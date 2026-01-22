using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Inventory
    {
        private Item item;

        public Item Item
        {
            get { return item; }
        }

        public Inventory()
        {
            item = new Item();
        }

        public bool IsEmpty()
        {
            return item.Quantity == 0;
        }

        public string GetItemInfo()
        {
            if (IsEmpty())
            {
                return "아이템이 비어있습니다.";
            }

            return item.ToString();
        }

        public void AddItem(Item _item)
        {
            item = _item;
        }

        public void UseItem(Player player)
        {
            item.Use(player);
        }
    }
}
