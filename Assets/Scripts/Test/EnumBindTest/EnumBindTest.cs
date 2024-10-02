using System;
using System.Collections.Generic;
using UnityEngine;
using UniVue.Event;
using UniVue.i18n;
using UniVue.View;

namespace UniVue.Test
{
    [EventRegister]
    public sealed partial class EnumBindTest : MonoBehaviour
    {
        public VueConfig _config;

        private void Awake()
        {
            Vue.Initialize(_config);
            Vue.LoadAllViewObject();
        }


        private void Start()
        {
            User user = new User()
            {
                Gender = Gender.Boy,
                Hobby = Hobby.Writing,
                Country = Country.Japan,
                Language = new List<string>() { "zh_CN", "ja_JP", "en_US" }
            };

            TestView UserInputView = new TestView("UserInputView") { Level = ViewLevel.Common, state = true};
            UserInputView.BindModel(user);

            TestView UserInfoView = new TestView("UserInfoView") { Level = ViewLevel.Common, state = true };
            UserInfoView.BindModel(user);

            Vue.Router.AddView(UserInputView);
            Vue.Router.AddView(UserInfoView);

            //зЂВс
            Vue.Event.Register(this);
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
