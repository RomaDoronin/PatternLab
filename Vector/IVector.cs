using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLab.Vectror
{
    interface IVector
    {
        void SetVal(int index, int val);
        int GetVal(int index);
        int GetSize();
        void ClearVector();
    }
}
