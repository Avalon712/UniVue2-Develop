using System;
using System.Collections.Generic;
using UnityEngine;
using UniVue.Event;
using UniVue.i18n;
using UniVue.View;

namespace UniVue.Test
{
    /*
     如果当前脚步的执行顺序在TMP_Dropdown执行之前，会导致TMP_Dropdown的绑定会被TMP_Dropdown的初始化进行覆盖导致显示错误
    可以将 [DefaultExecutionOrder(99999)]注释掉，然后你会发现Country的枚举显示不正确，本来绑定的是Japan但是显示的却是China，
    这并不是绑定错误的原因，而是TMP_Dropdown的初始化会覆盖掉之前绑定的结果
    //问题原因以及解决办法：在渲染后将TMP_Dropdown.value设置为正确的索引即可
     */
    // [DefaultExecutionOrder(99999)]
    [EventRegister]
    public sealed partial class EnumBindTest : MonoBehaviour
    {
        public VueConfig _config;

        private void Awake()
        {
            Vue.Initialize(_config);
            Vue.LoadAllViewObject();
        }

        private bool _initilaized;

        private void Start()
        {
            User user = new User()
            {
                Gender = Gender.Boy,
                Hobby = Hobby.Writing,
                Country = Country.Japan,
                Language = new List<string>() { "zh_CN", "ja_JP", "en_US" }
            };

            TestView UserInputView = new TestView("UserInputView") { Level = ViewLevel.Common, state = true };
            UserInputView.BindModel(user);

            TestView UserInfoView = new TestView("UserInfoView") { Level = ViewLevel.Common, state = true };
            UserInfoView.BindModel(user);

            Vue.Router.AddView(UserInputView);
            Vue.Router.AddView(UserInfoView);

            //注册
            Vue.Event.Register(this);
        }

        private void Update()
        {
            if (_initilaized)
            {
                return;
            }
           
            _initilaized = true;
        }

        [EventCall]
        private void ChangeLanguage(string lang)
        {
            if (Lang.TryParse(lang, out Language language))
            {
                Vue.language = language;
                Debug.Log(language);
            }
        }

    }


}
