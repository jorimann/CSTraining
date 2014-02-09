using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_parse_url
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter url to parse");
            //string url = Console.ReadLine();
            string url = "http://prezi.com/fxzefllyyqgi/c-and-oop-basics/?utm_campaign=share&utm_medium=copy";
                   url = "http://channel9.msdn.com/Series/C-Sharp-Fundamentals-Development-for-Absolute-Beginners";
            //         url = "https://domain.com/default.aspx";
           //        url = "ftp://xxx:124/path";
                   url = "https://docs.google.com/spreadsheet/ccc?key=0Aq2J7s8tC1W3dFdXVnk0dmtOQlZKN21kSlNuLXF6bFE&usp=sharing#gid=0";
            Console.WriteLine(url+ "\n");
            
            string req_part = "";
            string s = "";

            //1. Get protocol
            string[] arr = url.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("protocol: {0}", arr[0]);

            //1.1 join array back except first element
            s = String.Join(":", arr, 1, arr.Length - 1);
            
            //Console.WriteLine("path:   {0}", s);

            //2. Get uep part
            arr = s.Split(new[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine("uep: {0}", arr[0]);
            if (arr.Length > 1)
            {
                req_part = arr[1];
            };

            //3. Split uep to domain and relative part
            arr = arr[0].Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("domain: {0}", arr[0]);

            s = String.Join("/", arr, 1, arr.Length - 1);
            Console.WriteLine("path:   {0}", s);
            
            //4. Get '?' part
            if (!req_part.Equals(""))
            {
                //Console.WriteLine("request: {0}", req_part);
                //4.1 Split by "&"
                arr = req_part.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("request param[{0}]: {1}", i, arr[i]);
                }
            }
            

            //string[] arr = url.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            //Console.WriteLine("protocol: {0}", arr[0].Replace(":", ""));
            //Console.WriteLine("domain: {0}", arr[1]);
            //if (arr.Length>4)
            //{
            //    string s = "";
            //    for (int i = 2; i < arr.Length-1; i++)
            //    {
            //        s = s + arr[i] + "/";
            //    }
            //    Console.WriteLine("path:    {0}", s);

            //    string[] query = arr[arr.Length - 1].Split('&');
            //    for (int i = 0; i < query.Length; i++)
            //    {
            //        Console.WriteLine("query:    {0}", query[i]);                    
            //    }
            //}
            
            
            Console.ReadLine();
        }
    }
}
