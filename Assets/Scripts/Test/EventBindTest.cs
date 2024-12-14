using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniVue.Event;

namespace UniVue.Test
{
    [EventRegister]
    public sealed partial class EventBindTest : MonoBehaviour
    {
        public VueConfig _config;

        private void Awake()
        {
            Vue.Initialize(_config);
            Vue.LoadAllViewObject();
        }

        private void Start()
        {
            Vue.Event.Register(this);
        }

        [EventCall]
        private void TestImageArg(Image img)
        {
            Debug.Log("TestImageArg");
        }

        [EventCall]
        private void TestTextArg(TMP_Text txt)
        {
            Debug.Log("TestTextArg");
        }
    }
}


