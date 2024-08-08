using UnityEngine.EventSystems;
using UnityEngine;
using Game.Units;
using Game.Data;
using Zenject;
using Game.UI;

namespace Game.Gameplay.Items
{
    public interface IItemInteractive : IInitialization<BaseSOItem>, IConstructor<IUI_Manager>, IHint
    {
        public BaseSOItem SOItem { get; }
        public Transform Transform { get; }
        public EventSystem EventSystem { get; }

        public void UnitEnterLook();
        public void UnitExiteLook();
        public void Execute(IUnit owner);
    }

    public class ItemInteractive : MonoBehaviour, IItemInteractive
    {
        [field: SerializeField] public BaseSOItem SOItem { get; private set; }

        public Transform Transform => transform;
        public EventSystem EventSystem { get; private set; }
        public string HintText => SOItem != null ? SOItem.Hint : string.Empty;

        [Inject]
        public virtual void Constuctor(IUI_Manager data)
        {
            EventSystem = data.Get<EventSystem>();
        }

        public virtual void Init(BaseSOItem data)
        {
            SOItem = data;
        }

        public virtual void UnitEnterLook()
        {
            if (!EventSystem.IsPointerOverGameObject())
            {
                return;
            }
        }

        public virtual void UnitExiteLook()
        {
        }

        public virtual void Execute(IUnit unit)
        {
        }

    }
}