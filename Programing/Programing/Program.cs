using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ArrayEx

{
    public class UnitParent
    {
        protected string name;
        protected int hp;

        public int Hp
        {
            get
            {
                return hp;
            }
        }
    }  

    public class Player : UnitParent
    {
        
    }

    public class Monster : UnitParent
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player playerA = new Player();
            Monster monA = new Monster();

            int _hp = playerA.Hp;

        }
    }
}
