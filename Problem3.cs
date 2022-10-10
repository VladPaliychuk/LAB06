using System;

namespace Problem3
{
    internal class Problem3
    {
        static void Main()
        {
            try
            {
                string[] firstline = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = firstline[0];
                string lastName = firstline[1];
                string fNum = firstline[2];
                Student student = new Student(firstName, lastName, fNum);

                string[] secondline = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                firstName = secondline[0];
                lastName = secondline[1];
                decimal salary = decimal.Parse(secondline[2]);
                decimal hoursPerDay = decimal.Parse(secondline[3]);
                Worker worker = new Worker(firstName, lastName, salary, hoursPerDay);

                student.Print();
                worker.Print();
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

    class Human
    {
        string firstName;
        string lastName;

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (NumContains(value) == true)
                {
                    throw new ArgumentException("First Name not valid.");
                }
                if (Char.IsUpper(value[0])!=true)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName!");
                }
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName!");
                }
                this.firstName = value;
            }
        }
        private string LastName
        {
            get { return this.lastName; }
            set
            {
                if(NumContains(value) == true)
                {
                    throw new ArgumentException("Last Name not valid.");
                }
                if (Char.IsUpper(value[0])!=true)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName!");
                }
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: lastName!");
                }

                this.lastName = value;
            }
        }

        bool NumContains(string str)
        {

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i])) { return true; }
            }
            return false;
        }

        public virtual void Print()
        {
            Console.WriteLine("\nFirst Name: " + this.firstName);
            Console.WriteLine("Last Name: " + this.lastName);
        }
    }
    class Worker : Human
    {  
        decimal salary;
        decimal hoursPerDay;

        public Worker(string firstName, string lastName, decimal salary, decimal hoursPerDay)
            : base(firstName, lastName)
        {
            Salary = salary;
            HoursPerDay = hoursPerDay;
        }
        private decimal Salary
        {
            get { return this.salary; }
            set
            {
                if(value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: salary");
                }
                this.salary = value;
            }
        }
        private decimal HoursPerDay
        {
            get { return this.hoursPerDay; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: hoursPerDay");
                }
                this.hoursPerDay = value;
            }
        }
        private decimal salaryPerHour()
        {
            decimal sPerHour=this.salary/(this.hoursPerDay*5);
            return sPerHour;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Week salary: " + this.salary);
            Console.WriteLine("Hours per day: " + this.hoursPerDay);
            Console.WriteLine("Salary per hour: " + salaryPerHour());
        }
    }

    class Student : Human
    {
        string fNum;

        public Student(string firstName, string lastName, string fNum)
            : base(firstName, lastName)
        {
            FacultyNum = fNum;
        }
        private string FacultyNum
        {
            get { return this.fNum; }
            set
            {
                if(value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.fNum = value;
            }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Faculty number: " + this.fNum);
        }
    }
}
