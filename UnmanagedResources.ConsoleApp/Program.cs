using System;

namespace UnmanagedResources.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start.");


            while (Console.ReadKey().Key != ConsoleKey.X) DoWork();

            Console.WriteLine("Finished loading, check your memory and press any key to exit.");
            Console.ReadKey();
        }

        private static void DoWork()
        {
            var leaker = new Leaker();
            Console.WriteLine("New Leaker loaded.  Press X to exit, or press any other key to load another Leaker.");
        }
    }
}