using Game.Models;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Units/Detection")]
    public class SODetection : ScriptableObject
    {
        [field: SerializeField] public DetectionModel Model { get; private set; }
    }
}