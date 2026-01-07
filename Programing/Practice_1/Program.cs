using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1
{
    public class Value
    {
        private double m_value;

        public double value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public Value()
        {
            m_value = 0;
        }

        public void Reset()
        {
            m_value = 0;
        }
    }

    internal class Program
    {
        public static double[] Input()
        {
            Console.Clear();
            Console.Write("숫자를 공백을 두고 입력해주세요 : ");
            string m_num = Console.ReadLine();

            string[] num = m_num.Split();
            double[] nums = new double[num.Length];

            for (int i = 0; i < num.Length; i++)
            {
                double.TryParse(num[i], out nums[i]);
            }

            return nums;
        }

        public static string op_Input()
        {
            Console.Write("연산자를 입력 해주세요 : ");
            string op = Console.ReadLine();

            return op;
        }

        public static double Sum(double[] nums)
        {
            double result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                result += nums[i];
            }

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine(result);
            Console.WriteLine();

            return result;
        }

        public static double Sub(double[] nums)
        {
            double result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                result -= nums[i];
            }

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine(result);
            Console.WriteLine();

            return result;
        }

        public static double Mul(double[] nums)
        {
            double result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                result *= nums[i];
            }

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine(result);
            Console.WriteLine();

            return result;
        }

        public static double Div(double[] nums)
        {
            double result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine();
                    Console.WriteLine("0으로 나눌 수 없습니다.");
                    Console.WriteLine();
                    return 0;
                }
                else
                {
                    result /= nums[i];
                }
            }

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine(result);
            Console.WriteLine();

            return result;
        }

        public static double Cal(double[] nums, Value value, string opt)
        {
            if (opt == "+")
            {
                value.value += Sum(nums);

            }
            else if (opt == "-")
            {
                value.value += Sub(nums);
            }
            else if (opt == "*")
            {
                value.value += Mul(nums);
            }
            else if (opt == "/")
            {
                value.value += Div(nums);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine();
            }

            Console.WriteLine($"저장된 값 : {value.value}");
            Console.WriteLine();

            return value.value;
        }

        public static bool Menu(Value value)
        {
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine("1. 값 누적 및 계속");
            Console.WriteLine("2. 저장 값 초기화 및 계속");
            Console.WriteLine("3. 종료한다");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.D1 ||  keyInfo.Key == ConsoleKey.NumPad1)
            {
                return true;
            }
            else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
            {
                value.Reset();
                return true;
            }
            else if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad3)
            {
                return false;
            }

            return false;
        }

        static void Main(string[] args)
        {
            Value value = new Value();

            while (true)
            {
                double[] nums = Input();
                string opt = op_Input();

                value.value = Cal(nums, value, opt);
                
                if (!Menu(value))
                {
                    break;
                }
            }
        }
    }
}

/*
1-1 덧셈만

정수 2개 입력 -> 덧셈 출력

1-2 사칙연산 전부

결과 모두 출력

1-3 연산자 선택

연산자 입력 -> 해당 연산만 실행

1-4 메뉴 반복

계산 계속 / 종료

1-5 메서드 나누기

Add / Sub / Mul / Div

1-6 0 나누기 방지

1-7 소수점 계산

double 사용

1-8 결과 누적

이전 결과 저장 후 다음 계산
 */