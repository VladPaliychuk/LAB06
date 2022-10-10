using System;
using System.Text;

namespace Problem2
{
    internal class Problem2
    {
        static void Main()
        {
            try
            {
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                decimal price = decimal.Parse(Console.ReadLine());
                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);
                Console.WriteLine(book + Environment.NewLine);
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }

    public class Book
    {
        string title;
        string author;
        decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

#region Validations
        public string Title
        {
            get { return this.title; }
            set
            {
                if (NumContains(value) == true)
                {
                    throw new ArgumentException("Title not valid");
                }
                this.title = value;
            }
        }
        public string Author
        {
            get { return this.author; }
            set
            {
                if (NumContains(value) == true)
                {
                    throw new ArgumentException("Author not valid");
                }
                this.author = value;
            }
        }
        public virtual decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be less than 0.");
                }
                this.price=value;
            }
        }
#endregion

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");
            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }
        bool NumContains(string str)
        {

            for(int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i])) { return true; }
            }
            return false;
        }
    }

    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price) 
            : base(author, title, price)
        {
        }

        public override decimal Price
        {
            get { return base.Price*1.3m; }
        }
    }
}
