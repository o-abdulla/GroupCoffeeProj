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

decimal total = 0;
foreach (Items i in listOrdered)
{
    total += i.Price;
}
foreach (Items i in listOrdered)
{
    Console.WriteLine($"{i.Name} {i.Price}");
}

Console.WriteLine(total);




