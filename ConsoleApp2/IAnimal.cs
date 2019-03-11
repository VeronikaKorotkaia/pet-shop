using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    interface IAnimal
    {
        string Name { get; }
        AnimalType Type { get; }
        void Print();
        float Price { get; }
    }
}
