using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of array");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size]; //our array
            int[] rev = new int[size]; //reversed array
            String s = "";

            //Fill up initial array
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter numbers. " + (size-i).ToString() + " left");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Output to console
            s = "";
            for (int i = 0; i < size; i++)
            {
                s = s + " " + arr[i];
            }
            Console.WriteLine("Initial array:" + s);

            //reverse array
            for (int i = 0; i < size; i++)
            {
                rev[i] = arr[size - i - 1];
            }

            //output to console
            s = "";
            for (int i = 0; i < size; i++)
            {
                s = s + " " + rev[i];
            }
            Console.WriteLine("Reversed array:" + s);
            Console.ReadLine();
        }
    }
}
