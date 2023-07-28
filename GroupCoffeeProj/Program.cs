// Coffee Shop Project
using TimTool;

//using file_io;

using GroupCoffeeProj;
using System.Runtime.CompilerServices;
using System.Security.Principal;

string filePath = "../../../CoffeeShop.txt";
//Name, Category, Description, Price)
if (File.Exists(filePath) == false)
{
    StreamWriter tempWriter = new StreamWriter(filePath);
    tempWriter.WriteLine("Black Coffee| | | 5.00");
    tempWriter.WriteLine("Donut | hole| chocolate");
    tempWriter.Close();
}

StreamReader reader = new StreamReader(filePath);
List<Items> menu = new List<Items>();
//Populating list menu 
while (true)
{
    //Name, Category, Description, Price,Cream, Sugar, Hot)
    string line = reader.ReadLine();
    if (line == "pleaseStop")
    {
        break;
    }
    else
    {
        //Name, Category, Description, Price,Cream, Sugar, Hot)
        string[] parts = line.Split("|");

        if (parts.Length == 7)
        {
            Beverages b = new Beverages(parts[0], parts[1], parts[2], decimal.Parse(parts[3]), parts[4], bool.Parse(parts[5]), bool.Parse(parts[6]));
            menu.Add(b);
        }
        else if (parts.Length == 4)
        {
            Food f = new Food(parts[0], parts[1], parts[2], decimal.Parse(parts[3]));

            menu.Add(f);

        }
    }
}
reader.Close();


//Displaying list select by number. 
bool continueOrdering = true;
List<Items> listOrdered = new List<Items>();
while (continueOrdering)
{
    Items order = Menu.Str(menu, out continueOrdering);
    if (order != null)
    {
        Console.Write($"How many {order.Name.ToString().Trim()}'s\n" +
            $"would you like ");
        int amount = Gatekeeper.GetPositiveInputInt();
        for (int i = 1; i <= amount; i++)
        {
            listOrdered.Add(order);
        }

        continueOrdering = Gatekeeper.GetContinue();
    }
}

//calculating subtotal (sum of items * price )
decimal subTotal = 0;
decimal salesTaxRate = 0.06m;


foreach (Items i in listOrdered)
{
    subTotal += i.Price;
}
decimal salesTaxTotal = subTotal * salesTaxRate;
decimal grandTotal = subTotal + salesTaxTotal;
//Ethan's simplifed linq  method
//use .Select and .Distinct to pull fiirst unique instances of objects in list by Name, and make a list of them called "receipt"
//List<Items> receipt = listOrdered.Select(i => i.Name).Distinct().ToList();
////print out list with for loop
//for (int i = 0; i < receipt.Count(); i++)
//{
//    Console.WriteLine($"{i}. {receipt[i].Name}");
//}

//use count method to get quantity
//int adultCount = ages.Count(p => p >= 21);

//plain readout of every individual selection (works but is long
foreach (Items i in listOrdered)
{
    Console.WriteLine($"{i.Name} {i.Price}");
}

Console.WriteLine($"Subtotal: {subTotal:c}");
Console.WriteLine($"Sales Tax: {subTotal * salesTaxRate:c}");
Console.WriteLine($"Grand Total: {subTotal + salesTaxTotal:c}");


Console.WriteLine("How would you like to pay - cash, credit, check");

List<string> payment = new List<string>()
{
    "cash",
    "credit",
    "check"
};

int paymentMethod = Menu.Int(payment);
if (paymentMethod == 1)
{
    //cash
    decimal cash = 0;
    decimal cashPaid = 0;
    while (true)
    {
        Console.WriteLine("Please enter cash amount:");

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
else if (paymentMethod == 2)
{
    //credit
    Console.WriteLine("");
}
else if (paymentMethod == 3)
{
    //check
    //Validation for 8 digit entry
    Console.WriteLine("Please enter routing number");
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
    Console.WriteLine("Please enter account number");
    //Validation for 8-17 digit entry
    ulong accountNum = 0;
    while (ulong.TryParse(Console.ReadLine(), out accountNum) == false || accountNum < 0 || accountNum.ToString().Length < 8 || accountNum.ToString().Length > 17)
    {
        Console.WriteLine("Error. Please enter an account number between 8 - 17 digits.");
    }


    Console.WriteLine("Please enter check number. NO FUNNY BUSINESS OK");
    //Validation for 1-4 digits
    int checkNum = 0;
    while (int.TryParse(Console.ReadLine(), out checkNum) == false || checkNum < 0 || checkNum.ToString().Length < 1 || checkNum.ToString().Length > 4)
    {
        Console.WriteLine("Invalid entry. Please enter only numerals.");
    }
   
    Console.WriteLine("Your check has cleared.");



}


//static decimal PaymentCash(decimal payment, decimal total)
//{

//}
