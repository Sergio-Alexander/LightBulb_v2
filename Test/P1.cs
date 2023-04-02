using System;
using standard;

namespace LightBulb
{
    public class P1
    {
        static void Main()
        {
            Lumen[] lumens = InitializeLumenObjects();

            Console.WriteLine("Initial Glow:");
            DisplayGlows(lumens);

            Console.WriteLine("\nGlow after some requests:");
            PerformGlowRequests(lumens);
            DisplayGlows(lumens);

            Console.WriteLine("\nGlow after reset attempts:");
            AttemptResets(lumens);
            DisplayGlows(lumens);
        }

        static Lumen[] InitializeLumenObjects()
        {
            Console.WriteLine("Enter the number of Lumen objects:");
            int numOfLumens = int.Parse(Console.ReadLine());

            Lumen[] lumens = new Lumen[numOfLumens];

            for (int i = 0; i < numOfLumens; i++)
            {
                Console.WriteLine($"Enter brightness, size, and power for Lumen {i + 1}:");
                int brightness = int.Parse(Console.ReadLine());
                int size = int.Parse(Console.ReadLine());
                int power = int.Parse(Console.ReadLine());

                lumens[i] = new Lumen(brightness, size, power, 10, 5, 4);
            }

            return lumens;
        }

        static void DisplayGlows(Lumen[] lumens)
        {
            for (int i = 0; i < lumens.Length; i++)
            {
                Console.WriteLine($"Lumen {i + 1}: {lumens[i].glow()}");
            }
        }

        static void PerformGlowRequests(Lumen[] lumens)
        {
            for (int i = 0; i < lumens.Length; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    lumens[i].glow();
                }
            }
        }

        static void AttemptResets(Lumen[] lumens)
        {
            for (int i = 0; i < lumens.Length; i++)
            {
                lumens[i].reset();
            }
        }
    }
}
