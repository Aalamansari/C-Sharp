namespace _02_Generics.Interface
{
    public interface IImportance<T>
    {
        T GetMostImportantOne(T a, T b);    
    }
}
