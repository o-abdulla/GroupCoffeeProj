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
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString();
            List<string> monthYear = new List<string>();
            monthYear = date.Split('/').ToList();
            monthYear[2] = monthYear[2].Substring(0, 4);
            return monthYear;
        }
        // DD
        public static string GetCerentDay() 
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString();
            List<string> monthYear = new List<string>();
            monthYear = date.Split('/').ToList();
            monthYear[2] = monthYear[2].Substring(0, 4);
            return monthYear[1];
        }
        //MM
        public static string GetCerentMonth()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString();
            List<string> monthYear = new List<string>();
            monthYear = date.Split('/').ToList();
            monthYear[2] = monthYear[2].Substring(0, 4);
            return monthYear[0];
        }
        //YYYY
        public static string GetCerentYear()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString();
            List<string> monthYear = new List<string>();
            monthYear = date.Split('/').ToList();
            monthYear[2] = monthYear[2].Substring(0, 4);
            return monthYear[2];
        }
        //YY
        public static string GetCerentYearAbb()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString();
            List<string> monthYear = new List<string>();
            monthYear = date.Split('/').ToList();
            monthYear[2] = monthYear[2].Substring(2, 2);
            return monthYear[2];
        }
    }
}
