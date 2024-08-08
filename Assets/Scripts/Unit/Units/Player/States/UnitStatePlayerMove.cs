using UnityEngine;
using Patterns;

namespace Game.Units.Controllers.States
{
    public class UnitStatePlayerMove : BasePlayerState
    {
        public UnitStatePlayerMove(IStateMachine machine) : base(machine)
        {
        }

        public override void Update()
        {
            base.Update();

            Move();

            if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
            {
                Controller.Switch(new UnitStatePlayerIdle(Controller));
                return;
            }
        }

        private void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 velocity = Controller.Owner.Transform.forward * z + Controller.Owner.Transform.right * x;
            Controller.Owner.RigidBody.velocity = Controller.Owner.Model.Data.Speed * Time.deltaTime * velocity;
        }
    }
}