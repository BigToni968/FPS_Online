using Game.Units.Controllers.States;
using Game.Units.Controllers;
using Game.Invetorys;
using UnityEngine;
using Game.Data;
using Game.UI;
using Zenject;

namespace Game.Units
{
    public class Player : BaseUnit
    {
        [field: SerializeField] public WindowHint Hint { get; private set; }
        [field: SerializeField] public Transform TouchPoint { get; private set; }
        [field: SerializeField] public Transform FollowPoint { get; private set; }
        [field: SerializeField] public PlayerLook Look { get; private set; }

        public IUI_Inventory UI_Inventory { get; private set; }

        public override void Constuctor(DiContainer data)
        {
            base.Constuctor(data);
            UI_Manager = DiContainer.TryResolve<IUI_Manager>();
            UI_Inventory = UI_Manager.Get<IUI_Inventory>();
        }

        public IUI_Manager UI_Manager { get; private set; }

        public override void Init(SOUnit data)
        {
            base.Init(data);

            Look.Init(Camera.main);

            Controller = new UnitPlayerController();
            Controller.Init(this);
            Inventory = new Inventory(this);

            SODetection temp = Detection.SODetection;
            Detection = new PlayerDetection();
            Detection.Init(temp);
            Detection.Init(this);

            LockCursor();
        }

        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void UnLockCursor()
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void Rotate()
        {
            Look.OnUpdate();
        }

        public override void OnUpdate()
        {
            if (Controller.Current != null && Controller.Current.GetType().Equals(typeof(UnitStatePlayerDead)))
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                UnLockCursor();
                UI_Inventory?.Show();
            }

            Rotate();
            base.OnUpdate();
        }

        private void OnDrawGizmos()
        {
            if (Look.Face == null || TouchPoint == null || FollowPoint == null)
            {
                return;
            }

            //Draw face point
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(Look.Face.position, .5f);
            Gizmos.DrawRay(Look.Face.position, Look.Face.forward);

            //Draw touch point
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(TouchPoint.position, Detection.Radius);
            Gizmos.DrawRay(TouchPoint.position, (TouchPoint.forward * -1) * Detection.Distance);
        }
    }
}