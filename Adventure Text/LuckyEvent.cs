using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Text
{
    internal class LuckyEvent : Event
    {
        private Random rand = new Random();

        public LuckyEvent()
        {
            eventName = "[Encontraste un objeto peculiar]";
        }

        public override void Execute(GameManager manager)
        {
            Console.WriteLine(eventName);
            Console.WriteLine("");
            Console.WriteLine("[Escoge tu desición]");
            Console.WriteLine("[1] Tomarlo");
            Console.WriteLine("[2] Ignorarlo");

            string option = Console.ReadLine();

            if (option == "1")
            {
                int roll = rand.Next(0, 2);

                Item item;

                if (roll == 0)
                {
                    item = new HealPotion();
                }
                else
                {
                    item = new FirePotion();
                }

                manager.itemInventory.Add(item);

                Console.WriteLine($"Has obtenido: {item.Name}");
            }
            else
            {
                Console.WriteLine("[Desides ignorarlo]");
            }
        }
    }
}
