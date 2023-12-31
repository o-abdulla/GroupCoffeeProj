﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupCoffeeProj
{
    internal class ImportFile
    {
        public static List<Items> Menu(string filePath)
        {
            
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
                    parts.Select(p => p.Trim());
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
            return menu;
        }
    }
}
