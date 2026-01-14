using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Revolver
    {
        List<bool> m_chamber;

        bool m_bullet;
        int m_size;
        int m_bullet_count;

        public List<bool> Chamber
        {
            get { return m_chamber; }
        }

        public bool Bullet
        {
            get { return m_bullet; }
        }

        public int Size
        {
            get { return m_size; }
        }

        public int Bullet_Count
        {
            get { return m_bullet_count; }
        }

        public Revolver()
        {
            m_chamber = new List<bool>();
            m_bullet = true;
            m_size = 0;
            m_bullet_count = 1;
        }

        public void setChamber()
        {
            Console.Write("약실의 수를 설정해주세요 : ");

            string chamber = Console.ReadLine();

            int.TryParse(chamber, out m_size);

            if (Size < 6 || Size > 50)
            {
                m_size = 6;
                Console.WriteLine("약실의 수가 범위를 벗어나 6으로 변경되었습니다.");
            }

            for (int i = 0; i < Size; i++)
            {
                m_chamber.Add(!Bullet);
            }
        }

        public void setBullet()
        {
            Console.Write("총알 수를 설정해주세요 : ");

            string bullet = Console.ReadLine();

            int.TryParse(bullet, out m_bullet_count);

            Random rand = new Random();

            if (Bullet_Count < 1 || Bullet_Count >= 50)
            {
                Console.WriteLine("잘못된 총알 수를 입력하여 1발만 장전되었습니다.");
                m_bullet_count = 1;
            }

            int count = 0;

            while (true)
            {
                int index = rand.Next(0, Size);

                if (count == Bullet_Count)
                    break;

                if (m_chamber[index] != Bullet)
                {
                    m_chamber[index] = Bullet;
                    count++;
                }
            }
        }
    }

    public class Player
    {
        protected string m_name;
        protected int m_count;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public int Count
        {
            get { return m_count; }
            set { m_count = value; }
        }

        public void Shoot()
        {
            m_count++;
            Console.WriteLine("방아쇠를 당깁니다.");
            Console.ReadKey();
        }
    }

    public class User : Player
    {
        User()
        {
            m_name = "";
            m_count = 0;
        }

        public void set_UserName()
        {
            Name = Console.ReadLine();
        }


    }

    internal class Program
    {
        static void Solo_GamePlay(int count)
        {
            Console.Clear();
            Console.WriteLine("1. 한 번 더 당긴다");
            Console.WriteLine("2. 그만둔다");
        }

        static void Multi_GamePlay(int count)
        {
            Console.Clear();
            Console.WriteLine("1. 한 번 더 당긴다");
            Console.WriteLine("2. 다음 상대에게 넘긴다");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        count++;
                        // 내 턴 지속
                        return;

                    case ConsoleKey.D2:
                        // 다음 상대의 턴
                        return;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Revolver revolver = new Revolver();

            revolver.setChamber();
            revolver.setBullet();
        }
    }
}

/*
   리볼버 - 6개의 약실 중에 1개만 총알이 들어가있다.

   1. 약실을 플레이어가 초기에 늘릴 수 있다.
      - 약실 : 6 그냥 이런식으로 적용 X
        변수를 통해서 약실 갯수를 변형이 가능해야한다.

   2. 총알을 여러개 넣는게 가능하게
      - 원래 정석은 6개의 약실에 총알 한 발
      - 20개의 약실에 총알 여러 발

   3. 혼자서, 1:1, 여러명 가능하게
      - 여러명일 경우 - Ex) 5명
      - 총알이 발사됐을때 그때 한명이 die
      - 약실에 총알을 다시 넣고
      - 5명 -> 4명
      - 최후 생존자가 나올 때 까지 or 내가 죽을 때 까지

   4. 러시아 룰렛인데
      - 플레이어만이 가질 수 있는 라이프
      - 아이템 - 총알이 있는지 없는지 확인하기
      - 특정 ai는 라이프가 더 있다. 얘도 아이템을 쓴다.

   5. 내가 스스로 방아쇠를 당긴다음
      - 한 번 더 당길지
      - 그냥 턴을 넘길지
 */
