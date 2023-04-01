using standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LightBulb
{
    public class P1
    {
        static void Main()
        {
            // Create an array of Lumen objects
            Lumen[] lumens = new Lumen[]
            {
            new Lumen(10, 2, 50, 10, 5, 4),
            new Lumen(8, 3, 40, 15, 4, 3),
            new Lumen(6, 4, 30, 20, 3, 2),
            new Lumen(4, 5, 20, 25, 2, 1),
            new Lumen(2, 6, 10, 30, 1, 1)
            };

            Console.WriteLine("Initial Glow:");

            // Display initial glow for all Lumen objects
            for (int i = 0; i < lumens.Length; i++)
            {
                Console.WriteLine($"Lumen {i + 1}: {lumens[i].glow()}");
            }

            Console.WriteLine("\nGlow after some requests:");

            // Perform some glow requests
            for (int i = 0; i < lumens.Length; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    lumens[i].glow();
                }
            }

            // Display glow after some requests for all Lumen objects
            for (int i = 0; i < lumens.Length; i++)
            {
                Console.WriteLine($"Lumen {i + 1}: {lumens[i].glow()}");
            }

            Console.WriteLine("\nGlow after reset attempts:");

            // Attempt to reset all Lumen objects
            for (int i = 0; i < lumens.Length; i++)
            {
                lumens[i].reset();
            }

            // Display glow after reset attempts for all Lumen objects
            for (int i = 0; i < lumens.Length; i++)
            {
                Console.WriteLine($"Lumen {i + 1}: {lumens[i].glow()}");
            }
        }
    }
}
