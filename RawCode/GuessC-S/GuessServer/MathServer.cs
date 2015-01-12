using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications;
namespace GuessServer
{
    class MathServer
    {
        public static IntInfo MathWin(IntInfo p1, IntInfo p2)
        {
            IntInfo tmp = new IntInfo("", UseForEum.Win, (int)Result.Equal, "平手");
            if (p1.MainInfo == p2.MainInfo)
            {
                return tmp;
            }
            else if (p1.MainInfo == (int)Choose.S)
            {
                if (p2.MainInfo == (int)Choose.B)
                {
                    p2.usefor = UseForEum.Win;
                    return p2;
                }
                else if (p2.MainInfo == (int)Choose.J)
                {
                    p1.usefor = UseForEum.Win;
                    return p1;
                }
            }
            else if (p1.MainInfo == (int)Choose.J)
            {
                if (p2.MainInfo == (int)Choose.S)
                {
                    p2.usefor = UseForEum.Win;
                    return p2;
                }
                else if (p2.MainInfo == (int)Choose.B)
                {
                    p1.usefor = UseForEum.Win;
                    return p1;
                }
            }
            else //p1.maininfo==B
            {
                if (p2.MainInfo == (int)Choose.J)
                {
                    p2.usefor = UseForEum.Win;
                    return p2;
                }
                else if (p2.MainInfo == (int)Choose.S)
                {
                    p1.usefor = UseForEum.Win;
                    return p1;
                }
            }
            return tmp;
        }
    }
}
