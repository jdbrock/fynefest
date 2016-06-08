using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FyneFest.Sync.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize();
            Engine.SyncFromWeb();
        }
    }
}
