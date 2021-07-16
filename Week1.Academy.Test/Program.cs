using System;
using System.IO;

namespace Week1.Academy.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("____ Watcher Files ____");
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"C:\Users\alessia.gualtieri\Desktop\Alessia\Avanade\Corso\Week1_Academy";

            //Definisco un filtro di controllo sui file .txt
            fsw.Filter = "*.txt"; //voglio solo file .txt

            // il file watcher tiene traccia di questi eventi elencati
            fsw.NotifyFilter = NotifyFilters.LastWrite |
                NotifyFilters.LastAccess | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

            //Abilito le notifiche
            fsw.EnableRaisingEvents = true;

            //Sottoscrizione all'evento
            fsw.Created += EventManager.HandleNewTextFile;

            string exit;
            do
            {
                Console.Write("Digit q to exit\t");
                exit = Console.ReadLine();
            }
            while (!exit.Equals("q")) ;

        }
    }
}
