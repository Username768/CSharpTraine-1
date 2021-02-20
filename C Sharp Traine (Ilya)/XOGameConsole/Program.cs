using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOGameCore;

namespace XOGameConsole
{
    class Program 
    {
        static void Main(string[] args)
        {
            Core gameCore = new Core(new UI());
            gameCore.Start();
        }
    }
}
