using System.Numerics;

namespace _02_Generics
{
    public class MathOperations<T> where T : INumber<T>
    {
        public T Add(T x, T y)
        {
            return x + y;  // This is only possible coz of INumber<T>
        }
    }
}
