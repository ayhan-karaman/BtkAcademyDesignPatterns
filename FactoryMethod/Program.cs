using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class LoggerFactory:ILoggerFactory
    {
       public ILogger CreateLogger()
        {
            return new KALogger();
        }
    }

    class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new AKLogger();
        }
    }
    interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    interface ILogger
    {
        void Log();
    }

    class KALogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("K - A Logged!");
        }
    }

    class AKLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("A - K Logged!");
        }
    }

    class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _loggerFactory.CreateLogger().Log();
        }
    }
}
