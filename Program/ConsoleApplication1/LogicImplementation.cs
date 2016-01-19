using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LogicImplementation
{
    /**
     * Code from (https://github.com/riverar/sample-win10-aeroglass/blob/master/MainWindow.xaml.cs)
     */

    internal enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_INVALID_STATE = 4
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    internal enum WindowCompositionAttribute
    {
        // ...
        WCA_ACCENT_POLICY = 19
        // ...
    }

    public class Logic
    {
        /**
         *  DLLImports
         */
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        [DllImport("user32.dll")]
        internal static extern bool SetWindowCompositionAttribute(IntPtr point, ref WindowCompositionAttributeData data);

        [DllImport("user32.dll")]
        internal static extern bool GetWindowCompositionAttribute(IntPtr point, ref WindowCompositionAttributeData data);

        /**
         *  Structs (code from https://github.com/riverar/sample-win10-aeroglass/blob/master/MainWindow.xaml.cs)
         */
        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        internal enum WindowCompositionAttribute
        {
            // ...
            WCA_ACCENT_POLICY = 19
            // ...
        }

        static void Main(string[] args)
        {
            // get accent
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_INVALID_STATE;
            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            // Get all processes 
            Process[] AllProcesses = Process.GetProcesses();

            // Search explorer process
            foreach (Process p in AllProcesses)
            {
                if (p.ProcessName == "explorer")
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine(p.Id + " " + p.Handle);
                    IntPtr hWnd = p.MainWindowHandle;

                    if (SetWindowCompositionAttribute(hWnd, ref data))
                    {
                        Console.WriteLine("Data: {0}", data.Data);
                    } else
                    {
                        Console.WriteLine(GetWindowCompositionAttribute(hWnd, ref data));
                        Console.WriteLine(Marshal.GetLastWin32Error());
                    }
                    SetForegroundWindow(hWnd);

                    break;
                }
                //Console.WriteLine("{0}: {1} ({2})", p.Id, p.MainWindowTitle, p.ProcessName);
            }

            Marshal.FreeHGlobal(accentPtr);

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
