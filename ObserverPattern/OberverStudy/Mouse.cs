using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OberverStudy
{
    class Mouse :Observer
    {
        private string name;
        public Mouse(string name,ModelBase childModel) :base(childModel)
        {
            this.name = name;
        }

        public override void Response()
        {
            System.Console.WriteLine(this.name + "开始跑");
        }
    }
}
