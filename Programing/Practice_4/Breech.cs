using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Breech
    {
        private Bullet m_bullet;

        private bool m_isBullet;

        public bool IsBullet
        {
            get { return m_isBullet; }
        }

        public Breech()
        {
            m_isBullet = false;
        }

        public void SetBullet()
        {
            m_isBullet = true;
            m_bullet = new Bullet();
        }

        public Bullet Fire()
        {
            if (!m_isBullet)
            {
                return null;
            }

            Bullet firedBullet = m_bullet;

            m_isBullet = false;
            m_bullet = null;

            return firedBullet;
        }

        public bool IsEmpty()
        {
            if (!m_isBullet && m_bullet == null)
            {
                return true;
            }

            return false;
        }
    }
}
