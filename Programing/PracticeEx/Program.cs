using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayA = new int[10];

            // 0 ~ 9 까지 숫자가 랜덤하게 배열에 들어가 있어야 한다.

            Random rand = new Random();

            for (int i = 0; i < arrayA.Length; i++)
            {
                arrayA[i] = rand.Next(i, arrayA.Length);
            }

            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write(arrayA[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < arrayA.Length; i++)
            {
                int temp = arrayA[i];
                int index = i;

                for (int j = i + 1; j < arrayA.Length; j++)
                {
                    if (temp < arrayA[j])
                    {
                        temp = arrayA[j];
                        index = j;
                    }
                }

                temp = arrayA[i];
                arrayA[i] = arrayA[index];
                arrayA[index] = temp;
            }

            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write(arrayA[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < arrayA.Length; i++)
            {
                int temp = arrayA[i];
                int index = i;

                for (int j = i + 1; j < arrayA.Length; j++)
                {
                    if (temp > arrayA[j])
                    {
                        temp = arrayA[j];
                        index = j;
                    }
                }

                temp = arrayA[index];
                arrayA[index] = arrayA[i];
                arrayA[i] = temp;
            }

            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write(arrayA[i] + " ");
            }

            // 배열의 내용이 바뀌더라도 가능해야 합니다.
            // 배열에서 가장 큰 숫자를 max 넣어주세요.
            // 배열에서 가장 작은 숫자를 min 넣어주세요.

            Console.ReadKey();

            int _dropGold = 100; // 10 ~ 200
        }
    }
}
