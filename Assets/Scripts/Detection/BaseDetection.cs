using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using System;

namespace Game
{
    public interface IDetection : IInitialization<SODetection>
    {
        public SODetection SODetection { get; }
        public float Radius { get; }
        public float Distance { get; }
        public LayerMask FindLayer { get; }

        public bool TryFind<T>(Transform findPoint, out T result) where T : class;
        public bool TryFind<T>(Transform findPoint, float radius, float distance, LayerMask layerMask, out T result) where T : class;

        public bool TryFind<T>(Transform findPoint, out List<T> result) where T : class;
        public bool TryFind<T>(Transform findPoint, float radius, float distance, LayerMask layerMask, out List<T> result) where T : class;

    }

    [Serializable]
    public abstract class BaseDetection : IDetection
    {
        [field: SerializeField] public SODetection SODetection { get; private set; }
        [field: SerializeField] public float Radius { get; private set; } = .5f;
        [field: SerializeField] public float Distance { get; private set; } = 1f;
        [field: SerializeField] public LayerMask FindLayer { get; private set; } = -1;

        private protected Collider[] _colliders = new Collider[10];

        public void Init(SODetection data)
        {
            SODetection = data;
            Radius = data.Model.Data.Radius;
            Distance = data.Model.Data.Distance;
            FindLayer = data.Model.Data.FindLayer;
        }

        public bool TryFind<T>(Transform findPoint, out T result) where T : class
        {
            return TryFind<T>(findPoint, Radius, Distance, FindLayer, out result);
        }

        public bool TryFind<T>(Transform findPoint, out List<T> result) where T : class
        {
            return TryFind<T>(findPoint, Radius, Distance, FindLayer, out result);
        }

        public virtual bool TryFind<T>(Transform findPoint, float radius, float distance, LayerMask layerMask, out T result) where T : class
        {
            result = null;
            return false;
        }

        public virtual bool TryFind<T>(Transform findPoint, float radius, float distance, LayerMask layerMask, out List<T> result) where T : class
        {
            result = null;
            return false;
        }
    }
}