using System;
using System.Timers;

namespace UnmanagedResources.ConsoleApp
{
    internal class Program
    {
        private static Timer timer;

        private static void Main(string[] args)
        {
            CreateTimer();

            Console.WriteLine("Press any key to start.");

            while (Console.ReadKey().Key != ConsoleKey.X) DoWork();

            Console.WriteLine("Finished loading, check your memory and press any key to exit.");
            Console.ReadKey();
        }

        private static void CreateTimer()
        {
            timer = new Timer(10000) {AutoReset = true, Enabled = true};
            timer.Elapsed += Timer_Elapsed;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Note:  This is only here so we can forcibly trigger GC so we can see the effects without having to wait for automatic GC.
            // This would not belong in production code.
            GC.Collect();
        }

        private static void DoWork()
        {
            var leaker = new Leaker();
            Console.WriteLine(
                "New Leaker loaded.  Press X to exit, or press any other key to load another Leaker.");
        }
    }
}