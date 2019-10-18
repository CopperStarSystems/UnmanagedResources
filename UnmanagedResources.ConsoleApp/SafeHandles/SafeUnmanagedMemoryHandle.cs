using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace UnmanagedResources.ConsoleApp.SafeHandles
{
    internal sealed class SafeUnmanagedMemoryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal SafeUnmanagedMemoryHandle() : base(true) { }

        internal SafeUnmanagedMemoryHandle(IntPtr preexistingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(preexistingHandle);
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

                // Return success.
                return true;
            }

            // Return false. 
            return false;
        }
    }
}
