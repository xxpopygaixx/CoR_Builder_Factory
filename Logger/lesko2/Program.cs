using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesko2
{
    class Program
    {
        static void Main(string[] args)
        {
            //appinfo_log.previous.txt
            logreader a = new logreader("appinfo_log.previous.txt");
            a.readlogs();
            Console.ReadKey();
        }
    }
}
