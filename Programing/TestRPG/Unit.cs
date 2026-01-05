using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG
{
    public interface IMoveController
    {
        void InputMove(ConsoleKeyInfo _keyInfo, int _size);
        void 
    }

    public class Unit
    {
        protected string m_name;

        public string Name
        {
            get { return m_name; }
        }

        protected int m_lv;

        public int Lv
        {
            get { return m_lv; }
        }

        private int[] m_requireExp = new int[]
        {
            0, 100, 200, 300, 500, 1000
        };

        protected int m_exp;

        public int Exp
        {
            get { return m_exp; }
        }

        private double m_expPercentage => ((double)m_exp / m_requireExp[Lv]) * 100;

        protected int m_hp;

        public int Hp
        {
            get { return m_hp; }
        }

        protected int m_mp;

        public int Mp
        {
            get { return m_mp; }
        }

        protected int m_attValue;

        public int AttValue
        {
            get { return m_attValue; }
        }

        protected int m_defvalue;

        public int DefValue
        {
            get { return m_defvalue; }
        }

        protected int m_gold;

        public int Gold
        {
            get { return m_gold; }
        }

        public int CurX
        {
            get;
            set;
        }

        public int CurY
        {
            get;
            set;
        }

        public void ShowStatus()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"이름 : {Name}  lv : {Lv}  Exp : {m_expPercentage}%  {Exp}");
            Console.WriteLine($"HP : {Hp}  MP : {Mp}");
            Console.WriteLine($"공격력 : {AttValue}  방어력 : {DefValue}");
            Console.WriteLine($"골드 : {Gold}");
            Console.WriteLine("=====================================");
        }
    }
}
