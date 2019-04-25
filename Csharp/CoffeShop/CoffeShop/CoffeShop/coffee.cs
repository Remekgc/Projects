using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop
{
    internal class Coffee
    {
        internal string CoffeType { get; set; }
        internal float CoffePrice { get; set; }

        public static List<Coffee> CreateCoffeList()
        {
            List<Coffee> coffeeList = new List<Coffee>();

            Coffee latte = new Coffee() { CoffeType = "Latte", CoffePrice = 2.5f };
            Coffee cappuccino = new Coffee() { CoffeType = "Cappuccino", CoffePrice = 1.5f };
            Coffee americano = new Coffee() { CoffeType = "Americano", CoffePrice = 2f };
            Coffee mocha = new Coffee() { CoffeType = "Mocha", CoffePrice = 3f };
            Coffee espresso = new Coffee() { CoffeType = "Espresso", CoffePrice = 3.5f };

            coffeeList.AddRange(new Coffee[] { latte, cappuccino, americano, mocha, espresso });

            return coffeeList;
        }

        public override string ToString()
        {
            return $"{CoffeType}, price: {CoffePrice}";
        }

    }
}
