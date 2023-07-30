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
        public static string GetCerentDay() 
        {
            List<string> monthYear = GetCerentMonthDayYear();
            return monthYear[1];
        }
        //MM
        public static string GetCerentMonth()
        {
            List<string> monthYear = GetCerentMonthDayYear();
            return monthYear[0];
        }
        //YYYY
        public static string GetCerentYear()
        {
            List<string> monthYear = GetCerentMonthDayYear();
            return monthYear[2];
        }
        //YY
        public static string GetCerentYearAbb() 
        {
            return GetCerentYear().Substring(2, 2);
        }


    }
}
