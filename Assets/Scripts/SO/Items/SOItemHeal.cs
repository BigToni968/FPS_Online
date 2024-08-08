using Game.Invetorys.Items;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Items/Heal")]
    public class SOItemHeal : BaseSOItem
    {
        [field: SerializeField] public float HPBonus { get; private set; }

        public override Item Item => new ItemHeal();
    }
}