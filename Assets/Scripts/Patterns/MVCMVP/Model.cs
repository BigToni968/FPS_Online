using UnityEngine;
using System;

namespace Patterns
{
    public interface IModel
    {
    }

    public interface IModel<T> : IModel
    {
        public void OnInit(T model);
        public T Copy();
        public void Set(T data);
    }

    [Serializable]
    public abstract class Model<T> : IModel<T>
    {
        [SerializeField] public T Data;

        public virtual void OnInit(T model)
        {
            Data = model;
        }

        public virtual void OnInit(IModel<T> model)
        {
            if (!model.GetType().Equals(GetType()))
            {
                return;
            }

            OnInit((model as Model<T>).Data);
        }

        public virtual void Set(T data)
        {
            Data = data;
        }

        public virtual void Set(IModel<T> model)
        {
            if (!model.GetType().Equals(GetType()))
            {
                return;
            }

            Set((model as Model<T>).Data);
        }

        public virtual T Copy()
        {
            return Data;
        }

        public virtual Model<T> Clone()
        {
            return MemberwiseClone() as Model<T>;
        }
    }
}