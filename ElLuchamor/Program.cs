using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDLSharp;

namespace ElLuchamor
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Name = "El Luchamor";
            Game.Run(new Level()); // uruchom gre
        }
    }
}
