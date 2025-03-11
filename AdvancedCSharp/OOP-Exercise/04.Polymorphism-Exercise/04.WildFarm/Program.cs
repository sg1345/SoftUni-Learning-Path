using _04.WildFarm.Abstraction;
using _04.WildFarm.Animal_Classes;
using _04.WildFarm.Animal_Classes.Birds;
using _04.WildFarm.Animal_Classes.Mammal;
using _04.WildFarm.Animal_Classes.Mammal.Feline;

namespace _04.WildFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Bird bird = new Hen("Goshko", 2.1, 2.1);
            //IFood vegetable = new Vegetable(10);
            //bird.Eat(vegetable);
            //Console.WriteLine(bird);

            List<IAnimal> listOfAnimals = new List<IAnimal>();

            string command;
            while((command = Console.ReadLine()!) != "End")
            {
                string[] animalData = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IAnimal? animal = CreateAnimal(animalData);

                if (animal == null) 
                    continue;

                Console.WriteLine(animal.MakeSound());
                //animal.MakeSound();

                string[] foodData = Console.ReadLine()!
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IFood? food = CreateFood(foodData);

                if (food == null) 
                    continue;

                animal.Eat(food);

                listOfAnimals.Add(animal);
            }

            foreach(IAnimal animal in listOfAnimals)
            {
                Console.WriteLine(animal);
            }
        }

        private static IFood? CreateFood(string[] foodData)
        {
            string foodType = foodData[0];
            int foodQuantity = int.Parse(foodData[1]);

            return foodType switch
            {
                $"{nameof(Vegetable)}" => new Vegetable(foodQuantity),
                $"{nameof(Fruit)}" => new Fruit(foodQuantity),
                $"{nameof(Meat)}" => new Meat(foodQuantity),
                $"{nameof(Seeds)}" => new Seeds(foodQuantity),
                _ => null
            };
        }

        private static IAnimal? CreateAnimal(string[] animalData)
        {
            return animalData[0] switch
            {
                $"{nameof(Owl)}" => CreateOwl(animalData),
                $"{nameof(Hen)}" => CreateHen(animalData),
                $"{nameof(Mouse)}" => CreateMouse(animalData),
                $"{nameof(Dog)}" => CreateDog(animalData),
                $"{nameof(Cat)}" => CreateCat(animalData),
                $"{nameof(Tiger)}" => CreateTiger(animalData),
                _ => null
            };
        }

        private static Owl CreateOwl(string[] animalData)
        {
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);
            double wingSize = double.Parse(animalData[3]);

            return new Owl(name, weight, wingSize);
        }

        private static Hen CreateHen(string[] animalData)
        {
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);
            double wingSize = double.Parse(animalData[3]);

            return new Hen(name, weight, wingSize);
        }

        private static Mouse CreateMouse(string[] animalData)
        {
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);
            string livingRegion = animalData[3];

            return new Mouse(name, weight, livingRegion);
        }

        private static Dog CreateDog(string[] animalData)
        {
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);
            string livingRegion = animalData[3];

            return new Dog(name, weight, livingRegion);
        }

        private static Cat CreateCat(string[] animalData)
        {
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);
            string livingRegion = animalData[3];
            string breed = animalData[4];

            return new Cat(name,weight,livingRegion, breed);
        }

        private static Tiger CreateTiger(string[] animalData)
        {
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);
            string livingRegion = animalData[3];
            string breed = animalData[4];

            return new Tiger(name, weight, livingRegion, breed);
        }
    }
}
