using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop
{
    class Receipt
    {
        private Coffee CoffePick { get; set; }
        private Resources ResourcePick { get; set; }
        private float CoffiePrice { get; set; }
        private float ResourcePrice { get; set; }
        private float TotalPrice { get; set; }
        private Customer CustomerInfo { get; set; }

        public Receipt(Coffee coffe, Resources resource, float coffprice, float resourPrice, Customer customer)
        {
            CoffePick = coffe;
            ResourcePick = resource;
            CoffiePrice = coffprice;
            ResourcePrice = resourPrice;
            CustomerInfo = customer;
        }

        public void CreateReceipt()
        {
            CalculateReceipt();
            string receipt = $"Coffe Machine \nReceipt \nItem purchased:{CoffePick} with {ResourcePick} \nTotal price: {TotalPrice} \nCustomer info: {CustomerInfo}";
            FileManager.CreateFile(receipt);
        }

        private void CalculateReceipt()
        {
            TotalPrice = CoffiePrice + ResourcePrice;
        }
    }
}
