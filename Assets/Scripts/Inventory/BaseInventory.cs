using System.Collections.Generic;
using Game.Units;

namespace Game.Invetorys
{
    public interface IInventory<T>
    {
        public IReadOnlyList<T> Items { get; }
        public IUnit Owner { get; }

        public void Add(T item);
        public void Remove(T item);
    }

    public abstract class BaseInventory<T> : IInventory<T>
    {
        public IReadOnlyList<T> Items => _items;
        public IUnit Owner { get; }

        private protected List<T> _items;

        public BaseInventory(IUnit owner)
        {
            _items = new List<T>();
            Owner = owner;
        }

        public virtual void Add(T item)
        { }

        public virtual void Remove(T item)
        { }
    }
}