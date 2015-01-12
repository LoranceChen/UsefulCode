using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAndFox
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManage mm = new MailManage();
            Fox fox = new Fox(mm);
            mm.SimulateNewMail("a", "b", "how are you?");
            Console.Read();
        }
    }
}
