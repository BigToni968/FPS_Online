using UnityEngine.EventSystems;
using Game.Invetorys.Items;
using UnityEngine.UI;
using UnityEngine;
using Patterns;
using TMPro;

namespace Game.UI
{
    public enum ItemSlotTypeCallback
    {
        Drop,
        Execute
    }

    public interface IUI_ItemSlotCallback
    {
        public delegate void ItemSlotCallbackDelegate(IUI_ItemSlot slot, ItemSlotTypeCallback callbackType);
        public event ItemSlotCallbackDelegate SlotCallback;
    }

    public interface IUI_ItemSlot : IInitialization<Item>, IView, ICommand, IUI_ItemSlotCallback
    {
        public IItem Item { get; }

        public void Drop();
        public void Destroyed();
    }

    public class UI_ItemSlot : ViewController, IUI_ItemSlot, IPointerDownHandler
    {
        [field: SerializeField] public RawImage Background { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Title { get; private set; }

        public event IUI_ItemSlotCallback.ItemSlotCallbackDelegate SlotCallback;

        public IItem Item { get; private set; }

        public void Init(Item data)
        {
            if (data.SOItem.Icon != null)
            {
                Background.texture = data.SOItem?.Icon.texture;

            }

            Title.SetText(data.SOItem.Name);
            Item = data;
        }

        public void Drop()
        {
            SlotCallback?.Invoke(this, ItemSlotTypeCallback.Drop);
        }

        public void Endo()
        {
        }

        public void Execute()
        {
            Item.Execute();
            SlotCallback?.Invoke(this, ItemSlotTypeCallback.Execute);
        }

        public void Destroyed()
        {
            Destroy(gameObject);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    Execute();
                    break;
                case PointerEventData.InputButton.Right:
                    Drop();
                    break;
            }
        }
    }
}