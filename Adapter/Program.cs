using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Logger());
            productManager.Save();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved ");
        }
    }
    interface ILogger
    {
        void Log(string message);

    }
    class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("{0}  Logged", message);
        }
    }

    //nuget 
    class Log4Net 
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("{0}, Logged with log4net", message);
        }
    }

    class Log4NetAdapter : ILogger
    {


        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }

}
