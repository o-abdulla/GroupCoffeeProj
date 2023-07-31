using System;
namespace GroupCoffeeProj
{
	internal class Receipt
	{
		public static decimal PrintReceipt(List<Items>listOrdered)
		{
            //calculating subtotal (sum of items * price )
            decimal subTotal = 0;
            decimal salesTaxRate = 0.06m;

            foreach (Items i in listOrdered)
            {
                subTotal += i.Price;
            }
            decimal salesTaxTotal = subTotal * salesTaxRate;
            decimal grandTotal = subTotal + salesTaxTotal;

            //use count method to get quantity
            //int adultCount = ages.Count(p => p >= 21);
            //plain readout of every individual selection (works but is long)
            foreach (Items i in listOrdered)
            {
                Console.WriteLine("{0,15} {1,6:c}",i.Name , i.Price);
            }

            //Display readout of subtotal, sales tax, and grand total
            Console.WriteLine(String.Format("{0,15} {1,6:c}","Subtotal: ",subTotal));
            Console.WriteLine(String.Format("{0,15} {1,6:c}","Sales Tax: ",(salesTaxTotal)));
            Console.WriteLine(String.Format("{0,15} {1,6:c}", "Grand Total: ",(grandTotal)));
            Console.WriteLine("\n\n\n");
            return grandTotal;

            
        }
    }
}

