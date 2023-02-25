using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        { /*
            MaxHeap<int> heap1 = new MaxHeap<int>();

            heap1.Add(4);
            heap1.Add(3);
            heap1.Add(2);
            heap1.Add(1);
            heap1.Add(0);
            Console.WriteLine(heap1.Count);

            Console.WriteLine(heap1.ExtractMax());
            */
            // Set up variables
            int cookingTime = 0;
            int flipTime = 0;
            int targetTemperature = 375;
            int currentTemperature = 70;
            bool isCooked = false;

            // Begin cooking process
            Console.WriteLine("Starting to cook pork rinds.");

            while (!isCooked)
            {
                // Check if pork rinds are done cooking
                if (cookingTime >= 15 && currentTemperature >= targetTemperature)
                {
                    Console.WriteLine("Pork rinds are cooked!");
                    isCooked = true;
                }
                else
                {
                    // Cook pork rinds for another minute
                    cookingTime++;
                    currentTemperature += 10;

                    // Check if it's time to flip the pork rinds
                    if (cookingTime == 8)
                    {
                        Console.WriteLine("Time to flip the pork rinds.");
                        flipTime = cookingTime;
                    }

                    // Print current status of pork rinds
                    Console.WriteLine($"Cooking time: {cookingTime} minute(s), Temperature: {currentTemperature} degrees Fahrenheit");

                    // Check if it's time to lower the temperature
                    if (flipTime > 0 && cookingTime - flipTime == 5)
                    {
                        Console.WriteLine("Lowering the temperature.");
                        currentTemperature = 250;
                    }

                }
            }
        }
    }
}

