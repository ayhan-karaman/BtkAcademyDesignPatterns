using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher engin = new Teacher(mediator);
            engin.Name = "Engin";
            mediator.Teacher = engin;
            Student aras = new Student(mediator);
            aras.Name = "Aras";
            Student emir = new Student(mediator);
            emir.Name = "Emir";
            Student kaan = new Student(mediator);
            kaan.Name = "Kaan";

            List<Student> students = new List<Student>{emir, aras, kaan };

            mediator.Students = students;
            Console.WriteLine(kaan.Name +" " + engin.Name +" hocaya bir soru sor");

            string question = Console.ReadLine();

            
            //engin.SendNewImageUrl("slide.jpg");
           
            kaan.SendNewQuestion(question, kaan);



            Console.ReadLine();

        }
    }
   abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher Recieved a question from {0}, {1}", student.Name,question);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher {1} changed slide: {0}", url, Name);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answer question : {0}, {1}", student.Name, answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get;  set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} received image : {0}", url, Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("{1} received answer [0}",answer, Name);
        }

        public void SendNewQuestion(string question, Student student)
        {
            Console.WriteLine("Student {1} changed question: {0}", question, Name);
            Mediator.SendQuestion(question,student);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
