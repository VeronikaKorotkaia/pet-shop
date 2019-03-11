using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Dog : IAnimal
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

        public AnimalType Type => AnimalType.Dog;

        public Dog(DateTime birthday, string name, float price) 
        {
            this.Birthday = birthday;
            this.Name = name;
            this.Price = price;
        }
        public void Print()
        {
            var years = Age.Days / 365;
            var month = (Age.Days % 365) / 30;
            Console.WriteLine($"Dog Name:{Name} Age:{years} Years and  {month} Month Price: {Price} $");
        }
        
    }
}
