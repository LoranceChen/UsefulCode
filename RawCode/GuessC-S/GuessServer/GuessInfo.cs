using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications;
namespace GuessServer
{
    class GuessInfo
    {
        IntInfo beginInfo;
        IntInfo loadedInfo;
        IntInfo chooseInfo;
        IntInfo resultInfo;
        public GuessInfo()
        {
            beginInfo = new IntInfo();
            loadedInfo = new IntInfo();
            chooseInfo = new IntInfo();
            resultInfo = new IntInfo();
        }
        public IntInfo BeginInfo
        {
            get
            {
                return beginInfo;
            }

            set
            {
                beginInfo = value;
            }
        }

        public IntInfo LoadedInfo
        {
            get
            {
                return loadedInfo;
            }

            set
            {
                loadedInfo = value;
            }
        }

        public IntInfo ChooseInfo
        {
            get
            {
                return chooseInfo;
            }

            set
            {
                chooseInfo = value;
            }
        }

        public IntInfo ResultInfo
        {
            get
            {
                return resultInfo;
            }

            set
            {
                resultInfo = value;
            }
        }
    }
}
