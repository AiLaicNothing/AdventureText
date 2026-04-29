using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adventure_Text
{
    internal class GameManager
    {
        // --> Related to Player
        public Entity player;
        public List<Item> itemInventory;

        public List<Entity> enemies;

        public List<Event> events;
        private int eventsCompleted = 0;
        private int maxEvents = 10;
        private Random rand = new Random();

        public void StartGame()
        {
            itemInventory = new List<Item>();
            InitializeEvents();

            CreateCharacter();

            GameLoop();
        }

        public void CreateCharacter()
        {
            Console.WriteLine("Introduce tu nombre");
            string playerName = Console.ReadLine();

            player = new Player(playerName);
            Console.WriteLine($"Tu personaje se llama {player.Name} tiene {player.Health} de vida");
        }

        public void InitializeEvents()
        {
            events = new List<Event>()
    {
        new EncounterEvent(),
        new DangerousEvent(),
        new ThreePathEventcs(),
        new LuckyEvent()
    };
        }

        private void GameLoop()
        {
            while (player.Health > 0 && eventsCompleted < maxEvents)
            {
                Console.Clear();

                Event e = events[rand.Next(events.Count)];

                e.Execute(this);

                eventsCompleted++;

                Wait();
            }

            EndGame();
        }

        public void StartCombat()
        {
            Console.Clear();
            Console.WriteLine($"{player.Name} se a encontrado con un grupo de enemigos.");
            Console.WriteLine($"{player.Name} entra en combate.");

            CombatLoop();
        }

        public void CombatLoop()
        {
            while (player.Health > 0 && enemies.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("=== TURNO DEL JUGADOR ===\n");

                PlayerTurn();
                Wait();

                if (enemies.Count <= 0) break;

                Console.Clear();
                Console.WriteLine("=== TURNO DEL ENEMIGO ===\n");

                EnemyTurn();
                Wait();
            }

            Console.Clear();

            if (player.Health > 0)
            {
                Console.WriteLine("GANASTE");
            }
            else
            {
                Console.WriteLine("PERDISTE");
            }

            Wait();
        }

        public void PlayerTurn()
        {
            Console.WriteLine($"Jugador: {player.Name} - Vida: {player.Health}");

            Console.WriteLine($"Enemigos encontrados");

            //Enseña una descripcion de los enemigos que hay
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine($"{enemies[i].Name} tiene {enemies[i].Health} de vida");
            }

            Console.WriteLine("[Escoge una acción]");
            Console.WriteLine("[1] Atacar");
            Console.WriteLine("[2] Usar item");

            string option = Console.ReadLine();

            if (option == "1")
            {
                //Enseña las opciones de enemigo
                for (int i = 0; i < enemies.Count; i++)
                {
                    Console.WriteLine($"[{i}] {enemies[i].Name} - {enemies[i].Health}");
                }

                //Atacar enemigo seleccionado

                string enemySelected = Console.ReadLine();
                int index = int.Parse(enemySelected);

                Entity enemy = enemies[index];

                enemy.ReciveDamage(player.Damage);

                Console.WriteLine($"{player.Name} atacó a {enemy.Name} por {player.Damage} de daño");

                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} murió");
                    DropItem();
                    enemies.RemoveAt(index);
                }
            }
            else if (option == "2")
            {
                if (itemInventory.Count == 0)
                {
                    Console.WriteLine("No tienes items");
                    return;
                }

                Console.WriteLine("Inventario:");

                for (int i = 0; i < itemInventory.Count; i++)
                {
                    Console.WriteLine($"[{i}] {itemInventory[i].Name}");
                }

                int itemIndex = int.Parse(Console.ReadLine());
                Item selectedItem = itemInventory[itemIndex];

                Console.WriteLine("¿A quién usar?");
                Console.WriteLine("[0] Tú");

                for (int i = 0; i < enemies.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {enemies[i].Name}");
                }

                int targetIndex = int.Parse(Console.ReadLine());

                Entity target;

                if (targetIndex == 0)
                    target = player;
                else
                    target = enemies[targetIndex - 1];

                selectedItem.Use(target);

                itemInventory.RemoveAt(itemIndex);
            }

        }
        }

        public void EnemyTurn()
        {
            int index = rand.Next(enemies.Count);

            Entity enemy = enemies[index];

            player.ReciveDamage(enemy.Damage);

            Console.WriteLine($"{enemy.Name} te atacó por {enemy.Damage}");
        }

        public void DropItem()
        {
            Console.WriteLine("El enemigo dejó una poción (+10 vida)");
            player.Heal(10);
        }

        public void Wait()
        {
            Console.WriteLine("Presiona ENTER para continuar...");
            Console.ReadLine();
        }

        private void EndGame()
        {
            Console.Clear();
            Console.WriteLine("=== FINAL ===");

            if (player.Health <= 0)
            {
                Console.WriteLine("Final Malo: Has muerto en la aventura.");
            }
            else if (player.Health < 10)
            {
                Console.WriteLine("Final Neutral: Sobreviviste... apenas.");
            }
            else
            {
                Console.WriteLine("Final Bueno: Saliste victorioso y fuerte.");
            }
        }
    }

}

