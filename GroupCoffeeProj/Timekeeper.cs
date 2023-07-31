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
       public static List<string> GetCerentMonthDayYear()
        {
            string date = DateTime.Now.ToString("M/d/yyyy");
            List<string> monthYear = new List<string>();
            monthYear = date.Split('/').ToList();
            return monthYear;
        }
        // DD
        public static int GetCerentDay() 
        {
            List<string> monthYear = GetCerentMonthDayYear();
            return int.Parse(monthYear[1]);
        }
        //MM
        public static int GetCerentMonth()
        {
            List<string> monthYear = GetCerentMonthDayYear();
            return int.Parse(monthYear[0]);
        }
        //YYYY
        public static int GetCerentYear()
        {
            List<string> monthYear = GetCerentMonthDayYear();
            return int.Parse(monthYear[2]);
        }
        //YY
        public static int GetCerentYearAbb() 
        {
            return int.Parse(GetCerentYear().ToString().Substring(2, 2));
        }
    }
}
