using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab9_parse_file_dictionary
{
    class Program
    {
// Create an app which reads a file with symbol pairs in the following format
//a -> b
//c -> z
//y -> x
//
//parses it and creates a dictionary. Then asks the user to enter  a string to console, substitutes symbols using the dictionary and prints the output string.
        static void Main(string[] args)
        {
            String input_path = "D:\\lab9_i.txt";
            if (!File.Exists(input_path))
            {
                Console.WriteLine("Input file was not found! Expected path: {0}", input_path);
                Console.ReadLine();
                return;
            }
            String[] str_pairs = File.ReadAllLines(input_path);
            Dictionary<char, char> dict = new Dictionary<char,char>();

            for (int i = 0; i < str_pairs.Length; i++)
            {
                dict.Add(str_pairs[i].Trim().First(), str_pairs[i].Trim().Last());
            }

            Console.WriteLine("Enter input string now: ");
            StringBuilder str_to_parse = new StringBuilder(Console.ReadLine());
            foreach (var item in dict)
	        {
		        str_to_parse = str_to_parse.Replace(item.Key, item.Value);
	        }

            Console.WriteLine("Updated String: {0}", str_to_parse);
            Console.ReadLine();
        }
    }
}
