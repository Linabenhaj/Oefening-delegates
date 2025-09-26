using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {

            Console.WriteLine("\n--- WEKKER MENU ---");
            Console.WriteLine("1. Stel alarmtijd in (seconden)");
            Console.WriteLine("2. Stel sluimertijd in (seconden)");
            Console.WriteLine("3. Voeg geluid toe");
            Console.WriteLine("4. Voeg boodschap toe");
            Console.WriteLine("5. Voeg knipperlicht toe");
            Console.WriteLine("6. Start wekker");
            Console.WriteLine("7. Stop wekker");
            Console.WriteLine("8. Sluimer");
            Console.WriteLine("0. Afsluiten");
            Console.Write("Kies optie: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Functie nog niet geïmplementeerd.");
                    break;
            }
        }
    }
}
