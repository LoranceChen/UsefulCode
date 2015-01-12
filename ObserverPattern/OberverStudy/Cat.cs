using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OberverStudy
{
    class Cat :ModelBase
    {
        public Cat()
        {

        }
        //行为
        public void Cry()
        {
            System.Console.WriteLine("Cat Cry..");

            this.Notify();
        }
    }
}
