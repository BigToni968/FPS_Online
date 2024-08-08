using UnityEngine;
using Game.Data;

namespace Game.Invetorys.Items
{
    public class ItemHeal : Item
    {
        public override void OnExecute()
        {
            base.OnExecute();
            Debug.Log($"Unit {Owner.Model.Data.Name}, hp after {Owner.Model.Data.HP}");
            SOItemHeal itemHeal = SOItem as SOItemHeal;
            Owner.Model.Data.HP += itemHeal.HPBonus;
            Debug.Log($"Unit {Owner.Model.Data.Name}, hp before {Owner.Model.Data.HP}");
        }
    }
}