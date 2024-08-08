using UnityEngine;
using Patterns;
using System;

namespace Game.Models
{
    [Serializable]
    public struct WeaponData
    {
        public Sprite Icon;
        public string Name;
        [TextArea(5, 10)] public string Description;
    }

    [Serializable]
    public class WeaponModel : Model<WeaponData>
    {
    }
}