using System;
using System.Collections.Generic;
using UnityEngine;
using UniVue.Event;
using UniVue.i18n;
using UniVue.View;

namespace UniVue.Test
{
    /*
     �����ǰ�Ų���ִ��˳����TMP_Dropdownִ��֮ǰ���ᵼ��TMP_Dropdown�İ󶨻ᱻTMP_Dropdown�ĳ�ʼ�����и��ǵ�����ʾ����
    ���Խ� [DefaultExecutionOrder(99999)]ע�͵���Ȼ����ᷢ��Country��ö����ʾ����ȷ�������󶨵���Japan������ʾ��ȴ��China��
    �Ⲣ���ǰ󶨴����ԭ�򣬶���TMP_Dropdown�ĳ�ʼ���Ḳ�ǵ�֮ǰ�󶨵Ľ��
    //����ԭ���Լ�����취������Ⱦ��TMP_Dropdown.value����Ϊ��ȷ����������
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

            //ע��
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
