using Game.Models;
using UnityEngine;
using Game.Units;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Unit")]
    public class SOUnit : ScriptableObject
    {
        [field: SerializeField] public BaseUnit Prefab { get; private set; }
        [field: SerializeField] public ModelUnit ModelUnit { get; private set; }
    }
}