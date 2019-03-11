using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class PetShop
    {
        public PetShop(List<IAnimal> animals, float balance) //это конструктор Пет шоп
        {
            this.Animals = animals;
            this.Balance = balance;
        }

        public List<IAnimal> Animals { get; } //список животных
        public float Balance { get; set; }     // баланс Пет шоп

        public void PrintAssortiment()
        {
            var cats = Animals.Where(animal => animal is Cat).ToList(); // Животное, где животное Кот
            var dogs = Animals.Where(animal => animal is Dog).ToList(); // Животное, где животное Собака

            Console.WriteLine($"Total animals count: {Animals.Count}");
            Console.WriteLine($"cats count: {cats.Count}");
            Console.WriteLine($"dogs count: {dogs.Count}");


            cats.ForEach(x => x.Print());
            dogs.ForEach(x => x.Print());

        }

        public void PrintFull() // распечатать всё
        {
            Console.WriteLine($"Balance PetShop: {Balance}$");
            PrintAssortiment();
        }

        // Вызываем метод продажи животных по имени и типу
        public IAnimal SellAnimal(AnimalType animalType, string name)
        {

            var animal = Animals.FirstOrDefault(x =>
            x.Name == name
            && x.Type == animalType);

            // Если Енимал = ничему (не нашли нужного), то выбрасываем исключение (ошибку)
            if (animal == null)
            {
                throw new Exception($"Cannot find {animalType} with name {name}");
            }

            //animal.Price вызвала свойство 

            Balance = Balance + animal.Price;


            // в списке Енимал мы удаляем животное которое купили
            Animals.Remove(animal);
            //и вернули животное 
            return animal;

        }

        // Вызываем метод покупки животного с занесением типа, имени и цены
        public IAnimal BuyAnimal(AnimalType animalType, string name, float price, DateTime birthday)
        {
            IAnimal animal = CreateAnimal(animalType, name, price, birthday);   // вызываем метод класса внутри класса          
            // от баланса вычитываем стоимость покупки животного
            Balance = Balance - animal.Price;
            //Добавляем в список новое животное
            Animals.Add(animal);
            return animal;
        }

        public IAnimal CreateAnimal(AnimalType animalType, string name, float price, DateTime birthday)
        {
            //Объявляем, но еще не инициализируем животное IAnimal animal = null;
            switch (animalType)
            {
                case AnimalType.Dog:
                    return new Dog(birthday, name, price);

                case AnimalType.Cat:
                    return new Cat(birthday, name, price);

                default: throw new NotImplementedException($"Unknown animal type {animalType}"); // если не сработало, то выдает ошибку

            }
        }
    }
}



