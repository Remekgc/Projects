using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop
{
    internal class Resources
    {
        internal string Name { get; set; }
        internal float Price { get; set; }

        public static List<Resources> CreateResourceList()
        {
            List<Resources> resourceList = new List<Resources>();

            Resources milk = new Resources() { Name = "Milk", Price = 0.5f };
            Resources whiteSugar = new Resources() { Name = "White sugar", Price = 0f };
            Resources brownSugar = new Resources() { Name = "Brown sugar", Price = 0f };
            Resources chocolate = new Resources() { Name = "Chocolate", Price = 0.5f };
            Resources x = new Resources() { Name = "x", Price = 0f };

            resourceList.AddRange(new Resources[] { milk, whiteSugar, brownSugar, chocolate, x });
            return resourceList;
        }

        public override string ToString()
        {
            return $"{Name}, price: {Price}";
        }

    }
}
