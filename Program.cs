using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
           
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
