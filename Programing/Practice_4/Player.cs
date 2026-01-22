using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Player
    {
        private string m_name;
        private int m_hp;
        private bool m_playerturn;
        private bool m_isDead;
        private Inventory[] inventories;

        public string Name
        {
            get { return m_name; }
        }

        public int Hp
        {
            get { return m_hp; }
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
            inventories = new Inventory[5];

            for (int i = 0; i < inventories.Length; i++)
            {
                inventories[i] = new Inventory();
            }
        }

        public bool OnTurn()
        {
            m_playerturn = true;

            return m_playerturn;
        }

        public bool OffTurn()
        {
            m_playerturn = false;

            return m_playerturn;
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

        public void Heal(int _heal)
        {
            m_hp += _heal;
        }

        public void ShowInven()
        {
            for (int i = 0; i < inventories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {inventories[i].GetItemInfo()}");
            }

            Console.WriteLine();
        }

        public void AddItem(Item item)
        {
            for (int i = 0; i < inventories.Length; i++)
            {
                if (inventories[i].IsEmpty())
                {
                    inventories[i].AddItem(item);
                    return;
                }
            }

            Console.WriteLine("Inventory is Full");
        }

        public void UseItem(int key)
        {
            inventories[key].UseItem(this);
        }
    }
}
