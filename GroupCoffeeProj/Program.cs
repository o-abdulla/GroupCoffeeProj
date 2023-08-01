// Coffee Shop Project
using TimTool;

//using file_io;

using GroupCoffeeProj;
using System.Runtime.CompilerServices;
using System.Security.Principal;

//Specify file path of .txt file with menu data
string filePath = "../../../CoffeeShop.txt";

//file i/o method to call in import of menu from .txt file
List<Items> menu = ImportFile.Menu(filePath);

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

decimal grandTotal = Receipt.PrintReceipt(listOrdered);

Console.WriteLine("How would you like to pay today: cash, card, or check?");

List<string> payment = new List<string>()
{
    "Cash",
    "Credit",
    "Check"
};
//1. Cash Payment
int paymentMethod = Menu.Int(payment);
decimal amountRemaining = 0;
if (paymentMethod == 1)
{
    amountRemaining=Payment.Cash(grandTotal);
    
}
//2. Card payment
else if (paymentMethod == 2)
{
    Payment.Card();
}
//3. Check Payment
else if (paymentMethod == 3)
{
    Payment.Check();
}

//Console.Clear();
    //this is supposed to clear the console but it's not really doing that?
Console.WriteLine("Thank you for patronage of our fine establishment today. \nHere is your receipt.");
//inserted 3x newline as placeholder spacer before final receipt
//Final receipt printout:
Receipt.PrintReceipt(listOrdered, amountRemaining);
Console.WriteLine("We hope to see you again soon. Have a great day.");

//Console.ReadLine();