using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_lab.Vectror
{
    class SparseVector : IVector
    {
        private Dictionary<int, int> valDict = new Dictionary<int, int>();

        public void SetVal(int index, int val)
        {
            valDict[index] = val;
        }

        public int GetVal(int index)
        {
            if (valDict.ContainsKey(index))
            {
                return valDict[index];
            }
            else
            {
                return 0;
            }
        }

        public int GetSize()
        {
            return valDict.Keys.Max();
        }
    }
}
