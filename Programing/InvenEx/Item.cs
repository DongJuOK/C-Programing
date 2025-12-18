using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenEx
{
    public class Item
    {
        protected string name;
        public string Name { get { return name; } }
        protected int price;
        public int Price { get { return price; } }

        public string GetName()
        {
            return name;
        }

        public Item(string _name, int _price)
        {
            name = _name;
            price = _price;
        }
    }

    public class CashItem : Item
    {
        public CashItem(string _name, int _price) : base(_name, _price)
        {

        }
    }

    public class NormalItem : Item
    {
        public NormalItem(string _name, int _price) : base(_name, _price)
        {

        }
    }

    public class PlayerPet : Item
    {
        public PlayerPet(string _name, int _price) : base(_name, _price)
        {

        }
    }

}