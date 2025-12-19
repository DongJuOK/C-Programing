using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char c = '0';
            string str = "abcdef";
            str = str.Replace("c", "a");
            string temp = str.Substring(1, 5);
            temp = temp.Replace("a", "c");

            string result = str[0] + temp;

            c = (char)97;

            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}
