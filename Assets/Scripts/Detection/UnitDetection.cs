using System.Collections.Generic;
using UnityEngine;
using Game.Units;
using System;

namespace Game
{
    [Serializable]
    public class UnitDetection : BaseDetection, IInitialization<IUnit>, IUpdater
    {
        public IUnit Owner { get; private set; }

        public virtual void Init(IUnit data)
        {
            Owner = data;
            Init(SODetection);
        }

        public override bool TryFind<T>(Transform findPoint, float radius, float distance, LayerMask layerMask, out T result)
        {
            result = null;

            if (Physics.Raycast(findPoint.position, findPoint.forward, out RaycastHit hit, distance, layerMask) && hit.collider.TryGetComponent<T>(out T find))
            {
                result = find;
                return true;
            }

            return false;
        }

        public override bool TryFind<T>(Transform findPoint, float radius, float distance, LayerMask layerMask, out List<T> result)
        {
            result = null;

            Physics.OverlapSphereNonAlloc(findPoint.position, radius, _colliders, layerMask);

            if (_colliders.Length > 0)
            {
                for (int i = 0; i < _colliders.Length; i++)
                {
                    if (_colliders[i] == null)
                    {
                        break;
                    }

                    if (_colliders[i].TryGetComponent<T>(out T find))
                    {
                        result ??= new List<T>();
                        result.Add(find);
                    }

                    _colliders[i] = null;
                }

                if (result != null)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void OnUpdate()
        { }
    }
}