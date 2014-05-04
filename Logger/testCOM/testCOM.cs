using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace testCOM
{
    [Guid("85BB20AD-022A-48C4-B940-E6AD1629BCD4")]
    public interface I_testCOM
    {
        [DispId(1)]
        void logtofile(String message);
    }

    [Guid("EBDB9B62-F092-4A14-B122-44684CEC3C44"),
    ClassInterface(ClassInterfaceType.None)]
    public class testCOM: I_testCOM
    {
        public void logtofile(String message)
        {
            //System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
            System.IO.File.WriteAllText(@"C:\test.txt", message);
            //file.WriteLine(message);
            //file.Close();
        }
    }

}
