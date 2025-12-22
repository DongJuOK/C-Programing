using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class Program
    {
        static void ShowScreen(string name, int hp, int att)
        {
            Console.WriteLine("STATES");
            Console.WriteLine("name : " + name);
            Console.WriteLine("hp : " + hp);
            Console.WriteLine("att : " + att);
            Console.WriteLine();
        }

        static void Select(string name, int hp, int att)
        {
            Console.WriteLine("1. 몬스터와 싸운다.");
            Console.WriteLine("2. 대기한다.");
            Console.WriteLine();

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch(keyInfo.Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("몬스터와 싸웁니다.");
                        Console.WriteLine();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Console.WriteLine("대기합니다.");
                        Console.WriteLine();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine();
                        break;
                    }
            }

            Console.ReadKey();
            Console.Clear();
            ShowScreen(name, hp, att);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the name : ");
            string name = Console.ReadLine();

            Console.Write("Please set the Hp : ");
            int hp = int.Parse(Console.ReadLine());

            Console.Write("Please set the att : ");
            int att = int.Parse(Console.ReadLine());

            Console.Clear();

            ShowScreen(name, hp, att);

            while (true)
            {
                Select(name, hp, att);
            }
        }
    }
}

// 스테이터스 창
// 화면 - 플레이어 정보
// name :
// hp :
// att :

// 입력받을 수 있다.
// 1. 몬스터와 싸운다. - 몬스터와 싸웁니다.
// 2. 대기한다. - 대기합니다.
// 3. 다른경우 - 잘못된 입력입니다.

// 1번 무조건 화면에 띄운다.
// 2번 입력을 받아서 결과창이 나와야한다.
// 3번 반복되야한다.
// 4번 클래스로 만든다.

// 추가 부분
// 클래스로 만든다.
// 싸운다 선택 이후 플레이어는 상단, 중단, 하단을 공격할 수 있다.
// 몬스터는 이 세 부위 상단, 중단, 하단을 랜덤하게 막고
// 막으면 공격은 무효 못막으면 데미지가 들어온다.
// 몬스터가 죽을 때 까지
