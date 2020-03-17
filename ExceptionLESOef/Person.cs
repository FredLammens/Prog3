using System;
using System.Collections.Generic;

namespace ExceptionLESOef
{
    class Person
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        private int age { get; set; }
        public List<Person> kids { get; set; }
        public Person(string firstname, string lastname, int age) => (this.firstname, this.lastname, this.age) = (firstname, lastname, age);
        public Person(string info)
        {
            string[] s = info.Split(';');
            firstname = s[0];
            lastname = s[1];
            age = int.Parse(s[2]);
        }
        public void addKid(Person p)
        {
            kids.Add(p);
        }
        public void initKidsList()
        {
            kids = new List<Person>();
        }
        public void UpdateAge(int age)
        {
            if (age < 0)
                throw new ArgumentException($"Age {age} can not be negative!");
            else
                this.age = age;
        }
    }
}
