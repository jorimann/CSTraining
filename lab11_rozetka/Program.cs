using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11_rozetka
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class RozetkaSuit
    {
        public void BuyGadget()
        {
            Steps steps = new Steps();

            steps.NavigateTo("http://rozetka.com.ua");
            steps.SearchProduct("Galaxy S4");
            steps.AddProductToBaket("Galaxy S4", 1);
            steps.Checkout();
            steps.AssertTotal(5999);
        }
    }
}
