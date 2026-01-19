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
            Console.Write("약실의 수를 입력하세요 : ");
            int.TryParse(Console.ReadLine(), out int brC);

            Console.Write("총알의 수를 입력하세요 : ");
            int.TryParse(Console.ReadLine(), out int buC);

            m_revolver = new Revolver(brC, buC);

            m_revolver.SetBullet();
            m_revolver.Shuffle();
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

            m_player[m_count].OnTurn();

            while (m_player[m_count].OnTurn())
            {
                if (m_living_count <= 1)
                {
                    m_active = false;
                    return;
                }
                else if (m_revolver.IsEmpty())
                {
                    Console.WriteLine("모든 약실이 비어있습니다.\n");
                    Console.Write("재장전 할 총알의 수를 입력하세요 : ");
                    int.TryParse(Console.ReadLine(), out int buC);

                    m_revolver.Reload(buC);
                }

                Console.Clear();
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

                if (m_player[m_count].IsDead)
                {
                    m_count++;
                    m_living_count--;
                    return;
                }
                
                Console.WriteLine("1. 추가 발사한다");
                Console.WriteLine("2. 턴을 넘긴다");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        continue;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        m_player[m_count++].OffTurn();
                        return;

                    default:
                        Console.WriteLine("잘못된 키 입력 입니다.\n");
                        Console.ReadKey(true);
                        continue;
                }
            }
        }
    }
}
