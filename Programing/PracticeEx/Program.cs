using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx
{
    class Monster
    {
        int hp;

        public int Hp { get { return hp; } }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 가장 기초 알고리즘

            // 제일 큰애, 제일 작은애, 같은애 위치, 배열값 복사하기, 배열 뒤집기

            // 0 ~ 9 까지 숫자가 랜덤하게 배열에 들어가 있어야 한다.

            // 숫자를 오름차순 0 ~ 9, 내림차순 9 ~ 0

            // 아래 두 배열 합치기

            int[] arrayA = new int[10];
            int[] arrayB = new int[10];

            int[] arrayResult = new int[arrayA.Length + arrayB.Length];

            for (int i = 0; i < arrayA.Length; i++)
            {
                arrayA[i] = i;
                arrayB[i] = i + 10;
            }

            // Random rnd = new Random();
            // 
            // for (int i = 0; i < arrayA.Length; i++)
            // {
            //     int _value = rnd.Next(0, arrayA.Length);
            //     int _temp = arrayA[i];
            //     arrayA[i] = arrayA[_value];
            //     arrayA[_value] = _temp;
            // }

            for (int i = 0; i < arrayA.Length; i++)
            {
                arrayResult[i] = arrayA[i];
            }

            for (int i = 0; i < arrayB.Length; i++)
            {
                arrayResult[arrayA.Length + i] = arrayB[i];
            }

            for (int i = 0; i < arrayResult.Length; i++)
            {
                Console.Write(arrayResult[i] + " ");
            }

            Console.WriteLine();

            int mid_size = arrayResult.Length / 2;

            int[] arrayC = new int[mid_size];
            int[] arrayD = new int[mid_size];

            for (int i = 0; i < mid_size; i++)
            {
                arrayC[i] = arrayResult[i];
                arrayD[i] = arrayResult[mid_size + i];
            }

            for (int i = 0; i < mid_size; i++)
            {
                Console.Write(arrayC[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < mid_size; i++)
            {
                Console.Write(arrayD[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
