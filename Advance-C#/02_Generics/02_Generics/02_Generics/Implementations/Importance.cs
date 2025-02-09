using _02_Generics.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Generics.Implementations
{
    public class Importance : IImportance<int>
    {
        public int GetMostImportantOne(int a, int b)
        {
            if (a>b) 
                return a;
            else
                return b;
        }
    }
}
