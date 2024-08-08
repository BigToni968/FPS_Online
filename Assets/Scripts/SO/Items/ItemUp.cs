using Game.Invetorys.Items;
using Game.UI.Displays;
using UnityEngine;
using Game.Units;
using Game.UI;
using System;

namespace Game.Gameplay.Items
{
    public interface IItemUp : IItemInteractive
    {
    }

    public class ItemUp : ItemInteractive, IItemUp
    {
        [field: SerializeField] public UI_DisplayItemUp UI { get; private set; }
        [field: SerializeField] public ParticleSystem Mirror { get; private set; }

        public override void Constuctor(IUI_Manager data)
        {
            base.Constuctor(data);
            UI = data.Get<UI_DisplayItemUp>();
        }

        public override void UnitEnterLook()
        {
            base.UnitEnterLook();
            UI.Init(new() { Title = SOItem.Name, Description = SOItem.Description });
            UI.Show();
            Mirror.gameObject.SetActive(true);
        }

        public override void UnitExiteLook()
        {
            base.UnitExiteLook();
            UI.Hide();
            Mirror.gameObject.SetActive(false);
        }

        public override void Execute(IUnit unit)
        {
            base.Execute(unit);
            Item item = Activator.CreateInstance(SOItem.Item.GetType()) as Item;
            item.Init(SOItem);
            unit.Inventory.Add(item);
            Destroy(gameObject);
        }
    }
}