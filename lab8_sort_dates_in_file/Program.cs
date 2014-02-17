using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace lab8_sort_dates_in_file
{
    class Program
    {
        
//Create an app which reads an unsorted list of dates from a file (date format is '21_12_2013 20-21' ) and sorts dates and writes the sorted dates into a new file. 
//The output date format is as in ANSI SQL (2013-12-21 20:21:00)
//Example:
//input: dates.txt           output: sortedDates.txt
// 21_12_2013 20-21       2013-01-20 20:21:00
// 20_01_2013 00-21       2013-09-20 21:00:00    
// 20_09_2013 21-00       2013-12-21 20:21:00                               

        static void Main(string[] args)
        {
            String input_path = "D:\\lab8_i.txt";
            String output_path = "D:\\lab8_o.txt";
            if (!File.Exists(input_path))
            {
                Console.WriteLine("Input file was not found! Expected path: {0}", input_path);
                Console.ReadLine();
                return;
            }
            String[] str_dates = File.ReadAllLines(input_path);
            DateTime [] dates = new DateTime[str_dates.Length];
            for (int i = 0; i < dates.Length; i++)
            {
                dates[i] = DateTime.ParseExact(str_dates[i], "dd_MM_yyyy HH-mm", CultureInfo.CurrentCulture);                
            }

            Array.Sort(dates);

            for (int i = 0; i < dates.Length; i++)
            {
                str_dates[i] = dates[i].ToString("yyyy-MM-dd HH:mm:ss");                
            }

            File.WriteAllLines(output_path, str_dates);
            Console.WriteLine("Done");
            Console.ReadLine();

        }
    }
}
