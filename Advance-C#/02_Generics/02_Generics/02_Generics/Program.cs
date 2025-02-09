// <T> refers that T can be of any type and we can pass only T type of parameter in the function
using _02_Generics;

void TypeChecker<T>(T value)
{
    Console.WriteLine($"Type: {typeof(T)}");
    Console.WriteLine($"Value: {value}");
}

TypeChecker(12);
TypeChecker("Aalam");

Console.WriteLine("===========================================");

// Adding items to the generic list of ListGenerics<T>
ListGenerics<int> numbers = new();
numbers.AddToList(4);

ListGenerics<string> strings = new();
strings.AddToList("aalam");

Console.WriteLine("===========================================");

// performing math operation using generics which has inherited INumeric interface
MathOperations<int> intMath = new();
Console.WriteLine(intMath.Add(2,3));

MathOperations<double> doubleMath = new();
Console.WriteLine(doubleMath.Add(2.12, 3.123));

//putting contraints on generics
public class SampleClass1<T> where T: class, new()  // This have a constraint that T can be class or it needs to have a constructor
{

}

public class SampleClass2<T, U> where T : U  // U derives from T 
{

}

