using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    class Character
    {
        protected string name;
        protected int hp;
        protected int att;

        public string Name => name;
        public int Hp => hp;
        public int Att => att;

        public void Attack(Character target)
        {
            target.hp -= att;
            Console.WriteLine($"{name}가 {target.name}에게 {att}만큼의 피해를 입혔습니다.");

            if ( target.hp <= 0 )
            {
                Console.WriteLine();
                Console.WriteLine($"{target.name}가 죽었습니다.");
            }
        }
    }

    class Player : Character
    {
        public Player()
        {
            name = "용사";
            hp = 100;
            att = 10;
        }
    }

    class Monster : Character
    {
        public Monster(Character character)
        {
            name = "몬스터";
            hp = character.Hp;
            att = character.Att / 2;
        }
    }

    internal class Program
    {
        static void ShowScreen(Character user)
        {
            Console.WriteLine("STATUS");
            Console.WriteLine("Name : " + user.Name);
            Console.WriteLine("HP : " + user.Hp);
            Console.WriteLine("ATT : " + user.Att);
            Console.WriteLine();
        }

        static void Select(Character user, Character mon)
        {
            Console.WriteLine("1. 몬스터와 싸운다.");
            Console.WriteLine("2. 대기한다.");
            Console.WriteLine("3. 잘못된 입력입니다.");
            Console.WriteLine();

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch(key.Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("몬스터와 싸웁니다.");
                        Console.WriteLine();
                        Fight(user, mon);
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
            ShowScreen(user);
        }

        static void Fight(Character user, Character mon)
        {
            Console.WriteLine($"{mon.Name}의 HP : {mon.Hp}");
            Console.WriteLine();
            Console.WriteLine("1. 상단 공격");
            Console.WriteLine("2. 중단 공격");
            Console.WriteLine("3. 하단 공격");
            Console.WriteLine();

            int count = 0;

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    {
                        count = 1;
                        Console.WriteLine("상단 공격을 합니다.");
                        Console.WriteLine();
                        Guard(count, user, mon);
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        count = 2;
                        Console.WriteLine("중단 공격을 합니다.");
                        Console.WriteLine();
                        Guard(count, user, mon);
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        count = 3;
                        Console.WriteLine("하단 공격을 합니다.");
                        Console.WriteLine();
                        Guard(count, user, mon);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                    }
            }
        }

        static Random rand = new Random();

        static void Guard(int count, Character user, Character mon)
        {
            int monsterGuard = rand.Next(1, 4);

            if (count == monsterGuard)
            {
                Console.WriteLine($"{mon.Name}가 공격을 막았습니다.");
            }
            else
            {
                user.Attack(mon);
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Monster monster = new Monster(player);

            ShowScreen(player);

            while (true)
            {
                Select(player, monster);

                if (monster.Hp <= 0)
                {
                    Console.WriteLine("게임 종료");
                    break;
                }
            }

            Console.ReadKey(true);
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
    }
}
