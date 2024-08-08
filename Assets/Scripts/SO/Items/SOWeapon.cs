using Game.Models;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Weapon/AssaultRifle")]
    public class SOWeapon : ScriptableObject
    {
        [field: SerializeField] public WeaponModel Model { get; private set; }
    }
}