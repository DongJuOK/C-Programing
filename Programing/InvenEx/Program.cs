namespace InvenEx
{
    internal class Program
    {
        public class Inven
        {
            public Item[] 
        }

        public class Item
        {
            string name;
            public string Name { get { return name; } }
            int price;
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

        static void Main(string[] args)
        {
            Item itemA = new Item("단검", 100);
            Item itemB = new Item("장창", 500);
            Item itemC = new Item("지팡이", 1000);
           
        }
    }
}
