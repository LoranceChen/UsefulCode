using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OberverStudy
{
    class Master :Observer
    {
        public Master(ModelBase childModel) : base(childModel) { }
        public override void Response()
        {
            System.Console.WriteLine("sleep");
        }
    }
}
