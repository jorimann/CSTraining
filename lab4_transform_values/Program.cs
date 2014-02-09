using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_transform_values
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of array");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size]; //our array
            String s = "";

            //Fill up initial array
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter numbers. " + (size - i).ToString() + " left");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Output to console
            s = String.Join(" ", arr);
            Console.WriteLine("Initial array: " + s);

            //update array
            for (int i = 0; i < size; i++)
            {
                switch (arr[i])
                {
                    case 0:
                        arr[i] = 1;
                        break;
                    case 1:
                        arr[i] = 42;
                        break;
                    case 2:
                        arr[i] = -42;
                        break;
                    case 3:
                        arr[i] = 0;
                        break;
                    default:
                        arr[i] = Math.Abs(arr[i] - 3) + 1;
                        break;
                }
            }

            //output to console
            s = String.Join(" ", arr);
            Console.WriteLine("Updated array: {0}", s);
            Console.ReadLine();
        }
    }
}
