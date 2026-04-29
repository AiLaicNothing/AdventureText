using System;

public class Class1
{
	public ThreePathEventcs()
	{

        public ThreePathEventcs()
    {
        eventName = "[Encuentras tres caminos]";
    }

    public override void Execute(GameManager manager)
    {
        Console.WriteLine(eventName);
        Console.WriteLine("");
        Console.WriteLine("[Escoge tu desición]");
        Console.WriteLine("[1] Camino de espinas");
        Console.WriteLine("[2] Caída de altura desconocida");
        Console.WriteLine("[3] Camino [Normal]");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine("[Cruzas el camino con espinas]");
            Console.WriteLine("[Te cuerpo es cortado]");
            Console.WriteLine("[Recibes 6 de daño]");
            manager.player.ReciveDamage(6);

            Console.WriteLine("[Al final encuentras objetos]");
            Console.WriteLine("[1x Poción de cura]");
            Console.WriteLine("[1x Poción de fuego]");

            manager.itemInventory.Add(new HealPotion());
            manager.itemInventory.Add(new FirePotion());
        }
        else if (choice == "2")
        {
            Console.WriteLine("[La caída no fue tan alta]");
            Console.WriteLine("[Continuas tu camino con normalidad]");
        }
        else if (choice == "3")
        {
            Console.WriteLine("[Tomas el camino [Normal] ]");
            Console.WriteLine("[Era una trampa, fuiste emboscado]");

            manager.enemies = new List<Entity>();
            manager.enemies.Add(new Goblin());
            manager.enemies.Add(new Troll());

            manager.StartCombat();

        }
    }

}
