using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoffeShop
{
    class CoffeMaker
    {
        public static string coffeCup = "";

        public static void PrepareCoffe()
        {
            System.Diagnostics.Process.Start(@"Images\Americano.jpg");
        }

        public static void PrintCoffeeList(List<Coffee> coffeeList)
        {
            for (int i = 0; i < coffeeList.Count; i++)
            {
                Console.WriteLine($"nr.{i}: {coffeeList[i]}");
            }
        }

        public static int CoffeePicker(List<Coffee> coffeeList)
        {
            bool checkCoffie = int.TryParse(Console.ReadLine(), out int coffiePick);

            while (!checkCoffie || !Enumerable.Range(0, coffeeList.Count).Contains(coffiePick))
            {
                Console.WriteLine("Invalid choice, try again: ");
                checkCoffie = int.TryParse(Console.ReadLine(), out coffiePick);
            }

            return coffiePick;
        }

        public static void PrintResourceList(List<Resources> resourceList)
        {
            for (int i = 0; i < resourceList.Count; i++)
            {
                Console.WriteLine($"nr.{i}: {resourceList[i]}");
            }
        }

        public static int ResroucePicker(List<Resources> resourceList)
        {
            bool checkResource = int.TryParse(Console.ReadLine(), out int resourcePick);

            while (!checkResource || !Enumerable.Range(0, resourceList.Count).Contains(resourcePick))
            {
                Console.WriteLine("Invalid choice, try again: ");
                checkResource = int.TryParse(Console.ReadLine(), out resourcePick);
            }

            return resourcePick;
        }
    }
}
