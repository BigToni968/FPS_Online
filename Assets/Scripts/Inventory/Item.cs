using Game.Data;

namespace Game.Invetorys.Items
{
    public class Item : BaseItem, IInitialization<BaseSOItem>
    {
        public BaseSOItem SOItem { get; private set; }

        public void Init(BaseSOItem data)
        {
            SOItem = data;
        }
    }
}