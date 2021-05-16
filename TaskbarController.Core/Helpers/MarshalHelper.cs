using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskbarController.Core.Helpers
{
    public class MarshalHelper : IUnmanagedMemoryHelper
    {        
        public MarshalData AllocateMemory<T>(T data, int size) where T : struct
        {
            var pointer = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(data, pointer, false);

            return new MarshalData(size, pointer);
        }
        public MarshalData AllocateMemory<T>(T data) where T : struct
        {
            var size = Marshal.SizeOf(data);
            return AllocateMemory(data, size);
        }
        public void FreeMemory(IntPtr pointer)
        {
            Marshal.FreeHGlobal(pointer);
        }
    }
}
