namespace Patterns
{
    public interface IController
    {
        public IModel Model { get; }
        public IView View { get; }

        public void OnInit();
    }

    public abstract class Controller : IController
    {
        public IModel Model { get; private set; }
        public IView View { get; private set; }

        public Controller(IModel model, IView view)
        {
            Model = model;
            View = view;
        }

        public virtual void OnInit() { }
    }
}