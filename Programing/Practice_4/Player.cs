using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Player
    {
        private string m_name;
        private int m_hp;
        private bool m_playerturn;

        public string Name
        {
            get { return m_name; }
        }

        public int Hp
        {
            get { return m_hp; }
        }

        public bool PlayerTurn
        {
            get { return m_playerturn; }
        }

        public Player(string name = "Player")
        {
            m_name = name;
            m_hp = 1;
            m_playerturn = false;
        }

        public bool OnTurn()
        {
            m_playerturn = true;

            return PlayerTurn;
        }

        public bool OffTurn()
        {
            m_playerturn = false;

            return PlayerTurn;
        }

        public void Hit(bool _hit)
        {
            if (_hit == true)
            {
                m_hp--;
            }
        }
    }
}
