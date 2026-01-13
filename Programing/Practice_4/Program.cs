using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                string[] nums = Console.ReadLine().Split();

                for (int j = 0; j < nums.Length; j++)
                {
                    list.Add(int.Parse(nums[j]));
                    sum += list[j];
                }

                result.AppendLine(sum.ToString());
            }

            Console.WriteLine(result.ToString());
        }
    }
}

/*

숫자 맞추기 업다운

1. 컴퓨터가 랜덤한 숫자 하나를 가지고 있어야 한다.

2. 플레이어는 숫자를 입력한다.
- 문자가 입력됐을때도 프로그램이 터지면 안된다.

3. 플레아어가 입력한 숫자가 크거나 작으면
   업이나 다운으로 플레이어에게 알려줘야한다.

4. 플레이어가 숫자를 맞출 때 까지

5. 결론이 나오면 몇번만에 count 됐는지

6. 난이도가 쉬움이면 - 횟수제한 없고, 숫자 범위도 작게

   난이도에 따라 횟수제한이 생긴다.

   숫자 범위가 커진다.

7. 리팩토링 -
   좀 더 알아보기 쉽게
   메서드화
   클래스도 적용

1. 가위바위보

 - 본인이 스스로 설계

 */
