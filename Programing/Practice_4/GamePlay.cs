using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class GamePlay
    {
        private Revolver m_revolver;

        private List<Player> m_player;

        private int m_count;

        private int m_living_count;

        private bool m_active;

        public bool Active
        {
            get { return m_active; }
        }

        public GamePlay()
        {
            m_player = new List<Player>();

            Console.Write("플레이어 수를 입력해주세요 : ");
            int.TryParse(Console.ReadLine(), out int pC);
            Console.WriteLine();

            if (pC <= 1)
            {
                Console.Write("플레이어의 이름을 입력해주세요 : ");
                string p_Name = Console.ReadLine();
                m_player.Add(new Player(p_Name));
                m_player.Add(new Player());
                Console.Clear();
            }
            else
            {
                for (int i = 0; i < pC; i++)
                {
                    Console.Write($"{i + 1}번째 플레이어의 이름을 입력해주세요 : ");
                    string p_Name = Console.ReadLine();
                    m_player.Add(new Player(p_Name));
                }

                Console.Clear();
            }
            
            m_count = 0;
            m_living_count = m_player.Count;
            m_active = true;
        }

        public void SetRevolver()
        {
            int brC = ReadInt("약실의 수를 입력하세요 : ");
            int buC = ReadInt("총알의 수를 입력하세요 : ");

            if (brC < 6)
            {
                Console.WriteLine("\n약실의 수가 너무 적어 6칸으로 조정되었습니다.");
            }

            if (buC >= brC)
            {
                Console.WriteLine($"\n총알의 수가 약실의 수보다 같거나 많아 1발로 조정되었습니다.");
            }

            m_revolver = new Revolver(brC, buC);

            m_revolver.SetBullet();
            m_revolver.Shuffle();
            Console.ReadKey(true);
            Console.Clear();
        }

        public void Play()
        {
            m_count %= m_player.Count;

            if (m_player[m_count].IsDead)
            {
                m_count++;
                return;
            }

            if (m_living_count <= 1)
            {
                Console.Clear();
                m_active = false;
                return;
            }

            Fire();

            m_player[m_count].OnTurn();

            while (m_player[m_count].OnTurn())
            {
                if (m_player[m_count].IsDead)
                {
                    m_count++;
                    m_living_count--;
                    return;
                }
                
                Console.WriteLine("1. 추가 발사한다");
                Console.WriteLine("2. 턴을 넘긴다\n");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Fire();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        m_player[m_count++].OffTurn();
                        return;

                    default:
                        Console.WriteLine("잘못된 키 입력 입니다.\n");
                        Console.ReadKey(true);
                        Console.Clear();
                        ShowPlayerInfo();
                        Console.WriteLine($"{m_player[m_count].Name}의 턴\n");
                        break;
                }
            }
        }

        private void Fire()
        {
            if (m_living_count <= 1)
            {
                m_active = false;
                return;
            }
            else if (m_revolver.IsEmpty())
            {
                Console.Clear();
                Console.WriteLine("모든 약실이 비어있습니다.\n");
                Console.Write("재장전 할 총알의 수를 입력하세요 : ");
                int.TryParse(Console.ReadLine(), out int buC);
                m_revolver.Reload(buC);
            }

            Console.Clear();
            ShowPlayerInfo();
            Console.WriteLine($"{m_player[m_count].Name}의 턴\n");

            bool fired = m_revolver.Shoot(out Bullet bullet);

            if (fired)
            {
                Console.WriteLine("탕!\n");
            }
            else
            {
                Console.WriteLine("틱...\n");
            }

            m_player[m_count].Hit(bullet);

            Console.ReadKey(true);
        }

        public void ShowPlayerInfo()
        {
            if (m_living_count <= 1)
            {
                m_active = false;
                return;
            }

            Console.Clear();

            m_count %= m_player.Count;

            if (!m_player[m_count].IsDead)
            {
                Console.WriteLine($"플레이어 이름 : {m_player[m_count].Name}");
                Console.WriteLine($"체력 : {m_player[m_count].Hp}");
                Console.WriteLine("생존 여부 : O\n");
                m_player[m_count].ShowInven();
            }
        }

        public int ReadInt(string msg)
        {
            while(true)
            {
                Console.Write(msg);

                if(int.TryParse(Console.ReadLine(), out int value) && value > 0)
                    return value;

                Console.WriteLine("\n잘못된 입력입니다.");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
