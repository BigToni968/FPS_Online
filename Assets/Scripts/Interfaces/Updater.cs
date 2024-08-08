using UnityEngine;

namespace Game
{
    public interface IUpdater
    {
        public void OnUpdate();
    }

    public abstract class MonoUpdater : MonoBehaviour, IUpdater
    {
        public virtual void OnUpdate()
        {
        }
    }
}