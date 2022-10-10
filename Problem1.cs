using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LAB06
{
    internal class Problem1
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                Child child = new Child(name, age);
                Console.WriteLine(child);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

    public class Person
    {
        string name;
        int age;
        public Person(string name, int age)
        {
            this.name = name; 
            this.age = age;
        }
        public virtual string Name
        {
            get { return this.name; }
            set
            {
                if(value.Length < 3) 
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
                else { this.name = value; }
            }
        }
        public virtual int Age
        {
            get { return this.age; }
            set 
            {
                if(value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                else { this.age = value; }
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));

            return stringBuilder.ToString();
        }
    }

    class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
            
        }
        public override string Name
        {
            get { return base.Name; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
                else { base.Name = value; }
            }
        }
        public override int Age
        {
            get { return base.Age;}
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }
                else { base.Age = value; }
            }
        }
    }
}
