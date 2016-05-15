using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GestorTFG_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 1)
                {
                    if (args[0].ToUpperInvariant().Trim() == "-VENTANA")
                        Process.Start("GestorTFG.exe");
                    else
                    {
                        new MenuPrincipal();
                    }
                }
                else
                {
                    new MenuPrincipal();
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
          
        }
    }
}
