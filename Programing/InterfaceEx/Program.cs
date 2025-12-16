using System.Security.Cryptography.X509Certificates;

namespace InterfaceEx
{
    public interface IBattle
    {
        int Att { get; set; }
        void Damaged(UnitParent unit);
    }

    public class UnitParent
    {
        public int hp;
        public int att;
        public void Damaged(IBattle unit)
        {
            Console.WriteLine("상대방의 공격 : " + unit.att);
        }
    }

    public class Player : UnitParent, IBattle
    {
        public int Att 
        { 
            get
            {
                return att;
            }
            set
            {
                att = value;
            }
        }

        public void TestFunc()
        {

        }
    }

    public class Monster : UnitParent, IBattle
    {
        public int Att
        {
            get
            {
                return att;
            }
            set
            {
                att = value;
            }
        }
    }

    public class FightNPC : UnitParent, IBattle
    {
        public int Att
        {
            get
            {
                return att;
            }
            set
            {
                att = value;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player playerA = new Player();
            Monster monA = new Monster();

            playerA.Att = 10;
            monA.Att = 20;

            monA.Damaged(playerA);

            int a = 0;

            Console.ReadLine();
        }
    }
}
