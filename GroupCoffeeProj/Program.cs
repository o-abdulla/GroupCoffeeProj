// Coffee Shop Project

//using file_io;

string filePath = "../../../CoffeeShop.txt";

if (File.Exists(filePath) == false)
{
    StreamWriter coffeeWriter = new StreamWriter(filePath);
}