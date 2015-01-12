using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAndFox
{
    class NewMailEventArgs :EventArgs
    {
        private readonly string from, to, subject;
        public NewMailEventArgs(string from,string to,string suject)
        {
            this.from = from;
            this.to = to;
            this.subject = subject;
        }
        public string From
        {
            get { return from; }
        }
        public string To
        {
            get { return to; }
        }
        public string Subject
        {
            get { return subject; }
        }
    }
}
