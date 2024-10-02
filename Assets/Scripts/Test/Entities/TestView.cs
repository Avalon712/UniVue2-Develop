using UniVue.View;

namespace UniVue.Test
{
    public sealed class TestView : IView
    {
        public bool state { get; set; }

        public ViewLevel Level { get; set; }

        public string Name { get; }

        public TestView(string name)
        {
            Name = name;
        }

        public void Close()
        {
            if (state)
            {
                state = false;
                this.GetViewObject().SetActive(false);
            }
        }

        public void OnUnload() { }

        public void Open()
        {
            if (!state)
            {
                state = true;
                this.GetViewObject().SetActive(true);
            }
        }
    }
}
