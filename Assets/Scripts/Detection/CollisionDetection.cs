using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class CollisionDetection : BaseDetection
    {
        public override bool TryFind<T>(Transform findPoint, float radius, float distance, LayerMask layerMask, out T result)
        {
            result = null;
            Vector3 pos = findPoint.localPosition / 2;
            Physics.OverlapSphereNonAlloc(pos, radius, _colliders, layerMask);

            if (_colliders.Length > 0)
            {
                for (int i = 0; i < _colliders.Length; i++)
                {
                    if (_colliders[i].TryGetComponent<T>(out T find))
                    {
                        result = find;
                        return true;
                    }
                }
            }

            _colliders = new Collider[0];
            return false;
        }
    }
}