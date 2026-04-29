using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Text
{
    internal class DangerousEvent : Event
    {
        public DangerousEvent()
        {
            eventName = "[Un encuentro letal]";
        }
        public override void Execute(GameManager manager)
        {
            Console.WriteLine(eventName);
            Console.WriteLine("");
            Console.WriteLine("[Ves un troll caminando]");
            Console.WriteLine("[Escoge tu desición]");
            Console.WriteLine("[1] Emboscar");
            Console.WriteLine("[2] Tratar pasar desapercibido");

            Entity enemy;

            enemy = new Troll();

            string option = Console.ReadLine();
            
            if (option == "1")
            {
                Console.WriteLine("[Emboscaste al troll]");
                Console.WriteLine("[Lograste inflingirle 8 de daño]");
                manager.enemies = new List<Entity>();
                manager.enemies.Add(enemy);
                enemy.ReciveDamage(8);

                manager.StartCombat();
            }
            else if ( option == "2")
            {
                Console.WriteLine("[Intentaste pasar desapercibido]");
                Console.WriteLine("[El troll te noto y recbiste 5 de daño]");

                manager.enemies = new List<Entity>();
                manager.enemies.Add(enemy);

                manager.player.ReciveDamage(5);

                manager.StartCombat();
            }
        }
    }
}
