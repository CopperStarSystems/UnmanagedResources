using System;
using System.Runtime.InteropServices;

namespace UnmanagedResources.ConsoleApp
{
    public class Leaker
    {
        private IntPtr buffer;

        public Leaker()
        {
            buffer = Marshal.AllocHGlobal(1024*1024);
        }
    }
}
