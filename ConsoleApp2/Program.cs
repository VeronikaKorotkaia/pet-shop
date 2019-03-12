using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
    class MainClass
    {

        public static void Main(string[] args)

        {

            var path = "D:\\PetShop.json";
            var persister = new Persister();

            PetShop petShop = InitializePetShop(path, persister);

            while (true)
            {
                var answer = ShowMenu();
                switch (answer)
                {
                    case 1:
                        BuyAnimal(petShop);
                        persister.SaveToFile(petShop, path);
                        break;

                    case 2:
                        SellAnimal(petShop);
                        persister.SaveToFile(petShop, path);
                        break;

                    case 3:
                        petShop.PrintFull();
                        break;

                    case 4: return;
                    default: Console.WriteLine("Please, enter value from 1 to 4");
                        break;
                }
            }

            //var soldAnimal = petShop.SellAnimal(AnimalType.Cat, "Ital"); // какое животное продали
            //Console.WriteLine($"Congratulations! You bought:");

            //soldAnimal.Print();

            //var buyAnimal = petShop.BuyAnimal(AnimalType.Dog, "Mikki", 40.99f, new DateTime(year: 2017, month: 09, day: 08)); // какое животное покупаем
            //buyAnimal.Print();
            //Console.WriteLine($"You bought a new animal:");

            //petShop.PrintFull();

            //Console.ReadKey();

        }


        private static PetShop InitializePetShop(string path, Persister persister)
        {
            PetShop petShop = null; // вынесли код в отдельный метод
            if (File.Exists(path))
            {
                petShop = persister.LoadFromFile<PetShop>(path);
            }
            else
            {
                petShop = CreateDefaultPetShop();
            }

            return petShop;
        }

        private static PetShop CreateDefaultPetShop()
        {
            List<IAnimal> animals = new List<IAnimal>()
            {
                new Dog(new DateTime(year: 2018, month: 04, day: 21), "Roxy", 19.23f),
                new Dog(new DateTime(year: 2018, month: 05, day: 22), "Poly", 10.23f),
                new Dog(new DateTime(year: 2017, month: 05, day: 23), "Moly", 16.23f),
                new Dog(new DateTime(year: 2017, month: 06, day: 06), "Dory", 12.23f),
                new Dog(new DateTime(year: 2017, month: 04, day: 06), "Bonya", 14.56f),
                new Dog(new DateTime(year: 2016, month: 03, day: 04), "Lussi", 12.98f),
                new Cat(new DateTime(year: 2017, month: 11, day: 24), "Fifi", 12.99f),
                new Cat(new DateTime(year: 2016, month: 12, day: 30), "Muew", 12.7f),
                new Cat(new DateTime(year: 2015, month: 12, day: 11), "Roma", 18.28f),
                new Cat(new DateTime(year: 2018, month: 11, day: 22), "Ital", 13.93f),
                new Cat(new DateTime(year: 2019, month: 01, day: 11), "Canada", 17.53f),
                new Cat(new DateTime(year: 2019, month: 01, day: 06), "Nepal", 18.22f),
                new Cat(new DateTime(year: 2019, month: 01, day: 02), "China", 11.11f)
            };

            PetShop petShop = new PetShop(animals, 1000);
            return petShop;


        }

        public static int ShowMenu()
        {
            Console.WriteLine("What do you want?");
            Console.WriteLine("1.buy animal");
            Console.WriteLine("2.Sell animal");
            Console.WriteLine("3.Print assortiment");
            Console.WriteLine("4.Exit");
            

            int answer = EnterNumber();
            return answer;
        }

        public static void SellAnimal(PetShop petShop)
        {
            Console.WriteLine("Please, enter animal type:");
            Console.WriteLine("1.Dog");
            Console.WriteLine("2.Cat");
            int type = EnterNumber();
            var animalType = (AnimalType)type; //безопасное приведение типов

            Console.WriteLine("Please, enter animal name.");
            string name = Console.ReadLine();

            var soldAnimal = petShop.SellAnimal(animalType, name);
            Console.WriteLine($"Congratulations! You bought:");

            soldAnimal.Print();
        }
        public static void BuyAnimal(PetShop petShop)
        {
            Console.WriteLine("Please, enter animal type:");
            Console.WriteLine("1.Dog");
            Console.WriteLine("2.Cat");
            int type = EnterNumber();
            var animalType = (AnimalType)type;

            Console.WriteLine("Please, enter animal name");
            string name = Console.ReadLine();

            Console.WriteLine("Please, enter animal price");
            float price = EnterText(); 

            Console.WriteLine("Please, enter animal birthday");
            DateTime birthday = EnterData();

            var buyAnimal = petShop.BuyAnimal(animalType, name, price, birthday);
            Console.WriteLine("Thank you! We bought a new animal:");
            buyAnimal.Print();
        }

        public static int EnterNumber()
        {
            int value;
            while (true)
            {
                var answer = Console.ReadLine();
                if (int.TryParse(answer, out value))
                {
                    return value;
                }
                Console.WriteLine("Please, enter integer value");
            }
        }
        public static float EnterText()
        {
            float value;
            while (true)
            {
                var answer = Console.ReadLine();
                if (float.TryParse(answer, out value))
                {
                    return value;
                }
                Console.WriteLine("Please, enter integer value");
            }
        }
        public static DateTime EnterData()
        {
            DateTime value;
            while(true)
            {
                var answer = Console.ReadLine();
                if (DateTime.TryParse(answer, out value))
                {
                    return value;
                }
                Console.WriteLine("Please, enter integer value");
            }
        }
        
    }
}




// Нужно сделать для покупки животного, в котором надо написать Введите имя животного. После ответа должно показать 
//животное и купитьь его в магазине