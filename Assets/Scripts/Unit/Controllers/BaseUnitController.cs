using Patterns;

namespace Game.Units.Controllers
{
    public interface IUnitController : IInitialization<IUnit>, IStateMachine
    {
        public IUnit Owner { get; }
    }

    public abstract class BaseUnitController : IUnitController
    {
        public IUnit Owner { get; private set; }
        public IState Current { get; private set; }

        public virtual void Init(IUnit data)
        {
            Owner = data;
        }

        public virtual void OnUpdate()
        {
            Current?.Update();
        }

        public virtual void Switch(IState state)
        {
            Current?.Finish();
            Current = state;
            Current?.Start();
        }
    }
}