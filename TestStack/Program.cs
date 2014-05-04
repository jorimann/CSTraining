using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using System.Diagnostics;

namespace TestStack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Automation peer
            new ProcessStartInfo(@"D:\Repos\Visual Studio\git_repo\App_Debug\WpfTodo.exe");
           // Application.AttachOrLaunch();
        }
    }
}
