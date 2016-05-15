using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GestorTFG_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                if (args[0].ToUpperInvariant().Trim() == "-CONSOLE")
                    new MenuPrincipal();
                else
                {
                    Process.Start("GestorTFG.exe");
                }
            }
            else
            {
                Process.Start("GestorTFG.exe");
            }
          
        }
    }
}
