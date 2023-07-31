﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimTool;

namespace GroupCoffeeProj
{
    internal class Payment
    {
        public static void Cash(decimal grandTotal)
        {

            decimal cash = 0;
            decimal cashPaid = 0;
            while (true)
            {
                Console.Write("Please enter cash amount:  ");

                while (decimal.TryParse(Console.ReadLine(), out cash) == false)
                {
                    Console.WriteLine("Invalid entry. Please enter only numerals.");
                }

                cashPaid += cash;
                if (cashPaid > grandTotal)
                {
                    decimal change = cashPaid - grandTotal;
                    Console.WriteLine($"Amount tendered: {cashPaid:c}");
                    Console.WriteLine($"Thank you for your purchase! Your change is: {change:c}");

                    break;
                }
                else if (cash < grandTotal)
                {
                    decimal amountRemaining = grandTotal - cashPaid;
                    Console.WriteLine($"Amount paid: {cashPaid:c}");
                    Console.WriteLine($"Amount remaining: {amountRemaining:c}");
                    Console.WriteLine($"Thank you for your purchase! Please come again.");

                }
                else if (cashPaid == grandTotal)
                {
                    decimal change = cashPaid - grandTotal;
                    Console.WriteLine($"Amount tendered: {cashPaid:c}");
                    Console.WriteLine($"Change: {change:c}");
                    Console.WriteLine($"Thank you for your purchase! Please come again.");
                    break;
                }
            }
        }
        public static void Card()
        {
            bool cardValidate = false;
            while (!cardValidate)
            {
                do
                {
                    cardValidate = true;
                    Console.WriteLine("Please enter 16-digit card number. \nWe do not accept American Express.");
                    ulong cardNum = 0;
                    //16 digit card number validation
                    while (ulong.TryParse(Console.ReadLine(), out cardNum) == false || cardNum < 0 || cardNum.ToString().Length != 16)
                    {

                        if (cardNum < 0)
                        {
                            Console.WriteLine("Invalid entry. Please enter only positive numbers");
                        }
                        else
                        {
                            Console.WriteLine("Only 16 digits allowed");
                        }
                        Console.WriteLine("Please enter a 16-digit account number.");
                    }
                    //Validation for expiration date (MM/YY)


                    int numMonth = 0;
                    Console.Write("Please enter two (2) digit card expiration month (MM):  ");
                    while (int.TryParse(Console.ReadLine(), out numMonth) == false || numMonth.ToString().Length > 2 || numMonth <= 0 || numMonth > 12)
                    {
                        Console.WriteLine("Invalid entry. Please enter only positive numbers and two digit month");
                    }

                    int numYear = 0;
                    Console.Write("Please enter two (2) digit card expiration year (YY):  ");
                    while (int.TryParse(Console.ReadLine(), out numYear) == false || numYear.ToString().Length != 2 || numYear < 0)
                    {
                        Console.WriteLine("Invalid entry. Please enter only positive numbers and two digit year Please also ensure the card is still valid.");
                    }

                    //date validation
                    if (numYear < Timekeeper.GetCurrentYearAbb())
                    {
                        Console.WriteLine("Card is expired.");
                        cardValidate = false;
                    }
                    else if (numYear == Timekeeper.GetCurrentYearAbb())
                    {
                        if (numMonth < Timekeeper.GetCurrentMonth())
                        {
                            Console.WriteLine("Card is expired.");
                            cardValidate = false;
                        }
                    }
                } while (!cardValidate);
                Console.Write("Enter your 3 digit CVV code:  ");
                int cvv = 0;
                while (int.TryParse(1 + Console.ReadLine(), out cvv) == false || cvv.ToString().Substring(1).Length != 3 || cvv < 0)
                {
                    Console.WriteLine("Invalid entry. Please enter a positive 3 digit number");
                }
                string cvvStr = cvv.ToString().Substring(1);

            }

        }


    }
}
