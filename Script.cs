using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    // Import mouse_event from user32.dll
    [DllImport("user32.dll", SetLastError = true)]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

    const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    const uint MOUSEEVENTF_LEFTUP = 0x0004;

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
            "Holo Sight",
            "Handmade Sight",
            "8x Scope"
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("AC Bypass Status (DEBUG) : Uknown");
            Console.WriteLine("=== RWK Loaded Successfully ===");
            Console.WriteLine("Select a gun from the list below:");
            Console.WriteLine("================================");
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

                    // Example: If AK-47 and Holo Sight are selected, simulate a left mouse click
                    if (rustGuns[choice - 1] == "Assault Rifle (AK-47)" && sights[sightChoice - 1] == "Holo Sight")
                    {
                        Console.WriteLine("Special combo detected! Simulating left mouse click...");
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                        Thread.Sleep(50);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                    }

                    break; // End after a successful selection
                }
                else
                {
                    Console.WriteLine("Invalid sight selection. Returning to gun selection...");
                    Thread.Sleep(1200);
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Invalid gun selection. Returning to gun selection...");
                Thread.Sleep(1200);
                continue;
            }
        }
    }
}
