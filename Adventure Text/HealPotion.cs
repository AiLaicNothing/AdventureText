using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adventure_Text
{
    internal class HealPotion: Item
    {
        int heal = 15;

        public HealPotion()
        {
            name = "Poción de cura";
            description = $"Cura {heal} de vida";
        }

        protected override void Fuction(Entity target)
        {
            target.Heal(heal);
        }
    }
}
