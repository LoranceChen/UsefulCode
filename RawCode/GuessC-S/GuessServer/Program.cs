using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MainProc mp = new MainProc("127.0.0.1", 26000);
            mp.Listener();

            Console.ReadKey();
        }
    }
}
