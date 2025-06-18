using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> rustGuns = new List<string>
        {
            "Assault Rifle (AK-47)",
            "Bolt Action Rifle",
            "Custom SMG",
            "LR-300 Assault Rifle",
            "M249",
            "M39 Rifle",
            "MP5A4",
            "Pump Shotgun",
            "Python Revolver",
            "Revolver",
            "Semi-Automatic Pistol",
            "Semi-Automatic Rifle",
            "Thompson",
            "Double Barrel Shotgun",
            "Eoka Pistol",
            "M92 Pistol",
            "Nailgun",
            "SAR (Semi-Auto Rifle)",
            "Waterpipe Shotgun"
        };

        List<string> sights = new List<string>
        {
            "Iron Sights",
            "Hollow Sight",
            "Handmade Sight",
            "8x Scope"
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== RWK Loaded Successfully ===");
            for (int i = 0; i < rustGuns.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rustGuns[i]}");
            }

            Console.WriteLine("\nSelect a gun by number, or press Enter to exit:");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Exiting...");
                break;
            }

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= rustGuns.Count)
            {
                Console.WriteLine($"You selected: {rustGuns[choice - 1]}");

                Console.WriteLine("\nSelect a sight for your gun:");
                for (int i = 0; i < sights.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {sights[i]}");
                }

                string sightInput = Console.ReadLine();
                if (int.TryParse(sightInput, out int sightChoice) && sightChoice >= 1 && sightChoice <= sights.Count)
                {
                    Console.WriteLine($"You selected: {sights[sightChoice - 1]} for your {rustGuns[choice - 1]}.");
                    break; // End after a successful selection
                }
                else
                {
                    Console.WriteLine("Invalid sight selection. Returning to gun selection...");
                    Thread.Sleep(1200);
                    continue; // Go back to gun selection
                }
            }
            else
            {
                Console.WriteLine("Invalid gun selection. Returning to gun selection...");
                Thread.Sleep(1200);
                continue; // Go back to gun selection
            }
        }
    }
}
