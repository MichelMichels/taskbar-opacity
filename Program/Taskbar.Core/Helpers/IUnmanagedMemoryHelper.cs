using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskbarController.Core.Helpers
{
    public interface IUnmanagedMemoryHelper
    {
        MarshalData AllocateMemory<T>(T data) where T : struct;
        MarshalData AllocateMemory<T>(T data, int size) where T : struct;
        void FreeMemory(IntPtr pointer);
    }
}
