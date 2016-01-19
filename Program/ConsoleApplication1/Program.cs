using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttribData data);

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttribData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        static void Main(string[] args)
        {
            pAttrData explorerAttrData = new pAttrData();
            explorerAttrData.attribute = 0x11;
            explorerAttrData.dataSize = 4096;

            Process[] AllProcesses = Process.GetProcesses();

            foreach (Process p in AllProcesses)
            {
                if(p.ProcessName == "explorer")
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine(p.Id + " " + p.Handle);
                    IntPtr hWnd = p.MainWindowHandle;

                    GetWindowCompositionAttribute(hWnd, explorerAttrData);
                    SetForegroundWindow(hWnd);
                }
                //Console.WriteLine("{0}: {1} ({2})", p.Id, p.MainWindowTitle, p.ProcessName);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
