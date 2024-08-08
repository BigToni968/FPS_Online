using UnityEngine;
using Patterns;
using System;

namespace Game.Models
{
    [Serializable]
    public struct DetectionData
    {
        public float Radius;
        public float Distance;
        public LayerMask FindLayer;
    }

    [Serializable]
    public class DetectionModel : Model<DetectionData>
    {
    }
}