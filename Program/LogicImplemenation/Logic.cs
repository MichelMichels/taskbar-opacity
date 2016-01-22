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
        ///////////////////////////////////////////////////////
        ////               DLL IMPORTS                    /////
        ///////////////////////////////////////////////////////
        [DllImport("user32.dll")]
        internal static extern bool SetWindowCompositionAttribute(IntPtr point, ref WindowCompositionAttributeData data);

        [DllImport("user32.dll")]
        internal static extern bool GetWindowCompositionAttribute(IntPtr point, ref WindowCompositionAttributeData data);

        ///////////////////////////////////////////////////////
        ////               EVENTS                         /////
        ///////////////////////////////////////////////////////

        public event Action ParametersChanged;

        ///////////////////////////////////////////////////////
        ////               FIELDS                         /////
        ///////////////////////////////////////////////////////

        private int _currentAccentState;
        private int _currentAccentFlags;
        private int _currentGradientColor;
        private int _currentAnimationId;


        ///////////////////////////////////////////////////////
        ////              PROPERTIES                      /////
        ///////////////////////////////////////////////////////

        public int CurrentAccentState
        {
            get
            {
                return _currentAccentState;
            }
        }

        public int CurrentAccentFlags
        {
            get
            {
                return _currentAccentFlags;
            }
        }

        public int CurrentGradientColor
        {
            get
            {
                return _currentGradientColor;
            }
        }

        public int CurrentAnimationId
        {
            get
            {
                return _currentAnimationId;
            }
        }


        ///////////////////////////////////////////////////////
        ////                  METHODS                     /////
        ///////////////////////////////////////////////////////

        // Update current parameters
        public void UpdateParameters()
        {
            // Variable for our new accent policy
            var newAccentPolicy = new AccentPolicy();

            
            // Get size of struct
            var accentStructSize = 1024;
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(newAccentPolicy, accentPtr, false);

            // Construct data parameter
            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;
            Console.WriteLine("Before: {0} {1} {2}", data.Data, data.SizeOfData, data.Attribute);

            // Get all processes 
            Process[] explorerProcesses = Process.GetProcessesByName("explorer");

            Console.WriteLine("Logic: {0} {1}", explorerProcesses[0].ProcessName, explorerProcesses[0].Id);
            IntPtr hWnd = explorerProcesses[0].MainWindowHandle;

            try {
                // Check if function executes
                GetWindowCompositionAttribute(hWnd, ref data);

                Console.WriteLine("After: {0} {1} {2}", data.Data, data.SizeOfData, data.Attribute);

            } catch (Exception e) {
                Console.WriteLine("Error occurred: {0}", e);
            } finally
            {
                // Free memory associated with accentPtr
                //Marshal.FreeHGlobal(accentPtr);
            }


        }

        // Taskbar invalid or transparent
        public bool SetTaskbarInvalid()
        {
            // Set the accent
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_INVALID_STATE;

            if (UpdateTaskbar(accent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Taskbar gradient
        public bool SetTaskBarGradient()
        {
            // Set the accent
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_GRADIENT;

            // Update Taskbar
            if (UpdateTaskbar(accent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Taskbar gradient
        public bool SetTaskBarBlur()
        {
            // Set the accent
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            // Update Taskbar
            if (UpdateTaskbar(accent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Taskbar gradient
        public bool SetTaskBarTransparentGradient()
        {
            // Set the accent
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_TRANSPARENTGRADIENT;

            // Update Taskbar
            if (UpdateTaskbar(accent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Taskbar gradient
        public bool SetTaskBarDisabled()
        {
            // Set the accent
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_DISABLED;

            // Update Taskbar
            if (UpdateTaskbar(accent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Change the taskbar
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
            Process[] explorerProcesses = Process.GetProcessesByName("explorer");

            // Taskbar will be the first process
            IntPtr hWnd = explorerProcesses[0].MainWindowHandle;

            // Check if function executes
            if (SetWindowCompositionAttribute(hWnd, ref data))
            {
                // Free memory associated with accentPtr
                Marshal.FreeHGlobal(accentPtr);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
