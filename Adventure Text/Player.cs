using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Text
{
    internal class Player: Entity
    {
        public Player(string name)
        {
            this.name = name;
            health = 20;
            damage = 5;
        }
    }
}

