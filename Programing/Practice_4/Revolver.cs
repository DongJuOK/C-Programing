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

        public Revolver(int _size = 6, int _count = 1)
        {
            m_breech = new Breech[_size];
            m_breechCount = 0;
            m_bulletCount = _count;
        }

        public void SetBullet()
        {
            for (int i = 0; i < m_bulletCount; i++)
            {
                m_breech[i] = new Breech();
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

        public void Shoot()
        {
            if (m_breech.All(x => x == null))
            {
                Console.WriteLine("총알이 모두 발사되었습니다.");
                Console.WriteLine();
            }
            else
            {
                if (m_breech[BreechCount] != null)
                {
                    Console.WriteLine("탕!");
                    Console.WriteLine();
                    m_breech[BreechCount] = null;
                }
                else
                {
                    Console.WriteLine("틱...");
                    Console.WriteLine();
                }
            }

            m_breechCount++;
        }
    }
}
