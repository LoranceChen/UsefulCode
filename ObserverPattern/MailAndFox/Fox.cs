using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAndFox
{
    class Fox
    {
        public Fox(MailManage mm)
        {
            mm.NewMail += new EventHandler<NewMailEventArgs>(FoxMsg);
        
        }
        public void Unregister(MailManage mm)
        {
            mm.NewMail -= new EventHandler<NewMailEventArgs>(FoxMsg);
        }
        private void FoxMsg(object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Foxing mail message:");
            Console.WriteLine("From:{0},To:{1},Subject:{2}", e.From, e.To, e.Subject);
        }
    }
}
