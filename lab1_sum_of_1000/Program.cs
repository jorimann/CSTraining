using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write an app which calculates the sum of all numbers below 1000 that divide by either 3 or 5 without remainder.
namespace lab1_sum_of_1000
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter int number");
            int range = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= range; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) sum = sum + i;
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
