using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { Id = 1, FirstName = "Ayhan", LastName = "Karaman", City = "Giresun" };

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Ahmet";
            Console.WriteLine(customer1.FirstName);
            Console.WriteLine("****************");
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();
        }
    }
    abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Customer : Person
    { 
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    class Employee : Person
    {
        public string City { get; set; }
        public string Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
