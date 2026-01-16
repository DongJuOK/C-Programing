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
        private bool m_isDead;

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

        public bool IsDead
        {
            get { return m_isDead; }
        }

        public Player(string name = "Player")
        {
            m_name = name;
            m_hp = 1;
            m_playerturn = false;
            m_isDead = false;
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

        public void Hit(Bullet bullet)
        {
            if (bullet == null || m_isDead)
            {
                return;
            }

            m_hp -= bullet.Attack;

            if (m_hp <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            m_isDead = true;
            Console.WriteLine($"{m_name}가 죽었습니다.");
        }
    }
}
