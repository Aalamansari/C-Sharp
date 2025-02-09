namespace _01_DelegateBasicExample
{
    public class Program
    {
        // LogDel can refer to functions which are void and accept a string param
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            // This delegate is calling an static method
            LogDel logDel1 = new LogDel(LogTextToScreen1);
            logDel1("This delegate is instantiating an Static method.");

            // This delegate is calling an instance method
            Log log = new Log();
            LogDel logDel2 = new LogDel(log.LogTextToScreen2);
            logDel2("This delegate is instantiating an Instance method.");

            Console.WriteLine("--------------------");

            // we can assign multiple functions to a single delegate and execute them at once
            LogDel singleDel1 = new LogDel(log.Delegate1);
            LogDel singleDel2 = new LogDel(log.Delegate2);

            LogDel multiDel = singleDel1 + singleDel2;
            multiDel("This is single delegate calling multiple functions.");

            Console.WriteLine("--------------------");

            // passing delegate as a parameter in a function
            LogText(multiDel, "Here delegate was passed as parameter in LogText() function");

            Console.ReadKey();
        }

        static void LogTextToScreen1(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }

    public class Log
    {
        public void LogTextToScreen2(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
        public void Delegate1(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
        public void Delegate2(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}
