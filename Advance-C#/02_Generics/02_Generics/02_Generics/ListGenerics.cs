using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Generics
{
    public class ListGenerics<T>
    {
        private List<T> data = new();
        
        public void AddToList(T value)
        {
            data.Add(value);
            Console.WriteLine($"{value} has been added to the List");
        }
    }
}
