using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_square_equation
{
    class Program
    {
        static void Main(string[] args)
        {
            String s="";
            do{
                Square();
                Console.WriteLine("Would you like one more? (y/n)");   
                s = Convert.ToString(Console.ReadLine());
            }while (s.Equals("y")); 
        }

        static void Square()
        {
            //Enter initial values
            Console.WriteLine("Squre equation: ax^2 + bx + c=0. Enter a, b, c");
            Double a = Convert.ToDouble(Console.ReadLine());
            Double b = Convert.ToDouble(Console.ReadLine());
            Double c = Convert.ToDouble(Console.ReadLine());

            //Calculate discriminant D=b^2 - 4ac
            Double D = b * b - 4 * a * c;
            if (D < 0) //Discriminant is negative, no solutions in real area
            {
                Console.WriteLine("D=" + D.ToString() + " it means no real solutions.");
            }
            else //D>=0. Calculate solutions
            {
                Double x1 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                Double x2 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                Console.WriteLine("x1 = " + x1.ToString() + "; x2 = " + x2.ToString());
            }

            Console.ReadLine();
        }
    }
}
