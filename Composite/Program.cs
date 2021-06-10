using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee ayhan = new Employee { Name = "Ayhan Karaman" };
            Employee umit = new Employee { Name = "Ümit Karaman" };

            ayhan.AddSubordinate(umit);

            Employee mevlut  = new Employee { Name = "Mevlüt Karaman" };
            ayhan.AddSubordinate(mevlut);

            Contractor aras = new Contractor { Name = "Aras Karaman" };
            mevlut.AddSubordinate(aras);


            Employee ahmet = new Employee { Name = "Ahmet Karaman" };
            umit.AddSubordinate(ahmet);

            Console.WriteLine(ayhan.Name);
            foreach (Employee manager in ayhan)
            {
                Console.WriteLine(manager.Name);
                foreach (IPerson person in manager)
                {
                    Console.WriteLine(person.Name);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }
    class Contractor:IPerson
    {
        public string Name { get; set; }
    }


    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }


        public string Name { get; set ; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
