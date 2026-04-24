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

        public void StartGame()
        {

        }

        public void CreateCharacter()
        {
            Console.WriteLine("Introduce tu nombre");
            string playerName = Console.ReadLine();

            player = new Player(playerName);
            Console.WriteLine($"Tu personaje se llama {player.Name} tiene {player.Health} de vida");
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

            if( option == "1")
            {
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
                else if( option == "2")
                {
                    //Show items 
                    //make a foreach item in itemInventory show with a [X] number of option
                    //tell the player to write respective number to use item;

                    //Give a options to choose to who use first option player, rest enemies
                }
 
            }
        }

        public void EnemyTurn()
        {
            Random rand = new Random();
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
    }

}

