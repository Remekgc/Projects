using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop
{
    internal class Customer
    {
        internal string name;
        internal int cardNumber;

        public override string ToString()
        {
            return $"{name}, card number: {cardNumber}";
        }

        public static Customer CreateCustomer()
        {
            Customer customer = new Customer();

            Console.WriteLine("Eneter customer info");
            Console.Write("Name: ");
            customer.name = Console.ReadLine();

            Console.Write("Card Number: ");
            ValidateCard(customer);
            return customer;
        }

        private static void ValidateCard(Customer customer)
        {
            bool checkCard = int.TryParse(Console.ReadLine(), out customer.cardNumber);

            while (!checkCard)
            {
                Console.WriteLine("Invalid card number");
                Console.Write("Please re-enter your Card Number: ");
                checkCard = int.TryParse(Console.ReadLine(), out customer.cardNumber);
            }
        }
    }
}
