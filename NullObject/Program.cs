﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            Console.WriteLine("Saved Customer!");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log 4 Net");   
        }
    }

    class NLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with N Logger");
        }
    }


    class StubLogger : ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();

        public StubLogger()
        {
        }
        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger == null)
                {
                    _stubLogger = new StubLogger();

                }
            }
            return _stubLogger;
        }
        public void Log()
        {
           
        }
    }



    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }


}
