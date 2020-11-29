using System;
using System.Collections.Generic;
using System.Text;

namespace Sales_Receipts
{
    class Receipt
    {

        public int CustomerID { get; set; }

        public int CogQuantity { get; set; }

        public int GearQuantity { get; set; }

        public DateTime SaleDate { get; set; }

        private double SalesTaxPercent = 0.089;

        private double CogPrice = 79.99;

        private double GearPrice = 250.00;

        public Receipt()
        {
            CustomerID = -1;
            CogQuantity = 0;
            GearQuantity = 0;
            SaleDate = DateTime.Now;

        }

        public Receipt(int id, int cog, int gear)
        {
            CustomerID = id;
            CogQuantity = cog;
            GearQuantity = gear;
            SaleDate = DateTime.Now;
        }

        public double CalculateTotal()
        {
            double total = CalculateNetAmount() + CalculateTaxAmount();
            return total;
        }

        public void PrintReceipt()
        {
            Console.WriteLine($"\tSale Date: {SaleDate}");
            Console.WriteLine($"\tCustomer ID: {CustomerID}");
            Console.WriteLine($"\t# of Cogs: {CogQuantity}");
            Console.WriteLine($"\t# of Gears: {GearQuantity}");
            Console.WriteLine($"\tNet Amount: {CalculateNetAmount().ToString("C")}");
            Console.WriteLine($"\tTax Amount: {CalculateTaxAmount().ToString("C")}");
            Console.WriteLine($"\tTotal: {CalculateTotal().ToString("C")}");
        }

        private double CalculateTaxAmount()
        {
            double taxAmount = CalculateNetAmount() * SalesTaxPercent;
            return taxAmount;
        }

        private double CalculateNetAmount()
        {
            double netAmount;

            double cogMarkupPrice;
            double gearMarkupPrice;

            if (CogQuantity > 10 || GearQuantity > 10)
            {
                cogMarkupPrice = CogPrice + (CogPrice * 0.125);
                gearMarkupPrice = GearPrice + (GearPrice * 0.125);
            }
            else if ((CogQuantity + GearQuantity) >= 16)
            {
                cogMarkupPrice = CogPrice + (CogPrice * 0.125);
                gearMarkupPrice = GearPrice + (GearPrice * 0.125);
            }
            else
            {
                cogMarkupPrice = CogPrice + (CogPrice * 0.15);
                gearMarkupPrice = GearPrice + (GearPrice * 0.15);
            }

            netAmount = (CogQuantity * cogMarkupPrice) + (GearQuantity * gearMarkupPrice);

            return netAmount;
        }

    }
}
