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

        public Bullet Bullet
        {
            get { return m_bullet; }
            set { m_bullet = value; }
        }

        public Breech()
        {
            m_bullet = new Bullet();
        }
    }
}
