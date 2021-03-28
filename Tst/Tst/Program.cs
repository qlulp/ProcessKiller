using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tst
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Process[] processes =  Process.GetProcesses();
            
            ProcessesManager.Output(processes);
            Console.Write("Удалить процессы, содержащие строку в названии: ");
            processes = ProcessesManager.Find(in processes, Console.ReadLine());

            if (processes.Length > 0)
            {
                Console.WriteLine($"\nНайдены следующие процессы:");
                Console.ForegroundColor = ConsoleColor.White;
                ProcessesManager.Output(processes);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Всего найдено: {processes.Length}");
                Console.ResetColor();
                Console.Write("Удалить? y/n: ");

                if (Console.ReadLine().ToLower() == "y")
                {
                    ProcessesManager.KillProcesses(in processes);
                }
            }
            else
            {
                Console.WriteLine("Ничего не найдено");
            }
            Console.ReadKey();
            Main();
        }
    }
}
