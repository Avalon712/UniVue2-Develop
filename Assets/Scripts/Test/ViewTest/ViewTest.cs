using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UniVue.View;

namespace UniVue.Test
{
    public sealed class ViewTest : MonoBehaviour
    {
        private sealed class View : IView
        {
            public bool state { get; private set; } = true;

            public ViewLevel Level => ViewLevel.Permanent;

            public string Name { get; }

            public View(string name)
            {
                Name = name;
                Vue.Router.AddView(this);
            }

            public void OnLoad()
            {

            }

            public void OnUnload()
            {

            }

            public void Open()
            {

            }

            public void Close()
            {

            }
        }

        private void Awake()
        {
            Vue.Initialize(VueConfig.New);
            Vue.LoadAllViewObject();
        }

        private void Start()
        {
            Dictionary<string, GameObject> viewObjects = (Dictionary<string, GameObject>)Vue.Router.GetType().GetField("_viewObjects", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(Vue.Router);
            foreach (var obj in viewObjects.Values)
            {
                new View(obj.name);
            }
        }
    }


}
