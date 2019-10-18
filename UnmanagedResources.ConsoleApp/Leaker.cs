using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace UnmanagedResources.ConsoleApp
{
    public class Leaker : IDisposable
    {
        private IntPtr buffer;

        public Leaker()
        {
            buffer = Marshal.AllocHGlobal(1024*1024);
        }

        private void ReleaseUnmanagedResources()
        {
            Console.WriteLine("In Leaker.ReleaseUnmanagedResources");
            Marshal.FreeHGlobal(buffer);
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~Leaker()
        {
            Console.WriteLine("In Leaker Finalizer.");
            ReleaseUnmanagedResources();
        }
    }
}
