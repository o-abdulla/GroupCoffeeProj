// Coffee Shop Project

//using file_io;

using GroupCoffeeProj;

string filePath = "../../../CoffeeShop.txt";
//Name, Category, Description, Price,Cream, Sugar, Hot)
if (File.Exists(filePath) == false)
{
    StreamWriter coffeeWriter = new StreamWriter(filePath);
    coffeeWriter.WriteLine("black Coffy| | | 5.00");
    coffeeWriter.WriteLine("Donut | hole| chocolate");
    coffeeWriter.Close();
}

StreamReader coffeeWriter = new StreamReader(filePath);
List<Items> menu =new List<Items>();

while(true)
{
    //Name, Category, Description, Price,Cream, Sugar, Hot)




}










