# UnmanagedResources
A project demonstrating how to consume unmanaged resources in .NET

# Overview
This project illustrates various approaches to working with unmanaged resources in .NET, specifically memory management and garbage collection.

It is a console application that allocates 1MB blocks of memory using Marshal.AllocHGlobal.

The solution is organized in a number of branches:

MemoryAllocationLeak:  A naive implementation that allocates unmanaged memory in 1MB blocks but does not release that memory

FixedWithIDisposable:  An improved implementation that allocates unmanaged memory using the IDisposable pattern

FixedWithCustomSafeHandle:  An improved implementation using the .NET SafeHandle construct

CustomSafeHandleWithGcFix:  A further-improved implementation of the custom SafeHandle so the Garbage Collector knows about the unmanaged allocation and can schedule runs as appropriate




