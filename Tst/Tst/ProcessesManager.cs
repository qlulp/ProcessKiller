using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tst
{
    class ProcessesManager
    {

        /// <summary>
        /// Удаление процессов
        /// </summary>
        /// <param name="processes">массив процессов для удаления</param>
        public static void KillProcesses(in Process[] processes)
        {
            foreach (Process process in processes)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Попытка удалить процесс {process.ProcessName}...\t");
                try
                {
                    process.Kill();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Процесс успешно удалён");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Вывод процессов
        /// </summary>
        /// <param name="processes">массив процессов для вывода</param>
        public static void Output(in Process[] processes)
        {
            int i = GetMax(in processes) + 4;
            foreach (Process process in processes)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{process.ProcessName}");
                for (int j = process.ProcessName.Length; j < i; j++)
                    Console.Write(" ");
                Console.ResetColor();
                Console.WriteLine($"{process.PagedMemorySize64 / 1024}КБ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Получить максимальную длину названия процесса
        /// </summary>
        /// <param name="processes">массив процессов</param>
        /// <returns></returns>
        private static int GetMax(in Process[] processes)
        {
            int i = processes[0].ProcessName.Length;

            for (int j = 0; j < processes.Length; j++)
            {
                if (i < processes[j].ProcessName.Length)
                    i = processes[j].ProcessName.Length;
            }
            return i;
        }


        /// <summary>
        /// Поиск процессов по ключевому слову
        /// </summary>
        /// <param name="processes">Массив процессов</param>
        /// <param name="key">Ключевое слово, содержащееся в названии процесса</param>
        /// <returns>Массив процессов, элементы которого удовлетворяют условиям поиска</returns>
        public static Process[] Find(in Process[] processes, string key)
        {
            return processes.Where(i => i.ProcessName.Contains(key)).ToArray();
        }

    }
}
