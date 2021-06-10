using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class DoubleCheckhedLockinGreetingManager : IGreetingService
    {
        private static DoubleCheckhedLockinGreetingManager _instance;
        private static object _lockObject = new object();
        private string _baseGreet = $"{new Random().Next(2, 100)} Greetings for";
        private DoubleCheckhedLockinGreetingManager() { }


        public static IGreetingService Instance
        {
            get
            {
                if (_instance is null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleCheckhedLockinGreetingManager();
                        }
                    }
                }
                return _instance;
            }
        }




        public void Greet(string name)
        {
            Console.WriteLine($"{_baseGreet} {name}");
        }
    }
}
