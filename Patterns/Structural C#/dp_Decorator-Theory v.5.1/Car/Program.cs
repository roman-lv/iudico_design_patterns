using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    // Базовий клас автомобіля 
    class Car
    {
        protected String BrandName { get; set; }
        public virtual void Go()
        {
            Console.WriteLine("I'm " + BrandName + " and I'm on my way...");
        }
    }

    // Конкретна реалізація класу Car
    class Mercedes : Car
    {
        public Mercedes()
        {
            BrandName = "Mercedes";
        }
    }
    // Для того, щоб зберегти контракт базового класу Car і мати базовий клас для всіх інших «прибамбасних» функціональностей, створюється CarDecorator, що так само наслідується від Car.

    // Втілення патерну Decorator - абстраткний клас для всіх класів Decorator
    abstract class DecoratorCar : Car
    {
        protected Car DecoratedCar { get; set; }
        public DecoratorCar(Car decoratedCar)
        {
            DecoratedCar = decoratedCar;
        }
        public override void Go()
        {
            DecoratedCar.Go();
        }
    }

    //Цей клас агрегує справжній автомобіль, або іншими словами обгортає DecoratedCar.
    //Додаткова функціональність може бути додана до будь-якої машини(чи то "Mercedes" чи то "BMW"), наслідуючися від класу CarDecorator.Нижче подано приклад простого розширення сигналу.

    //«Декор» карети швидкої допомоги 
    class AmbulanceCar : DecoratorCar
    {
        public AmbulanceCar(Car decoratedCar)
            : base(decoratedCar)
        {
        }
        public override void Go()
        {
            base.Go();
            Console.WriteLine("... beep-beep-beeeeeep ...");
        }
    }
    // Використання виглядає наступним чином - мерседес декорується особливостями швидкої і здійснюється мрія лікаря.Опісля цей об’єкт може бути продекорований ще якимись можливостями і, що важливо, це все може бути зроблено динамічно. Сниться лікарю сигнал – передаємо його мерседес в конструктор об'єкту AmbulanceCar, а сниться йому кулемет на даху автомобіля – передаємо у декоратор ArmorCar. Саме тому в таких випадках доцільно використовувати патерн Decorator.

    //Використання патерну 
    class Program
    {
        static void Main(string[] args)
        {
            var doctorsDream = new AmbulanceCar(new Mercedes());
            doctorsDream.Go();
            Console.ReadKey();
        }
    }
}

//Виведення програми:
//I'm Mercedes and I'm on my way...
//...beep-beep-beeeeeep...
