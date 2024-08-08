using Game.Invetorys.Items;
using Game.Gameplay.Items;
using UnityEngine;

namespace Game.Data
{
    public class BaseSOItem : ScriptableObject
    {
        [field: SerializeField] public ItemInteractive ItemInteractivePrefab { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Hint { get; private set; }
        [field: SerializeField, TextArea(5, 10)] public string Description { get; private set; }

        public virtual Item Item => null;
    }
}