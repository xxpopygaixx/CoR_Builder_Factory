using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesko2
{
    class messege
    {
        public string target;
        public string header;
        public string body;
    }

    interface Ibuilder
    {
       void addtagret(string target);
       void addheader(string header);
       void addbody(string body);
       messege getresult();
    }

    class mailbuilder : Ibuilder
    {
        public messege mes = new messege();
        public void addtagret(string target)
        {
            mes.target = target;
        }
        public void addheader(string header)
        {
            mes.header = header;
        }
        public void addbody(string body)
        {
            mes.body = body;
        }
        public messege getresult()
        {
            return mes;
        }
    }
}
