using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLab.Vectror
{
    class NormalVector : IVector
    {
        private List<int> valList = new List<int>();

        public void SetVal(int index, int val)
        {
            for (int i = GetSize(); i <= index; i++)
            {
                valList.Add(0);
            }

            valList[index] = val;
        }

        public int GetVal(int index)
        {
            if (index >= GetSize())
            {
                Console.WriteLine("ERROR: Going beyond vector. Return -1");
                return -1;
            }

            return valList[index];
        }

        public int GetSize()
        {
            return valList.Count;
        }

        public void ClearVector()
        {
            valList.Clear();
        }
    }
}
