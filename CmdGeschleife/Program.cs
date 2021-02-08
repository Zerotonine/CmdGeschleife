using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CmdGeschleife
{
    class Program
    {
        static void Main(string[] args)
        {
            string ausgabe = "";
            while(true)
            {
                Console.Clear();
                Console.Write(Environment.CurrentDirectory +  "> ");
                string eingabe = Console.ReadLine();

                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo("cmd", "/c " + eingabe);
                    psi.CreateNoWindow = true;
                    psi.RedirectStandardOutput = true;
                    psi.UseShellExecute = false;
                    
                    Process p = new Process();
                    p.StartInfo = psi;
                    p.Start();

                    ausgabe = p.StandardOutput.ReadToEnd();
                    Console.WriteLine(ausgabe);
                }
                catch
                {
                }

                if(!String.IsNullOrEmpty(ausgabe))
                    Console.ReadKey();
            }
        }
    }
}
