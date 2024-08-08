using Game.Units.Controllers.States;
using Patterns;

namespace Game
{
    public abstract class BasePlayerState : BaseUnitState
    {
        public BasePlayerState(IStateMachine machine) : base(machine)
        {
        }

        public override void Update()
        {
            base.Update();

            if (Controller.Owner.Model.Data.HP < 0f && Controller.Current != null && !Controller.Current.GetType().Equals(typeof(UnitStatePlayerDead)))
            {
                Controller.Switch(new UnitStatePlayerDead(Controller));
                return;
            }
        }
    }
}