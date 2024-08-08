using Game.Invetorys.Items;
using Game.Units;

namespace Game.Invetorys
{
    public class Inventory : BaseInventory<IItem>
    {
        public Inventory(IUnit owner) : base(owner)
        { }

        public override void Add(IItem item)
        {
            base.Add(item);

            if (_items.Contains(item))
            {
                _items[_items.IndexOf(item)].Count += item.Count;
                return;
            }

            _items.Add(item);
            item.ItemCallback += Remove;
            item.Owner = Owner;
        }

        public override void Remove(IItem item)
        {
            base.Remove(item);

            if (_items.Contains(item))
            {
                int index = _items.IndexOf(item);
                _items[index].Count -= item.Count;

                if (_items[index].Count < 1)
                {
                    _items[index].ItemCallback -= Remove;
                    _items[index].Owner = null;
                    _items.RemoveAt(index);
                }
            }
        }
    }
}