using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
      
    }

    class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }
    class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Nlogger");
        }
    }

    // Caching abstract yapı

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with memcache");
        }
    }

    class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with rediscache");
        }
    }

    public abstract class CrossCuttingConcernsFactorry
    {
        public abstract Logging CreateLoggin();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactorry
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLoggin()
        {
            return new Log4NetLogger();
        }
    }
    public class Factory2 : CrossCuttingConcernsFactorry
    {
        public override Caching CreateCaching()
        {
            return new MemCache();
        }

        public override Logging CreateLoggin()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactorry _crossCuttingConcernsFactorry;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactorry crossCuttingConcernsFactorry)
        {
            _crossCuttingConcernsFactorry = crossCuttingConcernsFactorry;
            _logging = _crossCuttingConcernsFactorry.CreateLoggin();
            _caching = _crossCuttingConcernsFactorry.CreateCaching();

        }
        public void GetAll()
        {
            _caching.Cache("Data");
            _logging.Log("Logged");
            Console.WriteLine("Products Listed...!");
        }
    }
}
