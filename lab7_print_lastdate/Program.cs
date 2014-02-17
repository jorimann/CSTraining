using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

//Create an app which reads a date from the console and prints  the last date in that month. 
//And you cannot use the DateTime.DaysInMonth function.
//Example:
//Input:  20/03/2013
//Output: 31/03/2013

namespace lab7_print_lastdate
{
    class Program
    {
        static void Main(string[] args)
        {
            //0. Prepare dictionary with the number of days
            Dictionary<int, int> months = new Dictionary<int, int>();
            months = GetListOfMonths(months);

            Console.WriteLine("Enter date in format 'dd/MM/yyyy'");
            String s = Console.ReadLine();
            DateTime dt;
            //1. Check that date is valid
            if (!DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Entered date was not in required format 'dd/MM/yyyy'");
                Console.ReadLine();
                return;
            }
            else
            {
                //2. Extract Month and return num of days 
                //small hack to fix leap years
                int i = DateTime.IsLeapYear(dt.Year) ? 1 : 0;
                months[2] = months[2] + i;

                Console.WriteLine("The last date is:  {0}", dt.AddDays(months[dt.Month] - dt.Day).ToString("dd/MM/yyyy"));
                Console.ReadLine();
            }
            
        }

        //TODO: what does mean static and can we avoid this?
        public static Dictionary<int, int> GetListOfMonths(Dictionary<int, int> months)
        {

            months.Add(1, 31);
            months.Add(2, 28);
            months.Add(3, 31);
            months.Add(4, 30);
            months.Add(5, 31);
            months.Add(6, 30);
            months.Add(7, 31);
            months.Add(8, 31);
            months.Add(9, 30);
            months.Add(10, 31);
            months.Add(11, 30);
            months.Add(12, 31);
            return months;
        } 
    }
}
