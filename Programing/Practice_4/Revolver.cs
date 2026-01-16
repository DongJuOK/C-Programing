using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Revolver
    {
        private Breech[] m_breech;

        public Breech[] Breech
        {
            get { return m_breech; }
        }

        private int m_breechCount;

        public int BreechCount
        {
            get { return m_breechCount; }
        }

        private int m_bulletCount;

        public int BulletCount
        {
            get { return m_bulletCount; }
        }

        public Revolver()
        {
            Console.Write("약실의 수를 입력하세요 : ");
            int.TryParse(Console.ReadLine(), out int brC);

            Console.Write("총알의 수를 입력하세요 : ");
            int.TryParse(Console.ReadLine(), out int buC);

            m_breech = new Breech[brC];
            m_breechCount = 0;
            m_bulletCount = buC;

            for (int i = 0; i < brC; i++)
            {
                m_breech[i] = new Breech();
            }
        }

        public void SetBullet()
        {
            for (int i = 0; i < m_bulletCount; i++)
            {
                if (Breech[i].IsBullet == false)
                {
                    Breech[i].SetBullet();
                }
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();

            for (int i = m_breech.Length - 1; i > 0; i--)
            {
                int index = rand.Next(0, i + 1);
                (m_breech[i], m_breech[index]) = (m_breech[index], m_breech[i]);
            }
        }

        public bool Shoot()
        {
            if (m_breech.All(x => x.IsEmpty()))
            {
                Console.WriteLine("총알이 장전되지 않았습니다.");
                Console.WriteLine();
                return false;
            }

            if (m_breech[BreechCount].Fire())
            {
                Console.WriteLine("탕!");
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("틱...");
                Console.WriteLine();
            }

            m_breechCount++;

            return false;
        }
    }
}
