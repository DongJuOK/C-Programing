using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListEx
{
    public class Inven<T>
    {
        public T data;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Inven<int> invenA = new Inven<int>();
            invenA.data = 0;

            Inven<string> invenB = new Inven<string>();
            invenB.data = "";

            List<int> ints = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                ints.Add(i);
                Console.WriteLine("Count : " + ints.Count);
                Console.WriteLine("Capacity : " + ints.Capacity);
            }
            Console.ReadLine();
            LinkedList<int> list = new LinkedList<int>();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();


        }
    }
}