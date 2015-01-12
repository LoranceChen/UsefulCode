using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OberverStudy
{
    public abstract class Observer
    {
        public Observer(ModelBase childModel)
        {
            childModel.SubEvent += new ModelBase.SubEventHandler(Response);
        }
        public abstract void Response();
    }
}
