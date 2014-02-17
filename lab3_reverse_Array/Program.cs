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
            int[] plain_array = new int[size]; //our array
            int[] reversed_array = new int[size]; //reversed array
            String s = "";

            //Fill up initial array
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter numbers. " + (size-i).ToString() + " left");
                plain_array[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Output to console
            s = "";
            for (int i = 0; i < size; i++)
            {
                s = s + " " + plain_array[i];
            }
            Console.WriteLine("Initial array:" + s);

            //reverse array
            for (int i = 0; i < size; i++)
            {
                reversed_array[i] = plain_array[size - i - 1];
            }

            //output to console
            s = "";
            for (int i = 0; i < size; i++)
            {
                s = s + " " + reversed_array[i];
            }
            Console.WriteLine("Reversed array:" + s);
            Console.ReadLine();
        }
    }
}
