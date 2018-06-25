using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    /// <summary>
    /// Абстрактний клас Component
    /// </summary>
    abstract class Beverage
    {
        protected string description = "Unknown beverage";

        public virtual string GetDescription()
        {
            return description;
        }
        public abstract decimal Cost();
    }
    //Тепер опишемо класи конкретних видів кави, які пропонуються у кав'ярні. Всі вони будуть ConcreteComponent і тому наслідуються від Beverage.

    /// <summary>
    /// Реалізації ConcreteComponent
    /// </summary>
    class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "HouseBlend";
        }

        public override decimal Cost()
        {
            return 0.89M;
        }
    }

    class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            description = "DarkRoast";
        }

        public override decimal Cost()
        {
            return 0.99M;
        }
    }

    class Decaf : Beverage
    {
        public Decaf()
        {
            description = "Decaf";
        }

        public override decimal Cost()
        {
            return 1.05M;
        }
    }

    class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";
        }

        public override decimal Cost()
        {
            return 1.99M;
        }
    }
    // Після цього опишемо абстрактний клас CondimentDecorator, який наслідуватиметься від Beverage і міститиме посилання на об'єкт Beverage.

    /// <summary>
    /// Абстрактний клас Decorator
    /// </summary>
    abstract class CondimentDecorator : Beverage
    {
        private Beverage _beverage;

        public CondimentDecorator(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription();
        }

        public override decimal Cost()
        {
            return _beverage.Cost();
        }
    }
    // Тепер напишемо класи для конкретних доповнень, які будуть огортати об'єкти ConcreteComponent, і після відправлення запиту такому об'єкту виконуватимуть додаткові операції.

    /// <summary>
    /// Реалізація ConcreteDecorator (молоко)
    /// </summary>
    class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Milk";
        }

        public override decimal Cost()
        {
            return base.Cost() + 0.1M;
        }
    }

    /// <summary>
    /// Реалізація ConcreteDecorator (шоколад)
    /// </summary>
    class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Mocha";
        }

        public override decimal Cost()
        {
            return base.Cost() + 0.2M;
        }
    }

    /// <summary>
    /// Реалізація ConcreteDecorator (соя)
    /// </summary>
    class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Soy";
        }

        public override decimal Cost()
        {
            return base.Cost() + 0.15M;
        }
    }

    /// <summary>
    /// Реалізація ConcreteDecorator (вершки)
    /// </summary>
    class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Whip";
        }

        public override decimal Cost()
        {
            return base.Cost() + 0.1M;
        }
    }
    //І, нарешті, клієнтський код, у якому об'єкт типу Espresso декорується шоколадом і подвійними вершками.


    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо об'єкт типу Espresso
            Beverage espresso = new Espresso();

            // Огортаємо його шоколадом (Mocha)
            Beverage espressoMocha = new Mocha(espresso);

            // Попередньо огорнутий обєкт знову огортаємо, але тепер вершками (Whip)
            Beverage espressoMochaWhip = new Whip(espressoMocha);

            // Попередньо огорнутий обєкт огортаємо ще раз вершками (Whip)
            Beverage espressoMochaDoubleWhip = new Whip(espressoMochaWhip);

            // Виводимо опис напою і його вартість
            Console.WriteLine(espressoMochaDoubleWhip.GetDescription() + "\t" + espressoMochaDoubleWhip.Cost().ToString());

            Console.ReadKey();
        }
    }
}
//Виведення програми:

//Espresso, Mocha, Whip, Whip         2,39

