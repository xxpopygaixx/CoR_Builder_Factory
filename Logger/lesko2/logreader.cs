using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesko2
{
    class logreader
    {
        private List<string> logs;
        string path;
        public logreader(string path)
        {
            this.path = path;
            File.WriteAllText("filewriter.txt","");
            File.WriteAllText("emails.txt","");
        }
        public void readlogs()
        {
            logs = File.ReadAllLines(path).ToList();

            writer fw = new filewriter();
            writer cw = new consolewriter();
            writer ew = new emailwriter();
            fw.next = cw;
            cw.next = ew;
            foreach (var item in logs)
            {
                fw.write(item);
            }
            Console.WriteLine("\n\n\n### END ###");
        }
    }

    
}
