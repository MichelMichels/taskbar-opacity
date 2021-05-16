using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskbarController.Core.Helpers
{
    public interface IProcessFinder
    {
        IntPtr GetPointer(string processName);
        Process GetProcess(string processName);
    }
}
