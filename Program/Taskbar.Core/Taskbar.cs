using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using TaskbarController.Core.Data;
using TaskbarController.Core.Enums;
using TaskbarController.Core.Helpers;

namespace TaskbarController.Core
{
    // original code from https://github.com/riverar/sample-win10-aeroglass/blob/master/MainWindow.xaml.cs
    public class Taskbar
    {
        private readonly IUnmanagedMemoryHelper unmanagedMemoryHelper;
        private readonly IProcessFinder processFinder;
        private readonly WindowCompositionAttribute defaultCompositionAttribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;

        public Taskbar(IUnmanagedMemoryHelper unmanagedMemoryHelper, IProcessFinder processFinder)
        {
            this.unmanagedMemoryHelper = unmanagedMemoryHelper;
            this.processFinder = processFinder;

            Initialize();
        }

        public void SetMode(TaskbarMode mode)
        {
            var accentPolicy = new AccentPolicy()
            {
                AccentState = FromTaskbarMode(mode),
            };

            SetAccentPolicy(accentPolicy);
        }

        private void Initialize()
        {
            SetMode(TaskbarMode.Invalid);
        }
        private bool SetAccentPolicy(AccentPolicy accentPolicy)
        {
            var info = unmanagedMemoryHelper.AllocateMemory(accentPolicy);
            var taskbarPointer = processFinder.GetPointer("explorer");            
            var data = GetWCAData(info);

            var isExecuted = SetWindowCompositionAttribute(taskbarPointer, ref data);
            if (isExecuted)
            {
                unmanagedMemoryHelper.FreeMemory(info.Pointer);
                return true;
            }
            
            return false;            
        }        
        private WindowCompositionAttributeData GetWCAData(MarshalData data)
        {
            return new WindowCompositionAttributeData
            {
                Attribute = defaultCompositionAttribute,
                SizeOfData = data.Size,
                Data = data.Pointer
            };
        }
        private AccentState FromTaskbarMode(TaskbarMode mode)
        {
            return mode switch
            {
                TaskbarMode.Blur => AccentState.ACCENT_ENABLE_BLURBEHIND,
                TaskbarMode.Disabled => AccentState.ACCENT_DISABLED,
                TaskbarMode.Gradient => AccentState.ACCENT_ENABLE_GRADIENT,
                TaskbarMode.Invalid => AccentState.ACCENT_INVALID_STATE,
                TaskbarMode.TransparentGradient => AccentState.ACCENT_ENABLE_TRANSPARENTGRADIENT,
                _ => throw new NotSupportedException(),
            };
        }

        [DllImport("user32.dll")]
        internal static extern bool SetWindowCompositionAttribute(IntPtr point, ref WindowCompositionAttributeData data);

        [DllImport("user32.dll")]
        internal static extern bool GetWindowCompositionAttribute(IntPtr point, ref WindowCompositionAttributeData data);
    }
}
