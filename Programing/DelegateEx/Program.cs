using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEx
{
    public abstract class Unit
    {
        public abstract void TestFunc();
    }

    public class Monster : Unit
    {
        public override void TestFunc()
        {
            
        }
    }

    public class Item
    {
        private string m_name;
        private int m_price;
        private int m_att;
        private int m_range;

        public int Price
        {
            get { return m_price; }
        }

        public delegate int ItemDelegate();
        public void TestDelegate(ItemDelegate dele)
        {
            dele();
        }

        // 딜리게이트를 통해서 만들어진 친구들
        // Action - 리턴을 안한다
        public Action<int, int> TestAction;

        // Func - 리턴을 한다
        public Func<int> TestFunc;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> listInt = new List<Item>();

            listInt.Add(new Item());
            listInt.Add(new Item());
            listInt.Add(new Item());

            listInt[0].TestDelegate( () => {
                Console.WriteLine("딜리게이트");
                return 0;
            } );

            listInt[0].TestAction = (a, b) => { Console.WriteLine($"{a} + {b} = {a + b}"); };
            listInt[0].TestAction.Invoke(1, 5);
            listInt[0].TestAction.Invoke(2, 7);
            listInt[0].TestAction(5, 11);

            Console.ReadKey();

            listInt.Sort( (a, b) => { return a.Price.CompareTo(b.Price); });
        }
    }
}
