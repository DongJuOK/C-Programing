using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace @new
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string m_num = Console.ReadLine();

            int.TryParse(m_num, out int num);

            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(num + " * " + i + " = " + (num * i));
            }
        }
    }
}
