using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Potion : Item
    {
        public Potion(int quantity)
        {
            Id = 1;
            Name = "포션";
            Quantity = quantity;
        }

        public override void Use(Player player)
        {
            player.Heal(3);
            Console.WriteLine($"{player.Name}의 체력이 3 회복되었습니다.");
        }
    }
}
