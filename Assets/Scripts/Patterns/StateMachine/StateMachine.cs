namespace Patterns
{
    public interface IStateMachine
    {
        public IState Current { get; }

        public void Switch(IState state);
        public void OnUpdate();
    }

    public abstract class StateMachine : IStateMachine
    {
        public IState Current { get; private set; }

        public virtual void Switch(IState state)
        {
            Current?.Finish();
            Current = state;
            state?.Start();
        }

        public virtual void OnUpdate()
        {
            Current?.Update();
        }
    }
}