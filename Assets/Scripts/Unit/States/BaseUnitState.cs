using State = Patterns.State;
using Patterns;

namespace Game.Units.Controllers.States
{
    public abstract class BaseUnitState : State
    {
        public BaseUnitController Controller { get; private set; }

        public BaseUnitState(IStateMachine machine)
        {
            Machine = machine;
            Controller = machine as UnitPlayerController;
        }
    }
}