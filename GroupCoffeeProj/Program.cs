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
        Console.Write($"Excellent choice. How many {order.Name.ToString().Trim()}s would you like?  ");
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

//use count method to get quantity
//int adultCount = ages.Count(p => p >= 21);
//plain readout of every individual selection (works but is long)
foreach (Items i in listOrdered)
{
    Console.WriteLine($"{i.Name} {i.Price}");
}

Console.WriteLine($"Subtotal: {subTotal:c}");
Console.WriteLine($"Sales Tax: {subTotal * salesTaxRate:c}");
Console.WriteLine($"Grand Total: {subTotal + salesTaxTotal:c}");


Console.WriteLine("How would you like to pay today: cash, card, or check?");

List<string> payment = new List<string>()
{
    "Cash",
    "Credit",
    "Check"
};
//1. Cash Payment
int paymentMethod = Menu.Int(payment);
if (paymentMethod == 1)
{
    Payment.Cash(grandTotal);
    
}
//2. Card payment
else if (paymentMethod == 2)
{
    Payment.Card();
}
//3. Check Payment
else if (paymentMethod == 3)
{

    //Validation for 8 digit entry
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