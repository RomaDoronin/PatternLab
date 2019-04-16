using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLab.Vectror
{
    class SparseVector : IVector
    {
        private Dictionary<int, int> valDict = new Dictionary<int, int>();

        public void SetVal(int index, int val)
        {
            if (val != 0)
            {
                valDict[index] = val;
            }
            else
            {
                if (valDict.ContainsKey(index))
                {
                    valDict.Remove(index);
                }
            }
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

        public void ClearVector()
        {
            valDict.Clear();
        }
    }
}
