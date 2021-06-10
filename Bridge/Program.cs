using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Body body = new Body { Title = "About the course!" };
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.UpdateCustomer(body);

            Console.ReadLine();
        }
    }
    public class Body
    {
        public string Title { get; set; }

        public string Text { get; set; }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved!");
        }

        public abstract void Send(Body body);
        
    }

    class MailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via mail sender ", body.Title);
        }
    }

   

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via sms sender ", body.Title);
        }
    }

    class CustomerManager
    {
       public MessageSenderBase MessageSenderBase { get; set; } 
        public void UpdateCustomer(Body body)
        {
            MessageSenderBase.Send(body);
            Console.WriteLine("Customer Updated");
        }
    }
}
