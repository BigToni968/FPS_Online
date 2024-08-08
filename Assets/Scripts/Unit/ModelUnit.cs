using UnityEngine;
using Patterns;
using System;

namespace Game.Models
{
    [Serializable]
    public struct UnitData
    {
        public string Name;
        [TextArea(5, 10)] public string Description;

        public float HP;
        public float MaxHP;
        public float Speed;
        public float SpeedRun;
        public float SpeedRotation;
    }

    [Serializable]
    public class ModelUnit : Model<UnitData>
    {
    }
}