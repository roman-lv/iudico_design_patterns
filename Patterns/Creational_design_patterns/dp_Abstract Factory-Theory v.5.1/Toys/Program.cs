using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    // абстрактна фабрика (abstract factory)
    interface IToyFactory
    {
        Bear GetBear();
        Cat GetCat();
    }
    // конкретна фабрика (concrete factory)
    class TeddyToysFactory : IToyFactory
    {
        public Bear GetBear()
        {
            return new TeddyBear();
        }
        public Cat GetCat()
        {
            return new TeddyCat();
        }
    }
    // і ще одна конкретна фабрика
    class WoodenToysFactory : IToyFactory
    {
        public Bear GetBear()
        {
            return new WoodenBear();
        }
        public Cat GetCat()
        {
            return new WoodenCat();
        }
    }

    abstract class AnimalToy
    {
        public string Name { get; set; }
        public AnimalToy(string name)
        {
            this.Name = name;
        }
    }

    abstract class Cat : AnimalToy
    {
        protected Cat(string name) : base(name) { }
    }
    // Базовий клас для усіх ведмедиків
    abstract class Bear : AnimalToy
    {
        protected Bear(string name) : base(name) { }
    }
    // Конкретні реалізації
    class WoodenCat : Cat
    {
        public WoodenCat() : base("Wooden Cat") { }
    }
    class TeddyCat : Cat
    {
        public TeddyCat() : base("Teddy Cat") { }
    }
    class WoodenBear : Bear
    {
        public WoodenBear() : base("Wooden Bear") { }
    }
    class TeddyBear : Bear
    {
        public TeddyBear() : base("Teddy Bear") { }
    }



    class Program
    {
        static void Main(string[] args)
        {
            // Спочатку створимо «дерев'яну» фабрику
            IToyFactory woodenToyFactory = new WoodenToysFactory();
            Bear woodenBear = woodenToyFactory.GetBear();
            Cat woodenCat = woodenToyFactory.GetCat();
            Console.WriteLine("I've got {0} and {1}", woodenBear.Name, woodenCat.Name);
            // Вивід на консоль буде: [I've got Wooden Bear and Wooden Cat]
            // А тепер створимо «плюшеву» фабрику, наступна лінійка є єдиною різницею в коді
            IToyFactory teddyToyFactory = new TeddyToysFactory();
            // Як бачимо код нижче не відрізняється від наведеного вище
            Bear teddyBear = teddyToyFactory.GetBear();
            Cat teddyCat = teddyToyFactory.GetCat();
            Console.WriteLine("I've got {0} and {1}", teddyBear.Name, teddyCat.Name);
            // А вивід на консоль буде інший: [I've got Teddy Bear and Teddy Cat]
            // Базовий клас для усіх котиків, базовий клас AnimalToy містить Name

            //Wait for user key
            Console.ReadKey();
        }
    }
}
