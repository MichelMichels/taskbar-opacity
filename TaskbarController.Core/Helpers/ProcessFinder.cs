using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskbarController.Core.Helpers
{
    public class ProcessFinder : IProcessFinder
    {
        public IntPtr GetPointer(string processName)
        {
            return GetProcess(processName).MainWindowHandle;
        }
        public Process GetProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Any())
            {
                return processes.First();
            }

            throw new NotSupportedException($"No processes found with name {processName}.");
        }
    }
}
