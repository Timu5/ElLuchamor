using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDLSharp
{
    public class Log
    {
        public static void WriteLine(string text)
        {
            Console.Write("[{0:D2}:{1:D2}:{2:D2}] ", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            Console.WriteLine(text);
        }
    }
}
