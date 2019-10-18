using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace UnmanagedResources.ConsoleApp.SafeHandles
{
    internal sealed class SafeUnmanagedMemoryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal SafeUnmanagedMemoryHandle() : base(true) { }
        private int bufferSize;

        internal SafeUnmanagedMemoryHandle(IntPtr preexistingHandle, int bufferSize, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(preexistingHandle);
            this.bufferSize = bufferSize;   
            GC.AddMemoryPressure(bufferSize);
        }

        override protected bool ReleaseHandle()
        {
            // "handle" is the internal
            // value for the IntPtr handle.

            // If the handle was set,
            // free it. Return success.
            Console.WriteLine("In SafeUnmanagedMemoryHandle.ReleaseHandle.");
            if (handle != IntPtr.Zero)
            {

                // Free the handle.
                Marshal.FreeHGlobal(handle);
                
                // Set the handle to zero.
                handle = IntPtr.Zero;

                GC.RemoveMemoryPressure(bufferSize);
                // Return success.
                return true;
            }

            // Return false. 
            return false;
        }
    }
}
