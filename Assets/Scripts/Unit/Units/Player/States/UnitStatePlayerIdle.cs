using UnityEngine;
using Patterns;

namespace Game.Units.Controllers.States
{
    public class UnitStatePlayerIdle : BasePlayerState
    {
        public UnitStatePlayerIdle(IStateMachine machine) : base(machine)
        {
        }

        public override void Start()
        {
            base.Start();
            Controller.Owner.RigidBody.velocity = Vector3.zero;
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
            {
                Controller.Switch(new UnitStatePlayerMove(Controller));
                return;
            }
        }
    }
}