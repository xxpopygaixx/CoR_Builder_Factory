using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesko2
{
    abstract class writer
    {
        abstract public void write(string logstr);
        public writer next { get; set; }
    }

    class filewriter : writer
    {
        public override void write(string logstr)
        {
            if (logstr.Contains("Starting async write"))
            {
                File.AppendAllText("filewriter.txt", logstr + "\n");
            }
            else if (next != null)
            {
                next.write(logstr);
            }
        }
    }

    class consolewriter : writer
    {
        public override void write(string logstr)
        {
            if (logstr.Contains("RequestAppInfoUpdate"))
            {
                Console.WriteLine(logstr);
            }
            else if (next != null)
            {
                next.write(logstr);
            }
        }
    }

    class emailwriter : writer
    {
        public override void write(string logstr)
        {
            if (logstr.Contains("Requesting"))
            {
                mailbuilder message = new mailbuilder();
                message.addbody(logstr);
                message.addheader("АХТУНГ");
                message.addtagret("someone");
                messege mes = message.getresult();
                File.AppendAllText("emails.txt", "Кому:\n " + mes.target + "\n");
                File.AppendAllText("emails.txt", "Тема:\n " + mes.header + "\n");
                File.AppendAllText("emails.txt", "Сообщение:\n " + mes.body + "\n");
                File.AppendAllText("emails.txt", "\n<--------------->\n");
            }
            else if (next != null)
            {
                next.write(logstr);
            }
        }
    }


}
