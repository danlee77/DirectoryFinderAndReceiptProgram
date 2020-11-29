using System;
using System.Collections.Generic;

namespace Sales_Receipts
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfCogs;
            int numberOfGears;
            int customerID;

            List<Receipt> customerReceipts = new List<Receipt>();

            Console.WriteLine("Hello Sales Associate!");


            //Data Entry
            string repeatEntry = "Y";
            do {

                Console.Write("\nEnter # of cogs: ");
                numberOfCogs = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter # of gears: ");
                numberOfGears = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Customer ID: ");
                customerID = Convert.ToInt32(Console.ReadLine());

                Receipt rec = new Receipt(customerID, numberOfCogs, numberOfGears);

                Console.Write("\n");
                rec.PrintReceipt();
                customerReceipts.Add(rec);

                Console.Write("\nAnother order entry (Y/N)?: ");
                repeatEntry = Console.ReadLine().ToUpper();


            } while (repeatEntry == "Y");


            //Receipt Printing
            string repeatPrint = "Y";
            do { 

                Console.WriteLine("------------------------");
                Console.WriteLine("1 - Based on Customer ID\n2 - Print all receipts\n3 - Print receipt with highest total");
                Console.Write("\nEnter print receipt option: ");
                string option = Console.ReadLine();

                Console.Write("\n");

                if (option == "1")
                {
                    Console.Write("Enter Customer ID: ");
                    int receiptCustomerID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");

                    foreach (var receipt in customerReceipts)
                    {
                        if (receiptCustomerID == receipt.CustomerID)
                        {
                            receipt.PrintReceipt();
                            Console.Write("\n");
                        }
                    
                    }
                }
                else if (option == "2")
                {
                    foreach (var receipt in customerReceipts)
                    {
                        receipt.PrintReceipt();
                        Console.Write("\n");
                    }
                }
                else if (option == "3")
                {
                    foreach (var receipt in customerReceipts)
                    {
                        double temp = receipt.CalculateTotal();
                        foreach (var receipt2 in customerReceipts)
                        {
                            if (receipt2.CalculateTotal() > temp)
                            {
                                temp = receipt2.CalculateTotal();
                                
                            }
                        }

                        if (receipt.CalculateTotal() == temp)
                        {
                            receipt.PrintReceipt();
                            Console.Write("\n");
                            break;
                        }
                        
                    }
                }

                Console.Write("Another receipt print (Y/N)?: ");
                repeatPrint = Console.ReadLine().ToUpper();

            } while (repeatPrint == "Y");


            Console.WriteLine("\nThank you Sales Associate!");
            
            Console.ReadKey();
        }
    }
}
