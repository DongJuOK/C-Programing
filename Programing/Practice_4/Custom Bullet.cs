using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Custom_Bullet : Item
    {
        public Custom_Bullet(int quantity)
        {
            Id = 2;
            Name = "특수 총알";
            Quantity = quantity;
        }

        public override void Use(Player player)
        {
            // 총알 데미지 3배
            Console.WriteLine("총알의 데미지가 3배 증가하였습니다.");
            Quantity--;
        }
    }
}
