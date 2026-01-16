using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Bullet
    {
        private int m_attack;

        public int Attack
        {
            get { return m_attack; }
        }

        public Bullet()
        {
            m_attack = 1;
        }
    }
}
