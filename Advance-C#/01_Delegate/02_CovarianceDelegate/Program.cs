using System;

class Animal
{
    public virtual string Speak() => "Some animal sound";
}

class Dog : Animal
{
    public override string Speak() => "Woof Woof";
}

delegate Animal AnimalDelegate();

class Program
{
    static Dog GetDog() => new Dog();  // Dog is a derived type of Animal means it is inheriting from Animal

    static void Main()
    {
        // Delegate is expecting an Aninal in return but GetDog() is returning Dog which is an derived type of Animal   
        AnimalDelegate del = GetDog;  // Covariance in action
        Animal result = del();
        Console.WriteLine(result.Speak());  // Output: Woof Woof
    }

    // Covariance provides Return-Type flexibility
}
