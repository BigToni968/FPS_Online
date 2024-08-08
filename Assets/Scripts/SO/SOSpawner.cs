using Game.Models;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Spawner")]
    public class SOSpawner : ScriptableObject
    {
        [field: SerializeField] public ModelSpawner Model { get; private set; }
    }
}