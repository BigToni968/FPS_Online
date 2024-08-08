using Game.Units.Controllers.States;

namespace Game.Units.Controllers
{
    public class UnitPlayerController : BaseUnitController
    {
        public override void Init(IUnit data)
        {
            base.Init(data);
            Switch(new UnitStatePlayerIdle(this));
        }
    }
}