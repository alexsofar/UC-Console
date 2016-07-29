using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC_Console
{
    class Program
    {
        static void Main()
        {
            DirectoryHandler dir = new DirectoryHandler();

            dir.OpenDirectory();

            string cmd = "";

            for (int i = 0; cmd != "x"; i++)
            {
                cmd = Console.ReadLine();

                try
                {
                    if (cmd == ".")
                        dir.PrevDirectory();
                    else if (Int32.Parse(cmd) < dir.CountItem)
                    {
                        dir.OpenDirectory(Int32.Parse(cmd));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Команда не опознана :(");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Папка с индексом {0} не существует", cmd);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Доступ запрещен!");
                }
            }
        }
    }
}
