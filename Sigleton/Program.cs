using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // var customerManager = CustomerManager.CreateAsSingleton();
            //customerManager.Save();
            //DoubleCheckhedLockinGreetingManager.Instance.Greet("singleton design");

            IGreetingService service = DoubleCheckhedLockinGreetingManager.Instance;
            IGreetingService service1 = DoubleCheckhedLockinGreetingManager.Instance;

            service.Greet("Singleton 1");
            service1.Greet("Singleton 2");
            service.Greet("Singleton 3");
          
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }

       public  static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
              return   _customerManager ?? (_customerManager = new CustomerManager());
              
            }
          
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}
