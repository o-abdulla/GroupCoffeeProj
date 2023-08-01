using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimTool;

namespace GroupCoffeeProj
{
    internal class Payment
    {
        public static decimal Cash(decimal grandTotal)
        {

            decimal cash = 0;
            decimal cashPaid = 0;
            decimal amountRemaining=0;
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
                    Console.WriteLine($"Your change is: {change:c}");
                    return change;

                    
                }
                else if (cash < grandTotal)
                {
                    amountRemaining = grandTotal - cashPaid;
                    Console.WriteLine($"Amount paid: {cashPaid:c}");
                    Console.WriteLine($"Amount remaining: {amountRemaining:c}");
                    Console.WriteLine($"Please enter remaining payment");
                   

                }
                else if (cashPaid == grandTotal)
                {
                    decimal change = cashPaid - grandTotal;
                    Console.WriteLine($"Amount tendered: {cashPaid:c}");
                    Console.WriteLine($"Change: {change:c}");
                    return 0;
                    
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
            Console.WriteLine("Card Accepted! Thank you, please come again.");

        }

        public static void Check()
        {
            Console.WriteLine("Please enter routing number:");
            int routingNum = 0;
            //check if numbers with TryParse
            //then if TryParse check passes, convert to String, measure String length
            //check if String length == 8
            //****
            //Routing number 

            while (int.TryParse(Console.ReadLine(), out routingNum) == false || routingNum < 0 || routingNum.ToString().Length != 8)
            {
                if (routingNum == 0)
                {
                    Console.WriteLine("Only numbers please.");
                }
                else if (routingNum < 0)
                {
                    Console.WriteLine("Invalid entry. Only positive numbers");
                }
                else
                {
                    Console.WriteLine("Only 8 digits allowed");
                }
                Console.WriteLine("Please enter a correct routing number");
            }


            //Account number 
            Console.WriteLine("Please enter account number:");
            //Validation for 8-17 digit entry
            ulong accountNum = 0;
            while (ulong.TryParse(Console.ReadLine(), out accountNum) == false || accountNum < 0 || accountNum.ToString().Length < 8 || accountNum.ToString().Length > 17)
            {
                Console.WriteLine("Error. Please enter an account number between 8 - 17 digits.");
            }


            Console.WriteLine("Please enter check number. No funny business, OK.");
            //Validation for 1-4 digits
            int checkNum = 0;
            while (int.TryParse(Console.ReadLine(), out checkNum) == false || checkNum < 0 || checkNum.ToString().Length < 1 || checkNum.ToString().Length > 4)
            {
                Console.WriteLine("Invalid entry. Please enter only numerals.");
            }
            Console.WriteLine("Check entry successful.");
        }

    }
}
