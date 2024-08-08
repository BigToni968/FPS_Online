using UnityEngine;

namespace Game
{
    public interface IInitialization<T, U>
    {
        public void Init(T data_0, U data_1);
    }

    public interface IInitialization<T>
    {
        public void Init(T data);
    }

    public interface IInitialization
    {
        public void Init();
    }

    public abstract class Initialization : IInitialization
    {
        public virtual void Init()
        {
        }
    }

    public abstract class Initialization<T> : IInitialization<T>
    {
        public virtual void Init(T data)
        {
        }
    }

    public abstract class MonoInitialization : MonoBehaviour, IInitialization
    {
        public virtual void Init()
        {
        }
    }

    public abstract class SOInitialization : ScriptableObject, IInitialization
    {
        public virtual void Init()
        {
        }
    }
}