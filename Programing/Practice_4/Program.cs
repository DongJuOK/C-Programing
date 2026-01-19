using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GamePlay game = new GamePlay();
            game.SetRevolver();

            while (game.Active)
            {
                game.Play();
                Console.Clear();
            }

            Console.WriteLine("게임 종료");
        }
    }
}

/*
   리볼버 - 6개의 약실 중에 1개만 총알이 들어가있다.

   1. 약실을 플레이어가 초기에 늘릴 수 있다.  - 클
      - 약실 : 6 그냥 이런식으로 적용 X
        변수를 통해서 약실 갯수를 변형이 가능해야한다.

   2. 총알을 여러개 넣는게 가능하게  - 클
      - 원래 정석은 6개의 약실에 총알 한 발
      - 20개의 약실에 총알 여러 발

   3. 혼자서, 1:1, 여러명 가능하게 - 클
      - 여러명일 경우 - Ex) 5명
      - 총알이 발사됐을때 그때 한명이 die
      - 약실에 총알을 다시 넣고
      - 5명 -> 4명
      - 최후 생존자가 나올 때 까지 or 내가 죽을 때 까지

   4. 러시아 룰렛인데
      - 플레이어만이 가질 수 있는 라이프
      - 아이템 - 총알이 있는지 없는지 확인하기
      - 특정 ai는 라이프가 더 있다. 얘도 아이템을 쓴다.

   5. 내가 스스로 방아쇠를 당긴다음 - 클
      - 한 번 더 당길지
      - 그냥 턴을 넘길지
 */
