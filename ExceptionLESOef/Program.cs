using System;
using System.Collections.Generic;

namespace ExceptionLESOef
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person p1 = new Person("Jan", "Jansen", 48);
            Person p2 = new Person("Janine", "Pieters", 42);
            Person p3 = new Person("Lowie", "Jansen", 18);

            List<Person> persons = new List<Person>() { p1, p2, p3 };

            ProcessAction pa = new ProcessAction(persons);
            Console.WriteLine("**addKid**");
            pa.doStuff("addKid");
            Console.WriteLine("**updateAge**");
            pa.doStuff("updateAge");
            Console.WriteLine("**initFormString1**");
            pa.doStuff("initFormString1");
            Console.WriteLine("**initFormString2**");
            pa.doStuff("initFormString2");
        }
    }
}
