using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Text
{
    internal class EncounterEvent: Event
    {
        public EncounterEvent()
        {
            eventName = "[Un grupo hostil se interpone en tu camino]";
        }

        public override void Execute(GameManager manager)
        {
            Console.WriteLine(eventName);

            // Crear enemigos
            manager.enemies = new List<Entity>()
        {
            new Goblin(),
            new Goblin()
        };

            manager.StartCombat();
        }
    }
}
