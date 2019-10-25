using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace HackingPOS.Scrapers.MemoryScraper
{
    public class ProcessMemoryLoader
    {

        private Process process = null;

        private IntPtr processHandler = IntPtr.Zero;

        const uint PROCESS_VM_READ = 0x0010;
        const uint PROCESS_VM_OPERATION = 0x0008;
        const uint PROCESS_VM_WRITE = 0x0020;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

        public ProcessMemoryLoader()
        {
        }

        public void OpenProcess(Process process)
        {
            this.process = process;
            processHandler = OpenProcess(PROCESS_VM_READ | PROCESS_VM_OPERATION | PROCESS_VM_WRITE, 1, (uint)process.Id);
        }

        public void CloseProcess()
        {
            try
            {
                CloseHandle(processHandler);
            }
            catch 
            {
            }
        }

        public byte[] LoadMemory(IntPtr MemoryAddress, uint bytesToRead, out int bytesRead)
        {
            byte[] buffer = new byte[bytesToRead];

            IntPtr ptrBytesRead;
            Int32 res = ReadProcessMemory(processHandler, MemoryAddress, buffer, bytesToRead, out ptrBytesRead);

            bytesRead = ptrBytesRead.ToInt32();

            return buffer;
        }
    }
}