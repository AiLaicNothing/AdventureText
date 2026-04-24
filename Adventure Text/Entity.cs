using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Text
{
    internal abstract class Entity
    {
        protected string name;
        protected int health;
        protected int damage;
        public string Name
        {
            get { return name; }
        }
        public int Health
        {
            get { return health; }
        }

        public int Damage
        {
            get { return damage; }
        }

        public void ReciveDamage(int ammount)
        {
            health -= ammount;
        }
        public void Heal(int ammount)
        {
            health += ammount;
        }
    }
}

