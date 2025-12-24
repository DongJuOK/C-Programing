using Microsoft.Win32;
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
        protected int maxhp;
        public int attack_point;
        public int hit;

        public string Name => name;
        public int Hp => hp;
        public int Att => att;

        public void Attack(Character target)
        {
            target.hp -= att;
            Console.WriteLine($"{name}가 {target.name}에게 {att}만큼의 피해를 입혔습니다.");
            Console.WriteLine();

            if ( target.hp <= 0 )
            {
                Console.WriteLine();
                Console.WriteLine($"{target.name}가 죽었습니다.");
                Console.WriteLine();
            }
        }

        public virtual void Reset()
        {
            hp = maxhp;
            attack_point = 0;
            hit = 0;
        }

        public int Hit(Character character)
        {
            int _hit = 0;

            if (character.attack_point != 0)
            {
                _hit = (character.hit * 100) / character.attack_point;
            }

            return _hit;
        }
    }

    class Unit : Character
    {
        public Unit()
        {
            name = "용사";
            maxhp = 100;
            hp = maxhp ;
            att = 10;
            attack_point = 0;
            hit = 0;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }

    class Orc : Character
    {
        public Orc(Character character)
        {
            name = "몬스터";
            maxhp = character.Hp;
            hp = maxhp;
            att = character.Att / 2;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }

    internal class Program
    {
        static void ShowScreen(Character user, Character mon)
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Name : " + user.Name);
            Console.WriteLine("Hp : " + user.Hp);
            Console.WriteLine("Att : " + user.Att);
            Console.WriteLine("Hit : " + user.Hit(user));
            Console.WriteLine("==============================");
            Console.WriteLine("Name : " + mon.Name);
            Console.WriteLine("Hp : " + mon.Hp);
            Console.WriteLine("Att : " + mon.Att);
            Console.WriteLine("Hit : " + mon.Hit(mon));
            Console.WriteLine("==============================");
            Console.WriteLine();
        }

        static void Select(Character user, Character mon)
        {
            Console.WriteLine("1. 몬스터와 싸운다.");
            Console.WriteLine("2. 대기한다.");
            Console.WriteLine();

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch(key.Key)
            {
                case ConsoleKey.D1:
                    {
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
            ShowScreen(user, mon);
        }

        static void Fight(Character user, Character mon)
        {
            while (true)
            {
                Console.Clear();
                ShowScreen(user, mon);
                Console.WriteLine("몬스터와 싸웁니다.");
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
                            user.attack_point++;

                            Console.WriteLine("상단 공격을 합니다.");
                            Console.WriteLine();

                            monsterGuard(count, user, mon);

                            if (mon.Hp <= 0)
                            {
                                return;
                            }

                            Console.ReadKey(true);

                            Console.Clear();

                            ShowScreen(user, mon);
                            monsterAttack(user, mon);

                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            count = 2;
                            user.attack_point++;

                            Console.WriteLine("중단 공격을 합니다.");
                            Console.WriteLine();

                            monsterGuard(count, user, mon);

                            if (mon.Hp <= 0)
                            {
                                return;
                            }

                            Console.ReadKey(true);

                            Console.Clear();

                            ShowScreen(user, mon);
                            monsterAttack(user, mon);

                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            count = 3;
                            user.attack_point++;

                            Console.WriteLine("하단 공격을 합니다.");
                            Console.WriteLine();

                            monsterGuard(count, user, mon);

                            if (mon.Hp <= 0)
                            {
                                return;
                            }

                            Console.ReadKey(true);

                            Console.Clear();

                            ShowScreen(user, mon);
                            monsterAttack(user, mon);

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.ReadKey(true);
                            continue;
                        }
                }

                return;
            }
        }

        static Random rand = new Random();

        static void monsterGuard(int count, Character user, Character mon)
        {
            int monsterGuard = rand.Next(1, 4);

            if (count == monsterGuard)
            {
                Console.WriteLine($"{mon.Name}가 공격을 막았습니다.");
                Console.WriteLine();
            }
            else
            {
                user.Attack(mon);
                user.hit++;
            }
        }

        static void monsterAttack(Character user, Character mon)
        {
            while (true)
            {
                Console.WriteLine("몬스터가 공격합니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상단 방어");
                Console.WriteLine("2. 중단 방어");
                Console.WriteLine("3. 하단 방어");
                Console.WriteLine();

                int count = 0;

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            count = 1;
                            mon.attack_point++;

                            Console.WriteLine("상단 방어를 합니다.");
                            Console.WriteLine();

                            playerGuard(count, user, mon);

                            if (user.Hp <= 0)
                            {
                                Console.WriteLine("게임을 처음부터 재시작 합니다.");
                            }

                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            count = 2;
                            mon.attack_point++;

                            Console.WriteLine("중단 방어를 합니다.");
                            Console.WriteLine();

                            playerGuard(count, user, mon);

                            if (user.Hp <= 0)
                            {
                                Console.WriteLine("게임을 처음부터 재시작 합니다.");
                            }

                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            count = 3;
                            mon.attack_point++;

                            Console.WriteLine("하단 방어를 합니다.");
                            Console.WriteLine();

                            playerGuard(count, user, mon);

                            if (user.Hp <= 0)
                            {
                                Console.WriteLine("게임을 처음부터 재시작 합니다.");
                            }

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.ReadKey(true);

                            Console.Clear();
                            ShowScreen(user, mon);

                            continue;
                        }
                }

                return;
            }  
        }

        static void playerGuard(int count, Character user, Character mon)
        {
            int monsterAttack = rand.Next(1, 4);

            if (count == monsterAttack)
            {
                Console.WriteLine($"{user.Name}가 공격을 막았습니다.");
                Console.WriteLine();
            }
            else
            {
                mon.Attack(user);
                mon.hit++;
            }
        }

        static void Restart(Character user, Character mon)
        {
            if (mon.Hp <= 0)
            {
                mon.Reset();
                Console.Clear();
                ShowScreen(user, mon);
            }
            else if (user.Hp <= 0)
            {
                user.Reset();
                mon.Reset();
                Console.Clear();
                ShowScreen(user, mon);
            }
        }

        static void Main(string[] args)
        {
            Unit player = new Unit();
            Orc monster = new Orc(player);

            ShowScreen(player, monster);

            while (true)
            {
                Select(player, monster);

                Restart(player, monster);
            }

            Console.ReadKey(true);
        }
    }
}
