using System;
using System.Runtime.InteropServices;
using UnmanagedResources.ConsoleApp.SafeHandles;

namespace UnmanagedResources.ConsoleApp
{
    public class Leaker
    {
        private readonly SafeUnmanagedMemoryHandle buffer;

        public Leaker()
        {
            int bufferSize = 1024 * 1024;
            buffer = new SafeUnmanagedMemoryHandle(Marshal.AllocHGlobal(bufferSize), bufferSize, true);
            GC.AddMemoryPressure(1024*1024);
        }
    }
}