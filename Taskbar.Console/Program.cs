using System;
using TaskbarController.Core.Helpers;
using TaskbarController.Core;
using TaskbarController.Core.Enums;

namespace TaskbarController.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var processFinder = new ProcessFinder();
            var unmanagedMemoryHelper = new MarshalHelper();

            var taskbar = new Taskbar(unmanagedMemoryHelper, processFinder);
            //taskbar.SetMode(TaskbarMode.Invalid);
        }
    }
}
