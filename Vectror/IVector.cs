using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_lab.Vectror
{
    interface IVector
    {
        void SetVal(int index, int val);
        int GetVal(int index);
        int GetSize();
    }
}
