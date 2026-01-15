using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class GamePlay
    {
        private Revolver revolver;

        public Revolver Revolver
        {
            get { return revolver; }
        }

        public GamePlay(int size, int bullet)
        {
            revolver = new Revolver(size, bullet);
        }

        public void Setting()
        {
            Revolver.SetBullet();
            Revolver.Shuffle();
            Console.Clear();
        }

        public void Play()
        {
            Revolver.Shoot();

            while (true)
            {
                Console.WriteLine("1. 추가 발사한다");
                Console.WriteLine("2. 턴을 넘긴다.");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        return;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        // 상대 턴
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 키 입력 입니다.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
