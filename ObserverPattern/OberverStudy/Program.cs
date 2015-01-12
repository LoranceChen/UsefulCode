using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OberverStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat myCat = new Cat();
            Mouse myMouse1 = new Mouse("mouse1", myCat);
            Mouse muMouse2 = new Mouse("mouse2", myCat);
            Master myMaster = new Master(myCat);
            //Master2 myLittleMaster=new mas
            myCat.Cry();
            Console.Read();
        }
    }
}
