﻿using GroupCoffeeProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TimTool
{
    internal class Menu
    {
        //string name =Menu.Str(menuList).ToLower();
        public static Items Str(List<Items> menus,out bool quit )
        {
            Console.Clear();
            Console.WriteLine("Welcome to The D.O.T. Coffeeshop & Boulangerie.\n");
            while (true)
            {
                //Displays the menu 
                for (int i = 1; i < menus.Count + 1; i++)
                {
                    Console.WriteLine("{0,3} {1}", i, menus[i - 1]);
                    //Console.WriteLine("{0,3} \t{1}", i, menus[i - 1]);
                }
                //we took out the tabs
                Console.WriteLine("{0,3} {1}", (menus.Count + 1), "Leave the coffeeshop.");
                int result;
                Console.WriteLine("Please select a number");

                //Validates the number 
                while (!int.TryParse(Console.ReadLine().ToLower().Trim(), out result) || result < 0 || result > menus.Count+1)
                {
                    Console.WriteLine("Invalid input. Try again with a positive number.");
                }
                if (result == menus.Count+1)
                {
                    Console.WriteLine( "Have a nice day");
                    quit = false;
                    return null;
                }
                else
                {
                    quit = true;
                }
                //Rewrite the enter number and the selected category before returning  
                Console.Clear();
                Console.WriteLine("\n{0,3} \t{1}", result, menus[result - 1]);
                Console.WriteLine("====================");
                return menus[result - 1];
            }
        }
        //string name =Menu.Int(menuList).ToLower();
        public static int Int(List<string> menus)
        {
           // Console.Clear();
            while (true)
            {
                //Displays the menu 
                for (int i = 1; i < menus.Count + 1; i++)
                {
                    Console.WriteLine("{0,3} \t{1}", i, menus[i - 1]);
                }
                
                int result;
                Console.WriteLine("Please select a number");

                //Validates the number 
                while (!int.TryParse(Console.ReadLine().ToLower().Trim(), out result) || result < 0 || result > menus.Count)
                {
                    Console.WriteLine("Invalid input. Try again with a positive number.");
                }

                //Rewrite the enter number and the selected category before returning  
                //Console.Clear();
                Console.WriteLine("\n{0,3} \t{1}", result, menus[result - 1]);
                Console.WriteLine("====================");
                return result;
            }
        }

        

        //***********EXAPLE OF PASING HOLE OBJECT THROW

        //Car name =Menu.CarPas(menuList);
        /*
        public static Car CarPas(List<Car> menus)
        {
            Console.Clear();
            while (true)
            {
                //Displays the menu 
                for (int i = 1; i < menus.Count + 1; i++)
                {
                    Console.WriteLine("{0,3} \t{1}", i, menus[i - 1]);
                }
                int result;
                Console.WriteLine("Pleas select a number");

                //Validates the number 
                while (!int.TryParse(Console.ReadLine().ToLower().Trim(), out result) || result < 0 || result > menus.Count)
                {
                    Console.WriteLine("Invalid input. Try again with a positive number.");
                }

                //Rewrite the enter number and the selected category before returning  
                Console.Clear();
                Console.WriteLine("\n{0,3} \t{1}", result, menus[result - 1]);
                Console.WriteLine("====================");
                return menus[result - 1];
            }
        }
        */
    }
   
}


