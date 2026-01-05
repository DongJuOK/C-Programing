using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG
{
    public class Warrior : PlayerUnit
    {
        public Warrior(string _name, int _lv, int _atk, int _def, int _gold = 300)
        {
            m_name = _name;
            m_lv = _lv;
            m_attValue = _atk;
            m_defvalue = _def;
            m_exp = 0;
            m_hp = 100;
            m_mp = 30;
            m_gold = _gold;

            CurX = 1;
            CurY = 1;
        }
    }
}
