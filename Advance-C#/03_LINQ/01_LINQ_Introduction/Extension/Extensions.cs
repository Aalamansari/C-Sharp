using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    public static class Extensions
    {
        public static List<T> Filter<T>(this List<T> records, Func<T, bool> func)
        {
            // records indicate entity where we're calling Filter<T> method, T is the type

            List<T> filteredList = new List<T>();
            
            foreach (T record in records)
            {
                if(func(record)) 
                    filteredList.Add(record);
            }

            return filteredList;
        }

        //func stores the function that we pass in the Filter() method, where it takes the record of Type T as input and returns bool value
    }
}
