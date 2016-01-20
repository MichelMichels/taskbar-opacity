using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LogicImplementation
{
    /**
     * Code from (https://github.com/riverar/sample-win10-aeroglass/blob/master/MainWindow.xaml.cs)
     */
    
    // Different states of accent
    internal enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_INVALID_STATE = 4
    }

    // Policy struct ??
    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    // Parameter struct for the Get and SetWindowCompositionAttribute() functions
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
        [DllImport("user32.dll")]
        internal static extern bool SetWindowCompositionAttribute(IntPtr point, ref WindowCompositionAttributeData data);

        [DllImport("user32.dll")]
        internal static extern bool GetWindowCompositionAttribute(IntPtr point, ref WindowCompositionAttributeData data);

        /**
         * Methods
         */

        public bool SetTaskbarInvalid()
        {
            // Set the accent
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_INVALID_STATE;
            
            if(UpdateTaskbar(accent))
            {
                return true;
            } else
            {
                return false;
            }
        }

        private bool UpdateTaskbar(AccentPolicy accent)
        {
            // Get size of struct
            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            // Construct data parameter
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
                    // Get explorer window handle
                    IntPtr hWnd = p.MainWindowHandle;

                    if (SetWindowCompositionAttribute(hWnd, ref data))
                    {
                        // Free memory associated with accentPtr
                        Console.WriteLine("Succeeded");
                        Marshal.FreeHGlobal(accentPtr);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            // Unreachable code
            return false;
        }
    }
}
