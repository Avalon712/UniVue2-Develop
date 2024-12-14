using UnityEngine;
using UnityEngine.UI;
using UniVue.Event;
using UniVue.Extensions;
using UniVue.View;
using UniVue.Widgets;

namespace UniVue.Test
{
    [EventRegister]
    public sealed partial class LoopableTest : MonoBehaviour
    {
        public int dataCount = 10;

        public LoopList vloopList;
        public LoopList hloopList;
        public LoopGrid vloopGrid;
        public LoopGrid hloopGrid;

        private ObservableList<ItemData> datas = new ObservableList<ItemData>();


        private void Awake()
        {
            Vue.Initialize(VueConfig.New);
            Vue.LoadAllViewObject();
        }

        private void Start()
        {
            for (int i = 0; i < dataCount; i++)
            {
                datas.Add(new ItemData() { ID = i });
            }

            vloopList.BindData(datas);
            hloopList.BindData(datas);
            vloopGrid.BindData(datas);
            hloopGrid.BindData(datas);

            Vue.Router.AddView(new TestView("LoopList-TestView") { Level = ViewLevel.System });
            Vue.Router.AddView(new TestView("LoopGrid-TestView") { Level = ViewLevel.System, state = true });
            Vue.Router.AddView(new TestView("TestOptionView") { Level = ViewLevel.Permanent });
            Vue.Router.AddView(new TestView("VBagView") { Level = ViewLevel.Permanent });

            vloopGrid.scrollRect.onValueChanged.AddListener(v =>
            {
                if (_selectedToggle != null && _selectedIndex != -1)
                {
                    bool visible = vloopGrid.IsVisible(_selectedIndex);
                    if (visible != _selectedToggle.isOn)
                        _selectedToggle.isOn = visible;
                }
            });

            Vue.Event.Register(this);
        }


        [EventCall]
        private void OnClick(int id)
        {
            Debug.Log($"OnClick - ID={id}");
        }

        [EventCall]
        private void AddItem(int id)
        {
            Debug.Log($"AddItem - ID={id}");
            datas.Add(new ItemData() { ID = id });
        }

        [EventCall]
        private void RemoveItem(int id)
        {
            Debug.Log($"RemoveItem - ID={id}");
            datas.RemoveAll(item => item.ID == id);
        }

        [EventCall]
        private void ScrollTo(int id)
        {
            vloopList.ScrollTo(datas.Find(item => item.ID == id));
            hloopList.ScrollTo(datas.Find(item => item.ID == id));
        }

        private int _selectedIndex = -1; //当前选中的Item
        private Toggle _selectedToggle;
        [EventCall]
        private void OnSelected(int id, EventUI eventUI)
        {
            ItemData item = datas.Find(item => item.ID == id);
            if (item == null) return;
            Toggle toggle = eventUI.GetUI<Toggle>();
            if (toggle.isOn)
            {
                if (_selectedToggle != null && _selectedToggle != toggle && _selectedToggle.isOn)
                    _selectedToggle.isOn = false;
                _selectedIndex = datas.IndexOf(item);
                _selectedToggle = toggle;
                Vue.Router.GetView("VBagView").BindModel(item, true, null, true);
            }
        }
    }
}


