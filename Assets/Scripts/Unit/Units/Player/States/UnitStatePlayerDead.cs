using Patterns;

namespace Game.Units.Controllers.States
{
    public class UnitStatePlayerDead : BasePlayerState
    {
        public UnitStatePlayerDead(IStateMachine machine) : base(machine)
        {
        }
    }
}