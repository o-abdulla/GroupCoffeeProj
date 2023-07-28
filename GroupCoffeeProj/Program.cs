// Coffee Shop Project
using TimTool;

//using file_io;

using GroupCoffeeProj;

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
bool continueOrdering=true;
List<Items> listOrdered = new List<Items>();
while (continueOrdering)
{
    Items order = Menu.Str(menu,out continueOrdering);
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
    Console.WriteLine("Please enter cash amount");
     bool goodCash = Gatekeeper.Larger(decimal.Parse(Console.ReadLine()), grandTotal);
}
else if (paymentMethod == 2)
{
    //credit
    Console.WriteLine("");
}
else if (paymentMethod == 3)
{
    //check
    Console.WriteLine("");

}

//static decimal PaymentCash(decimal payment, decimal total)
//{

//}
