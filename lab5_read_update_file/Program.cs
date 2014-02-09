using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab5_read_update_file
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an app which reads a random text file, replaces all “a” letters with “b”,  
            //all “b” letters with “c” and all “c” letters with “a” and saves a copy of the file back to the disk
            //Example
            //input:                asdbwiurlcasd
            //output:               bsdcwiurlabsd
            Console.WriteLine("Enter the full path to file");
            String spath = Console.ReadLine();
            StringBuilder sb = new StringBuilder(File.ReadAllText(spath));
            for (int i = 0; i < sb.Length; i++)
			{
			    switch (sb[i])
	            {
		            case 'a': 
                        sb[i] = 'b';
                        break;
                    case 'b':
                        sb[i] = 'c';
                        break;
                    case 'c':
                        sb[i] = 'a';
                        break;
            	}
			}
            File.WriteAllText(spath, sb.ToString());
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
