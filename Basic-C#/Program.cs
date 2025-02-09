using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

namespace CSharpPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            int smallAge = 12;   // int is 32-bit
            long bigAge = 1222222L; // long is 64-bit

            // max-min integer possible
            int longest_integer = int.MaxValue;
            int min_integer = int.MinValue;

            // max-min long possible
            long longest_long = long.MaxValue;
            long min_long = long.MinValue;

            double negativeNumber = -5.5D;
            float floatNumber = 22.22F;
            decimal decimalNumber = 12.22M;  // put M to denote value as decimal

            string name = "Aalam";
            char letter = 'A';

            string age = "22";
            int convertedAge = Convert.ToInt32(age);

            // Converting from string to other data types.
            int textBigInteger = Convert.ToInt32(longest_integer);
            long textBigLong = Convert.ToInt64(longest_long);
            double textDouble = Convert.ToDouble(negativeNumber);
            float textFloat = Convert.ToSingle(floatNumber);
            decimal textDecimal = Convert.ToDecimal(decimalNumber);

            var varData = 12; //var takes the D-T of its value after initialziation

            const int hardInt = 12;  // const makes the D-T unchangeable

            //Operations();

            //SwitchFunction();

            //LoopFunction();

            //Exercise1();

            //Formatting();

            //Exercise2();

            //TryParsing();

            //StringVerbatrim();

            //StringFunctions();

            //Exercise3();

            //ArrayFunctions();

            //ListFunctions();

            //DictFunctions();

            Parameters();


            Console.ReadLine();
        }

        public static void Parameters()
        {
            // out needs to be set in whatever func we are passing it
            int num = 3;
            test1(out num);

            // ref is passing by reference means that we are passing the address
            // no need to set the ref variable explicitly in whatever function you are passing it.
            int age = 12;
            test2(ref age);
        }

        static void test1(out int num)
        {
            num = 5; // need to set the out variable else compile error occurs
        }

        static void test2(ref int age)
        {
            // no need to set the ref variable as "age" has same address in the parent function
        }

        public static void DictFunctions()
        {
            Dictionary<int, string> names = new Dictionary<int, string>()
            {
                {1, "Aalam"},
                {2, "Asad"},
                {3, "Awaiz"}
            };

            for (int i = 0; i < names.Count; i++)
            {
                KeyValuePair<int, string> pair = names.ElementAt(i);
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

            Console.WriteLine();

            foreach(KeyValuePair<int, string> pair in names)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

            Console.WriteLine();

            Dictionary<string, string> teachers = new Dictionary<string, string>()
            {
                {"Math", "Aalam"},
                {"Science", "Asad"},
                {"Geo", "Awaiz"}
            };

            // checking if particular key exists or not then setting its value into mathTeacher
            if(teachers.TryGetValue("Math", out string mathTeacher))
                Console.WriteLine(mathTeacher);
            else
                Console.WriteLine("Math teacher not found");

            // checking if particular key exists or not
            if(teachers.ContainsKey("Math"))
                Console.WriteLine("Math teacher exists");
            else
                Console.WriteLine("Math teacher not found");

            Console.ReadLine();
        }

        public static void ListFunctions()
        {
            int[] numbers = new int[3] { 1, 2, 3 };

            List<int> listNumbers = new List<int>();

            // Adding values into list using Add() func
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter a value: ");
                listNumbers.Add(Convert.ToInt32(Console.ReadLine()));
            }

            //printing the values of the list
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(listNumbers[i]);
            }

            Console.WriteLine();

            listNumbers.RemoveAt(0);

            foreach (var items in listNumbers)
            {
                Console.WriteLine(items);
            }

            Console.ReadLine();
        }

        public static void ArrayFunctions()
        {
            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter a number: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine();

            int[] unsortedNums = new int[]
            {
                6,5,7,1,5
            };

            Array.Sort(unsortedNums);

            for (int i = 0; i < unsortedNums.Length; i++)
            {
                Console.Write($"{unsortedNums[i]} ");
            }

            Console.WriteLine();

            //reversing the values of an array
            int[] unreserved = new int[]
            {
                6,5,7,1,5
            };

            Array.Reverse(unreserved);

            for (int i = 0; i < unreserved.Length; i++)
            {
                Console.Write($"{unreserved[i]} ");
            }

            Console.WriteLine();

            // use clear function to convert the values of array to default
            int[] num2 = new int[] { 6, 5, 7, 1, 5 };

            Array.Clear(num2, 0, 3);

            for (int i = 0; i < num2.Length; i++)
            {
                Console.Write($"{num2[i]} ");
            }

            Console.WriteLine();

            // find the index of values in array using indexOf
            int position1 = Array.IndexOf(num2, 7);
            Console.WriteLine($"Position of 7 is {position1}");

            // Array.IndexOf(array, search, startIndex, EndIndex)
            int position2 = Array.IndexOf(num2, 7, 0, 2);
            Console.WriteLine($"Position of 7 is {position2}");

            Console.ReadLine();
        }

        public static void Exercise3()
        {
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            for (int i = str.Length - 1; i > -1; i--)
            {
                Console.Write(str[i]);
            }

            Console.ReadLine();
        }

        public static void StringFunctions()
        {
            string name = "Alam";
            int age = 12;
            string test = string.Concat("My name is ", name, " and my age is ", age);
            Console.WriteLine(test);

            //creating an empty string
            string emptyString = string.Empty;

            // check if two strings are equal, it checks just the values stored irrespective of their Data-Type
            string str1 = "Hello";
            string str2 = "Hello";

            if (str1.Equals(str2))
                Console.WriteLine("str1 equals to str2");
            else
                Console.WriteLine("str1 not equals to str2");

            string smallMessage = "C# is awesome";
            Console.WriteLine(smallMessage[0]);
            Console.WriteLine(smallMessage[1]);

            for (int i = 0; i < smallMessage.Length; i++)
            {
                Console.Write(smallMessage[i]);
                Thread.Sleep(240);  // Stops the thread for specified milliseconds, 1000ms = 1sec
            }
            Console.WriteLine();

            // use contains if string contains a substring or not
            bool doesContain = smallMessage.Contains("is");
            Console.WriteLine(doesContain);

            // use isNullsOrEmpty to check if contains null/empty
            bool strEmptyOrNull = string.IsNullOrEmpty(smallMessage);
            Console.WriteLine(strEmptyOrNull);

            Console.ReadLine();
        }

        public static void StringVerbatrim()
        {
            // In C# \\ represents a single backslash
            string path = "C:\\aalam\\docs";
            Console.WriteLine(path);

            string speech = "He said \"something\"";
            Console.WriteLine(speech);

            // using @ ignores all escape characters
            string newPath = @"C:\\aalam\\docs\\newDoc.pdf";
            Console.WriteLine(newPath);
        }

        public static void Exercise2()
        {
            Console.Write("Enter a number: ");
            bool success = int.TryParse(Console.ReadLine(), out int num);
            int i = 1;
            while (i <= 10)
            {
                Console.WriteLine($"{num} x {i} = {num * i}");
                i++;
            }
        }

        public static void TryParsing()
        {
            Console.Write("Enter a number: ");
            string num = Console.ReadLine();

            // TryParse tries to convert the input to the desired output and return a bool. If any error occurs it handles it and return a false.
            bool success = int.TryParse(num, out int value);

            //success ? Console.WriteLine(value) : Console.WriteLine("Invalid Input");

            if (success)
                Console.WriteLine(value);
            else
                Console.WriteLine("Invalid Input");
        }

        public static void Operations()
        {
            // when / something then best practice is to store it in double
            double age = 23;
            age /= 2;
            Console.WriteLine(age);

            //adding two char values results in adding their asciii values and converting it to that new ascii value
            char letter = 'a';
            letter += 'b';
            Console.WriteLine(letter);
        }

        public static void Exercise1()
        {
            int num1 = 12, num2 = 5;
            Console.WriteLine(num1 % num2);
        }

        public static void SwitchFunction()
        {
            int day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Invalid weekday");
                    break;
            }
        }

        public static void LoopFunction()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }

            int j = 0;
            while (j < 10)
            {
                Console.WriteLine(j);
                j++;
            }
        }

        public static void Formatting()
        {
            double value = 1000D / 12.3;
            Console.WriteLine(value);
            Console.WriteLine("{0}", value);
            Console.WriteLine("{0:0.00}", value);  // displaying specified number of decimals

            double money = -10D / 3D;
            Console.WriteLine(money.ToString("C", CultureInfo.CurrentCulture));   //display the logo of the current location, check gpt for -ve issue
            Console.WriteLine(money.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
        }
    }
}
