using UnityEngine;
using Game.Units;
using System;

namespace Game
{
    [Serializable]
    public class PlayerLook : IInitialization<Camera>, IUpdater
    {
        [field: SerializeField] public Transform Body { get; private set; }
        [field: SerializeField] public Transform Face { get; private set; }
        [field: SerializeField] public BaseUnit Player { get; private set; }
        [field: SerializeField] public float Smoothness { get; private set; } = 1f;
        [field: SerializeField] public Vector2 YClamp { get; private set; } = Vector2.one;

        public Camera Camera { get; private set; }

        public void Init(Camera data)
        {
            Camera = data;
        }

        public void OnUpdate()
        {
            RotateX();
            RotateY();
        }

        private void RotateX()
        {
            float mouseX = Input.GetAxis("Mouse X") * Player.Model.Data.SpeedRotation * Time.deltaTime;
            // –отаци€ вокруг оси Y (поворот тела персонажа)
            Body.Rotate(mouseX * Player.Model.Data.SpeedRotation * Vector3.up);
        }

        private void RotateY()
        {
            Vector3 position = Face.transform.localPosition;
            position.y += Input.GetAxis("Mouse Y") * Player.Model.Data.SpeedRotation * Smoothness * Time.deltaTime;
            position.y = Math.Clamp(position.y, YClamp.x, YClamp.y);
            Face.transform.localPosition = position;
        }
    }
}