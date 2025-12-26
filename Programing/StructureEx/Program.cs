using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StructureEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayA = new int[10];

            arrayA[0] = 1;

            List<int> listA = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                listA.Add(i);
            }

            listA.Insert(5, -20);

            for (int i = 0; i < listA.Count; i++)
            {
                Console.WriteLine(listA[i] + " ");
            }

            Console.WriteLine($"listA.Count : {listA.Count}  listA.Capacity : {listA.Capacity}");

            MyList<int> myList = new MyList<int>();

            for (int i = 0; i < 10; i++)
            {
                myList.Add(i);
            }

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList.array[i] + " ");
            }

            Console.WriteLine();

            Console.WriteLine($"listA.Count : {listA.Count}  listA.Capacity : {listA.Capacity}");

            Console.ReadKey();
        }
    }
}
