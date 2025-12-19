using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballEx
{
    internal class Program
    {
        static void ShowStartScreen()
        {
            Console.WriteLine("야구게임에 오신것을 환영합니다.");
            Console.WriteLine("※룰 : 중복되지 않은 숫자 3개를 입력해주세요.");
        }

        static int[] GetNumber()
        {
            Random rand = new Random();

            int[] arrayRandNum = new int[10];

            for (int i = 0; i < arrayRandNum.Length; i++)
            {
                arrayRandNum[i] = i;
            }

            for (int i = 0; i < arrayRandNum.Length; i++)
            {
                int result = rand.Next(0, 10);

                int temp = arrayRandNum[i];

                arrayRandNum[i] = arrayRandNum[result];

                arrayRandNum[result] = temp;
            }

            return arrayRandNum;
        }

        static bool IsNumberCheck(string str)
        {
            if (str.Length != 3)
            {
                Console.WriteLine("입력하신 문자의 길이가 3개가 아닙니다.");
            }
            else
            {
                bool _isNum = true;
                bool _isDuplication = true;
                for (int i = 0; i < 3; i++)
                {
                    char temp = str[i];
                    if (48 <= temp && temp <= 57)
                    {
                        for (int a = 0; a < str.Length; a++)
                        {
                            for (int b = a + 1; b < str.Length; b++)
                            {
                                if (str[a] == str[b])
                                {
                                    _isDuplication = false;
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                    else
                    {
                        _isNum = false;
                    }
                }

                if (_isNum)
                {
                    if (_isDuplication)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("중복된 숫자가 있습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("입력받은 값 중에 문자가 있습니다.");
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            ShowStartScreen();

            int[] arrayCorrectNum = new int[3];
            int[] arrayResult = GetNumber();
            
            for (int i = 0; i < arrayCorrectNum.Length; i++)
            {
                arrayCorrectNum[i] = arrayResult[i];
            }

            while (true)
            {
                string str = Console.ReadLine();

                if (IsNumberCheck(str))
                {
                    int[] arrayEnterNum = new int[3];

                    for (int i = 0; i < arrayEnterNum.Length; i++)
                    {
                        arrayEnterNum[i] = int.Parse(str[i].ToString());
                    }

                    int _strike = 0;
                    int _ball = 0;

                    for (int i = 0; i < arrayCorrectNum.Length; i++)
                    {
                        for (int j = 0; j < arrayEnterNum.Length; j++)
                        {
                            if (arrayCorrectNum[i] == arrayEnterNum[j])
                            {
                                if (i == j)
                                {
                                    _strike++;
                                }
                                else
                                {
                                    _ball++;
                                }
                            }
                        }
                    }

                    Console.WriteLine(_strike + " S");
                    Console.WriteLine(_ball + " B");
                    Console.WriteLine();

                    if (_strike >= 3)
                    {
                        Console.WriteLine("게임 종료");
                        break;
                    }
                }
                else
                {

                }
            }
        }
    }
}
