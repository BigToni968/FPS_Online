using Game.Units;
using Patterns;

namespace Game.Invetorys.Items
{
    public interface IItemCallback
    {
        public delegate void ItemCallbackDelegate(IItem item);
        public event ItemCallbackDelegate ItemCallback;
    }

    public interface IItem : ICommand, IItemCallback
    {
        public IUnit Owner { get; set; }
        public int Count { get; set; }

        public void OnExecute();
    }

    public abstract class BaseItem : IItem
    {
        public int Count { get; set; } = 1;
        public IUnit Owner { get; set; }

        public event IItemCallback.ItemCallbackDelegate ItemCallback;

        public void Endo()
        { }

        public void Execute()
        {
            OnExecute();
            ItemCallback?.Invoke(this);
        }

        public virtual void OnExecute()
        { }
    }
}