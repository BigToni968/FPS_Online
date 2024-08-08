using System.Collections.Generic;
using Game.Gameplay.Items;
using UnityEngine;
using Game.Units;
using System;

namespace Game
{
    [Serializable]
    public class PlayerDetection : UnitDetection
    {
        public Player Player { get; private set; }

        private IItemUp _itemUp;
        private RaycastHit[] _hits = new RaycastHit[10];

        public override void Init(IUnit data)
        {
            base.Init(data);

            Player = data as Player;

            if (SODetection != null)
            {
                Init(SODetection);
            }
        }

        public override bool TryFind<T>(Transform findPoint, float radius, float distance, LayerMask layerMask, out T result)
        {
            result = null;

            if (Physics.SphereCast(findPoint.position, Radius, findPoint.forward * -1, out RaycastHit hit, distance, layerMask) && hit.collider.TryGetComponent<T>(out T find))
            {
                result = find;
                return true;
            }

            return false;
        }

        public override bool TryFind<T>(Transform findPoint, float radius, float distance, LayerMask layerMask, out List<T> result)
        {
            result = null;

            Physics.SphereCastNonAlloc(findPoint.position, radius, findPoint.forward * -1, _hits, distance, layerMask);

            if (_hits.Length > 0)
            {
                for (int i = 0; i < _hits.Length; i++)
                {
                    if (_hits[i].collider != null && _hits[i].collider.TryGetComponent<T>(out T find))
                    {
                        result ??= new(10);
                        result.Add(find);
                    }
                }
            }

            _hits = new RaycastHit[10];

            return result != null;
        }

        private void CorrectDetectPoint()
        {
            Vector3 pos = Player.Look.Face.localPosition;
            pos.z = Distance;
            Player.TouchPoint.localPosition = pos;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            CorrectDetectPoint();


            if (TryFind<IItemUp>(Player.TouchPoint, Radius, Distance, FindLayer, out List<IItemUp> itemUp))
            {
                for (int i = 1; i < itemUp.Count; i++)
                {
                    itemUp[i].UnitExiteLook();
                }

                if (_itemUp != null && _itemUp != itemUp[0])
                {
                    HideItemUp();
                }

                _itemUp = itemUp[0];
                _itemUp.UnitEnterLook();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    _itemUp.Execute(Player);
                    _itemUp = null;
                }
            }
            else if (_itemUp != null)
            {
                HideItemUp();
            }

            if (_itemUp != null && !string.IsNullOrEmpty(_itemUp.HintText))
            {
                Player.Hint.SetHint(_itemUp.HintText);
                Player.Hint.Show();
            }
            else
            {
                Player.Hint.Hide();
            }

        }

        private void HideItemUp()
        {
            _itemUp.UnitExiteLook();
            _itemUp = null;
        }
    }
}