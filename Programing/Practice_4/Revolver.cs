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

        private int m_breechCount;

        private int m_bulletCount;

        public Revolver(int breech, int bullet)
        {
            m_breech = new Breech[breech];
            m_breechCount = 0;
            m_bulletCount = bullet;

            for (int i = 0; i < breech; i++)
            {
                m_breech[i] = new Breech();
            }
        }

        public void SetBullet()
        {
            for (int i = 0; i < m_bulletCount; i++)
            {
                if (m_breech[i].IsBullet == false)
                {
                    m_breech[i].SetBullet();
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

        public bool Shoot(out Bullet bullet)
        {
            bullet = m_breech[m_breechCount].Fire();

            m_breechCount = (m_breechCount + 1) % m_breech.Length;

            return bullet != null;
        }

        public void Reload(int bullet = 1)
        {
            m_bulletCount = bullet;

            SetBullet();
            Shuffle();
        }

        public bool IsEmpty()
        {
            if (m_breech.All(x => x.IsEmpty()))
            {
                return true;
            }

            return false;
        }
    }
}
