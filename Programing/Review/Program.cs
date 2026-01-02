using System;

namespace Review
{
    public class Player
    {
        protected int m_hp;
        public int HP
        {
            get { return m_hp; }
        }
    }

    public class Program
    {
        // 정적 변수
        static int AAAAA;

        // 멤버 변수 (암묵적 룰로 m_을 붙임)
        int m_AAA;

        static void Main(/* int _a */) // 매개 변수
        {
            // 지역 변수
            int a;
            Program A;

            // 원래는 System.Console.WriteLine();
            // 위에서 using을 썼기 때문에 생략 가능
            Console.WriteLine("Hello C#");

            // Building();
            Triangle();
        }

        // 빌딩 만들기 메서드
        static void Building()
        {
            // 내가 입력한 숫자의 크기만큼
            // ㅁㅁㅁㅁㅁ
            // ㅁㅁㅁㅁㅁ
            // ㅁㅁㅁㅁㅁ
            // ㅁㅁㅁㅁㅁ
            // ㅁㅁㅁㅁㅁ
            // 건물 모양 나오게 하기.
            // 대신 가로길이도 조절 가능하게
            // 한번 입력으로
            // 11 12

            Console.Write("숫자 2개를 입력해주세요 : ");

            // string x = Console.ReadLine();
            // string x_width = "";
            // string x_height = "";
               
            // int index = 0;
               
            // for (int i = 0; i < x.Length; i++)
            // {
            //     if (x[i] == ' ')
            //     {
            //         index = i;
            //         break;
            //     }
            // }
               
            // for (int i = 0; i < index; i++)
            // {
            //     x_width += x[i];
            // }
               
            // for (int i = index; i < x.Length; i++)
            // {
            //     x_height += x[i];
            // }

            string[] str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // int height = int.Parse(str);      // Convert.ToInt32(str);

            int height = 0;
            int width = 0;
            
            // 파싱이 되면 True 그렇지 않으면 False  out은 타입에 맞는 값 반환
            if (str.Length != 2 || !int.TryParse(str[0], out height) || !int.TryParse(str[1], out width))
            {
                Console.WriteLine("잘못된 입력입니다.");
            }

            string a = new string('ㅁ', width);

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(a);
            }
            
            // for (int i = 0; i < height; i++)
            // {
            //     for (int j = 0; j < width; j++)
            //     {
            //         Console.Write("ㅁ");
            //     }
            // 
            //     Console.WriteLine();
            // }
        }

        // 피라미드 만들기 메서드
        static void Triangle()
        {
            // Console.Write("피라미드의 높이를 입력해주세요 : ");
            // 
            // int height = int.Parse(Console.ReadLine());  // 이런 방식은 방어코드가 없기 때문에 안좋은 코드 방식
            // 
            // Console.Write("피라미드의 가로길이를 입력해주세요 : ");
            // 
            // int width = int.Parse(Console.ReadLine());   // 이런 방식은 방어코드가 없기 때문에 안좋은 코드 방식

            Console.Write("피라미드의 높이와 가로길이를 입력해주세요 : ");

            string[] str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int height = 0;
            int width = 0;

            if (str.Length != 2 || !int.TryParse(str[0], out height) || !int.TryParse(str[1], out width))
            {
                Console.WriteLine("잘못된 입력입니다.");
            }

            for (int i = 0; i < height; i++)
            {
                int count = 0;

                for (int j = 0; j < i + 1; j++)
                {
                    count++;
                }
                Console.Write(new string('△', count));

                Console.WriteLine();
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = width; j > i; j--)
                {
                    Console.Write("ㅇ");
                }

                Console.WriteLine();
            }


            // 피라미드의 옆 넓이의 길이를 늘리고 싶다.
        }

        static void ReverseTriangle()
        {

        }
    }
}
