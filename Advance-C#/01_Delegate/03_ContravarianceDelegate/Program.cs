using System;

class Animal
{
    public string Name { get; set; }
}

class Dog : Animal { }

class Program
{
    static void HandleDog(Animal animal) => Console.WriteLine($"Handling Dog: {animal.Name}");

    static void Main()
    {
        // HandleDog is expecting a Animal as parameter but delegate allows to pass Dog as well as parameter as Dog is inheriting Animal
        Action<Animal> del = HandleDog;  // No type issue here
        del(new Dog { Name = "Buddy" }); // Output: Handling Dog: Buddy
    }

    // Contravariance provides Parameter-Type flexibility
}
