using System.Runtime.InteropServices;
using UnmanagedResources.ConsoleApp.SafeHandles;

namespace UnmanagedResources.ConsoleApp
{
    public class Leaker
    {
        private readonly SafeUnmanagedMemoryHandle buffer;

        public Leaker()
        {
            buffer = new SafeUnmanagedMemoryHandle(Marshal.AllocHGlobal(1024 * 1024), true);
        }
    }
}