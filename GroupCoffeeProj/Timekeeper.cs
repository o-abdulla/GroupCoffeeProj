using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimTool
{
    internal class Timekeeper
    {
        // MM/DD/YYYY
       public static List<string> GetCurrentMonthDayYear()
        {
            string date = DateTime.Now.ToString("M/d/yyyy");
            List<string> monthYear = new List<string>();
            monthYear = date.Split('/').ToList();
            return monthYear;
        }
        // DD
        public static int GetCurrentDay() 
        {
            List<string> monthYear = GetCurrentMonthDayYear();
            return int.Parse(monthYear[1]);
        }
        //MM
        public static int GetCurrentMonth()
        {
            List<string> monthYear = GetCurrentMonthDayYear();
            return int.Parse(monthYear[0]);
        }
        //YYYY
        public static int GetCurrentYear()
        {
            List<string> monthYear = GetCurrentMonthDayYear();
            return int.Parse(monthYear[2]);
        }
        //YY
        public static int GetCurrentYearAbb() 
        {
            return int.Parse(GetCurrentYear().ToString().Substring(2, 2));
        }
    }
}
