using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting coffeList
            List<Coffee> coffeeList = Coffee.CreateCoffeList();

            //Getting resourceList
            List<Resources> resourceList = Resources.CreateResourceList();

            //Customer info:
            Customer customer = Customer.CreateCustomer();
            SectionEnding();

            //Pick a coffee
            Console.WriteLine("Pick a coffee:"); //slect coffe type
            CoffeMaker.PrintCoffeeList(coffeeList);

            int coffiePick = CoffeMaker.CoffeePicker(coffeeList);

            //Pick a resource
            CoffeMaker.PrintResourceList(resourceList);
            int resourcePick = CoffeMaker.ResroucePicker(resourceList);
            
            SectionEnding();

            //Create receipt
            Receipt receipt = new Receipt(coffeeList[coffiePick], resourceList[resourcePick], coffeeList[coffiePick].CoffePrice, resourceList[resourcePick].Price, customer);
            receipt.CreateReceipt();

            //Read receipt
            FileManager.ReadFile();
            SectionEnding();

            //Preparing coffe
            CoffeMaker.PrepareCoffe();
            Console.WriteLine("Thank you for using the Coffe Machine, check your desktop for the receipt");

            Console.ReadKey();
        }

        private static void SectionEnding()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        }

    }
}