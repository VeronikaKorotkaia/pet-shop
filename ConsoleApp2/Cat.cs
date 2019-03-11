using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Cat : IAnimal
    {
        public string Name { get; }
        public float Price { get; }
        public DateTime Birthday { get; }
        public TimeSpan Age
        {
            get
            {
                return DateTime.Now - Birthday;
            }
        }

        public AnimalType Type => AnimalType.Cat; 

        public Cat(DateTime birthday, string name, float price)
        {
            this.Birthday = birthday;
            this.Name = name;
            this.Price = price;
        }        
        public void Print()
        {
            var years = Age.Days / 365;
            var month = (Age.Days % 365) / 30;
            Console.WriteLine($"Cat Name:{Name} Age:{years} Years and  {month} Month Price: {Price} $");
        }        
    }
}
