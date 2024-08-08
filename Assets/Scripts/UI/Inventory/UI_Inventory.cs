using System.Collections.Generic;
using Game.Invetorys.Items;
using Game.Gameplay.Items;
using Game.Invetorys;
using UnityEngine;
using Game.Units;
using Patterns;

namespace Game.UI
{
    public interface IUI_Inventory : IInitialization<IUnit>, IInventory<IUI_ItemSlot>, IView
    {
    }

    public class UI_Inventory : ViewController, IUI_Inventory
    {
        [field: SerializeField] public UI_ItemSlot SlotPrefab { get; private set; }
        [field: SerializeField] public Transform Content { get; private set; }

        public IReadOnlyList<IUI_ItemSlot> Items => _items;
        public IUnit Owner { get; private set; }

        private List<IUI_ItemSlot> _items;

        public void Init(IUnit data)
        {
            Owner = data;
            _items = new(Owner.Inventory.Items.Count);
            Filling(Owner.Inventory);
        }

        private void Filling(IInventory<IItem> inventory)
        {
            foreach (IItem item in inventory.Items)
            {
                IUI_ItemSlot slot = Instantiate(SlotPrefab, Content);
                slot.Init(item as Item);
                Add(slot);
            }
        }

        private void Cleaning()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                Remove(_items[i]);
            }
        }

        private void OnEnable()
        {
            Filling(Owner.Inventory);
        }

        private void OnDisable()
        {
            Cleaning();

            if (Owner.GetType().Equals(typeof(Player)))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void Add(IUI_ItemSlot item)
        {
            item.Show();
            item.SlotCallback += ItemIvent;
            _items.Add(item);
        }

        public void Remove(IUI_ItemSlot item)
        {
            _items.Remove(item);
            item.Hide();
            item.SlotCallback -= ItemIvent;
            item.Destroyed();
        }

        private void ItemIvent(IUI_ItemSlot slot, ItemSlotTypeCallback typeCallback)
        {
            Item item = slot.Item as Item;

            switch (typeCallback)
            {
                case ItemSlotTypeCallback.Drop:
                    Owner.Inventory.Remove(slot.Item);
                    Vector3 forward = Owner.Transform.position + Owner.Transform.forward * 5 + Owner.Transform.up * 2;
                    Debug.Log($"Unit {Owner.Model.Data.Name} drop item {item.SOItem.Name}");
                    IItemInteractive interactive = GameObject.Instantiate(item.SOItem.ItemInteractivePrefab);
                    interactive.Constuctor(Owner.DiContainer.TryResolve<IUI_Manager>());
                    interactive.Init(item.SOItem);
                    interactive.Transform.position = forward;
                    break;
                case ItemSlotTypeCallback.Execute:
                    Debug.Log($"Unit {Owner.Model.Data.Name} execute item {item.SOItem.Name}");
                    break;
            }

            Cleaning();
            Filling(Owner.Inventory);
        }
    }
}