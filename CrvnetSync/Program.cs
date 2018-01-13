using CrvnetSync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrvnetSync
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ShopifyService shopServ = new ShopifyService();
                shopServ.InsertarEntradas();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
