using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Game.Units;

namespace Game.Gameplay.Weapon
{
    public interface IWeapon : IInitialization<IUnit>
    {
        public IUnit Owner { get; }

        public void Fire();
        public void Reload();
    }

    public class Weapon : MonoBehaviour
    {
    }
}