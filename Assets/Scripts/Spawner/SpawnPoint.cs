using UnityEngine;

namespace Game
{
    public interface ISpawnPoint
    {
        public Color Color { get; }
        public float Radius { get; }
        public Vector3 Position { get; }
    }

    public class SpawnPoint : MonoBehaviour, ISpawnPoint
    {
        [field: SerializeField] public Color Color { get; private set; } = Color.green;
        [field: SerializeField] public float Radius { get; private set; }

        public Vector3 Position => transform.position;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color;
            Gizmos.DrawWireSphere(Position, Radius);
        }
    }
}