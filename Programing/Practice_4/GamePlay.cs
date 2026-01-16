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

        public Revolver Revolver
        {
            get { return m_revolver; }
        }

        public List<Player> Player
        {
            get { return m_player; }
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

            m_revolver = new Revolver();
            m_count = 0;
        }

        public void SetRevolver()
        {
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
            }

            m_player[m_count].OnTurn();

            Console.WriteLine($"{m_player[m_count].Name}의 턴\n");

            m_player[m_count].Hit(m_revolver.Shoot());

            Console.ReadKey(true);

            while (m_player[m_count].OnTurn())
            {
                if (m_player[m_count].IsDead)
                {
                    m_count++;
                    return;
                }

                Console.Clear();
                Console.WriteLine($"{m_player[m_count].Name}의 턴\n");
                Console.WriteLine("1. 추가 발사한다");
                Console.WriteLine("2. 턴을 넘긴다");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Clear();
                        m_player[m_count].Hit(m_revolver.Shoot());
                        Console.ReadKey(true);
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
