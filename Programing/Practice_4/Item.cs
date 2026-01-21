using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Item
    {
        public int Id
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public int Quantity
        {
            get;
            protected set;
        }

        public virtual void Use(Player player)
        {
            return;
        }

        public override string ToString()
        {
            return $"{Name} x {Quantity}";
        }
    }
}
