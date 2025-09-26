using System;
using System.Timers;
using System.Threading;

class Program
{
    // Delegate voor alarmacties
    delegate void AlarmAction();
    static AlarmAction OnAlarm;

    static Timer alarmTimer;
    static Timer snoozeTimer;

    static void Main(string[] args)
    {
        
        AlarmAction sound = () => Console.Beep();
        AlarmAction message = () => Console.WriteLine("!!! WAKE UP !!!");
        AlarmAction blink = () =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("BLINK!");
                Thread.Sleep(500);
            }
        };

        // Delegate starten hier leeg
        OnAlarm = null;

        int alarmTimeInSeconds = 10; 
        int snoozeTimeInSeconds = 5; 
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
                case "1":
                    Console.Write("Nieuwe alarmtijd (s): ");
                    alarmTimeInSeconds = int.Parse(Console.ReadLine());
                    break;
                case "2":
                    Console.Write("Nieuwe sluimertijd (s): ");
                    snoozeTimeInSeconds = int.Parse(Console.ReadLine());
                    break;
                case "3":
                    OnAlarm += sound;
                    Console.WriteLine("Geluid toegevoegd!");
                    break;
                case "4":
                    OnAlarm += message;
                    Console.WriteLine("Boodschap toegevoegd!");
                    break;
                case "5":
                    OnAlarm += blink;
                    Console.WriteLine("Knipperlicht toegevoegd!");
                    break;
                case "6":
                    StartAlarm(alarmTimeInSeconds);
                    Console.WriteLine("Wekker gestart!");
                    break;
                case "7":
                    StopAlarm();
                    Console.WriteLine("Wekker gestopt!");
                    break;
                case "8":
                    Snooze(snoozeTimeInSeconds);
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ongeldige keuze!");
                    break;
            }
        }
    }

    static void StartAlarm(int seconds)
    {
        alarmTimer?.Stop();
        alarmTimer = new Timer(seconds * 1000);
        alarmTimer.Elapsed += (s, e) =>
        {
            OnAlarm?.Invoke();
            alarmTimer.Stop();
        };
        alarmTimer.AutoReset = false;
        alarmTimer.Start();
    }

    static void StopAlarm()
    {
        alarmTimer?.Stop();
        snoozeTimer?.Stop();
    }
