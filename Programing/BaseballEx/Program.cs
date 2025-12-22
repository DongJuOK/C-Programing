using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// 숫자 야구게임 만들기

// 룰 : 플레이어는 중복되지 않는 숫자 3개를 입력한다.
//      중복되는 숫자거나 숫자 3개가 아니면 아니라고 알려준다.
//      숫자 3개 입력시 비교를 하여 스트라이크와 볼을 체크해준다.

// 1. 처음에 화면에 야구게임이라고 출력해준다.

// 2. 컴퓨터가 중복되지 않는 랜덤한 숫자 3개 정하기

// 3. 플레이어가 뭐든 입력이 가능하게
//    - 문자열의 길이가 3인가?
//    - 입력된 문자들이 숫자인가?
//    - 입력된 숫자들이 중복되지 않는가?

// 4. 내가 올바르게 입력한 숫자가 컴퓨터가 처음 정한 숫자가 맞는지 비교를 한다.
//    - 숫자와 위치가 같은 경우 - S
//    - 숫자는 맞는데 위치가 다른 경우 - B

// 5. 몇번만에 맞췄는지에 대한 결과와 끝난다는 결과창이 나와야한다.
//    - 다시 숫자를 집어서 다시 게임이 되어야한다.

namespace BaseballEx
{
    internal class Program
    {
        static void ShowStartScreen()
        {
            Console.WriteLine("숫자 야구게임에 오신것을 환영합니다.");
            Console.WriteLine("중복되자 않는 숫자 3개를 입력해주세요.");
        }

        static int[] GetRandom()
        {
            Random rand = new Random();

            int[] arrayRand = new int[10];

            for (int i = 0; i < arrayRand.Length; i++)
            {
                arrayRand[i] = i;
            }

            for (int i = 0; i < arrayRand.Length; i++)
            {
                int randResult = rand.Next(i, arrayRand.Length);

                int temp = arrayRand[i];
                arrayRand[i] = arrayRand[randResult];
                arrayRand[randResult] = temp;
            }

            int[] arrayResult = new int[3];

            for (int i = 0; i < arrayResult.Length; i++)
            {
                arrayResult[i] = arrayRand[i];
            }

            return arrayResult;
        }

        static bool GetCheckNumber(string str)
        {
            bool _isLength = true;
            bool _isNumber = true;
            bool _isOverlap = true;

            // 문자열의 길이가 3이다
            if (str.Length != 3)
            {
                _isLength = false;

                if (str.Length < 3)
                {
                    Console.WriteLine("문자열의 길이가 3보다 작습니다.");
                }
                else
                {
                    Console.WriteLine("문자열의 길이가 3을 넘었습니다.");
                }
            }

            if (_isLength)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    char tempC = str[i];

                    if (tempC < 48 || tempC > 57)
                    {
                        _isNumber = false;
                    }
                }
            }

            if (_isNumber && _isLength)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if (str[i] == str[j])
                        {
                            _isOverlap = false;
                        }
                    }
                }
            }

            if (!_isOverlap)
            {
                Console.WriteLine("중복되는 숫자가 있습니다.");
            }

            if (!_isNumber)
            {
                Console.WriteLine("문자가 섞여있습니다.");
            }

            if (_isLength && _isNumber && _isOverlap)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            ShowStartScreen();
            int[] arrayCorrect = GetRandom();

            int _count = 0;

            while (true)
            {
                string inputStr = Console.ReadLine();
                bool _bool = GetCheckNumber(inputStr);

                if (_bool)
                {
                    _count++;
                    int _strike = 0;
                    int _ball = 0;

                    for (int i = 0; i < inputStr.Length; i++)
                    {
                        int tempNum = (int)inputStr[i] - 48;

                        for (int j = 0; j < arrayCorrect.Length; j++)
                        {
                            if (tempNum == arrayCorrect[j])
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

                    Console.WriteLine("S : " + _strike);
                    Console.WriteLine("B : " + _ball);

                    if (_strike == 3)
                    {
                        Console.WriteLine("정답입니다!");
                        Console.WriteLine("시도한 횟수 : " + _count);
                        Console.ReadKey();

                        Console.Clear();
                        ShowStartScreen();
                        arrayCorrect = GetRandom();
                        _count = 0;
                    }
                }
            }
        }
    }
}
