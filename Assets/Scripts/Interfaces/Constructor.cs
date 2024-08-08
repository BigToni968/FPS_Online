using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public interface IConstructor
    {
        public DiContainer DiContainer { get; }
    }

    public interface IConstructor<T>
    {
        public void Constuctor(T data);
    }

    public abstract class MonoConstructor : MonoBehaviour, IConstructor, IConstructor<DiContainer>
    {
        [Inject]
        public DiContainer DiContainer { get; private set; }

        [Inject]
        public virtual void Constuctor(DiContainer data)
        {
            DiContainer = data;
        }
    }
}