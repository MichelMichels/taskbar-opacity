using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskbarController.Core.Helpers
{
    public class MarshalData
    {
        public MarshalData(int size, IntPtr pointer)
        {
            Size = size;
            Pointer = pointer;
        }

        public int Size { get; set; }
        public IntPtr Pointer { get; set; }
    }
}
