namespace Patterns
{
    public interface IPresenatar
    {
        public IModel Model { get; }
        public IViewPresentar View { get; }

        public void OnInit();
    }

    public abstract class Presentar : IPresenatar
    {
        public IModel Model { get; private set; }
        public IViewPresentar View { get; private set; }

        public Presentar(IModel model, IViewPresentar view)
        {
            Model = model;
            View = view;
        }

        public virtual void OnInit() { }
    }
}