using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior playerWarrior = new Warrior("전사", 1, 10, 3);

            WorldMap map = new WorldMap();

            while (true)
            {
                Console.Clear();
                map.ShowScreenMap(playerWarrior);
                playerWarrior.ShowStatus();
                playerWarrior.InputMove(Console.ReadKey(), map.GetCurMapSize(0), map.GetCurMapSize(1));
            }
        }
    }
}

/*

1. 맵 만들기
   - 완 -  나중에 수정을 할 수도 있지만
2. 캐릭터 클래스
   - 완 - 수정 할 수 있지만
3. 인벤토리
4. 아이템 만들기

*/