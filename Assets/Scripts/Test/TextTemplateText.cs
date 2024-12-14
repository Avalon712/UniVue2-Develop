using System;
using System.Collections.Generic;
using UnityEngine;
using UniVue.Event;
using UniVue.i18n;
using UniVue.View;

namespace UniVue.Test
{
    [EventRegister]
    public sealed partial class TextTemplateText : MonoBehaviour
    {
        private void Awake()
        {
            Vue.Initialize(VueConfig.New);
            Vue.LoadAllViewObject();
        }

        private void Start()
        {
            Player test = new Player() { Name = "Test", Language = new List<string>(2) { "zh_CN", "en_US"} };
            TestView view = new TestView("TestTemplateView") { Level = View.ViewLevel.Permanent };
            Vue.Router.AddView(view);
            view.BindModel(test);

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

