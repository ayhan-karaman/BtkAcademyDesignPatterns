using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class Logging:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogger
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {

        public void UserCheck()
        {
            Console.WriteLine("User checked");
        }
    }

    internal interface IAuthorize
    {
        void UserCheck();
    }

    class Validation : IValidation
    {

        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }

    internal interface IValidation
    {
        void Validate();
    }

    class CustomerManager
    {

        CrossCuttongConcernsFacade _concernsFacade;

        public CustomerManager()
        {
            _concernsFacade = new CrossCuttongConcernsFacade();
        }
        public void Save()
        {

            _concernsFacade.Validation.Validate();
            _concernsFacade.Caching.Cache();
            _concernsFacade.Authorize.UserCheck();
            _concernsFacade.Logger.Log();
            Console.WriteLine("Saved!");
        }
    }

    class CrossCuttongConcernsFacade
    {
        public  ILogger Logger;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidation Validation;

        public CrossCuttongConcernsFacade()
        {
            Authorize = new Authorize();
            Caching = new Caching();
            Logger = new Logging();
            Validation = new Validation();
        }
    }
}
