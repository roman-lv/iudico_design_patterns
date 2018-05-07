using System;
using System.Collections.Generic;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Strategy_Game
{

    // Абстрактні базові класи всіх можливих видів воїнів
    public abstract class Infantryman
    {
        public abstract void info();
    };

    public abstract class Archer
    {
        public abstract void info();
    };

    public abstract class Horseman
    {
        public abstract void info();
    };


    // Класи всіх видів воїнів Римської армії
    class RomanInfantryman : Infantryman
    {
        public override void info()
        {
            Console.WriteLine("RomanInfantryman");
        }
    };

    class RomanArcher : Archer
    {
        public override void info()
        {
            Console.WriteLine("RomanArcher");
        }
    };

    class RomanHorseman : Horseman
    {
        public override void info()
        {
            Console.WriteLine("RomanHorseman");
        }
    };


    // Класи всіх видів воїнів армії Карфагена
    class CarthaginianInfantryman : Infantryman
    {
        public override void info()
        {
            Console.WriteLine("CarthaginianInfantryman");
        }
    };

    class CarthaginianArcher : Archer
    {
        public override void info()
        {
            Console.WriteLine("CarthaginianArcher");
        }
    };

    class CarthaginianHorseman : Horseman
    {
        public override void info()
        {
            Console.WriteLine("CarthaginianHorseman");
        }
    };


    // Абстрактна фабрика для створення воїнів
    abstract class ArmyFactory
    {
        public abstract Infantryman createInfantryman();
        public abstract Archer createArcher();
        public abstract Horseman createHorseman();
    };


    // Фабрика для створення воїнів Римської армії
    class RomanArmyFactory : ArmyFactory
    {
        public override Infantryman createInfantryman()
        {
            return new RomanInfantryman();
        }
        public override Archer createArcher()
        {
            return new RomanArcher();
        }
        public override Horseman createHorseman()
        {
            return new RomanHorseman();
        }
    };


    // Фабрика для створення воїнів армії Карфагена
    class CarthaginianArmyFactory : ArmyFactory
    {
        public override Infantryman createInfantryman()
        {
            return new CarthaginianInfantryman();
        }
        public override Archer createArcher()
        {
            return new CarthaginianArcher();
        }
        public override Horseman createHorseman()
        {
            return new CarthaginianHorseman();
        }
    };


    // Клас, який містить всіх воїнів обох армій
    class Army
    {
        public void info()
        {
            int i;
            for (i = 0; i < vi.Count; ++i) vi[i].info();
            for (i = 0; i < va.Count; ++i) va[i].info();
            for (i = 0; i < vh.Count; ++i) vh[i].info();
        }
        public List<Infantryman> vi = new List<Infantryman>();
        public List<Archer> va = new List<Archer>();
        public List<Horseman> vh = new List<Horseman>();
        /////////////////////////////////////////////////////////////////////
        ////////////////////List -> Vector//////////////////////////////
        ////////////////////////////////////////////////////////////////////
    };


    // Створення армії 
    class Game
    {
        public Army createArmy(ArmyFactory factory)
        {
            Army p = new Army();
            p.vi.Add(factory.createInfantryman());
            p.va.Add(factory.createArcher());
            p.vh.Add(factory.createHorseman());
            return p;
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            RomanArmyFactory ra_factory = new RomanArmyFactory();
            CarthaginianArmyFactory ca_factory = new CarthaginianArmyFactory();

            Army ra = game.createArmy(ra_factory);
            Army ca = game.createArmy(ca_factory);
            Console.WriteLine("Roman army:");
            ra.info();
            Console.WriteLine();
            Console.WriteLine("Carthaginian army:");
            ca.info();

            Console.ReadKey();
            // ...
        }
    }
    //Вивід програми:

    //Roman army:
    //RomanInfantryman
    //RomanArcher
    //RomanHorseman

    //Carthaginian army:
    //CarthaginianInfantryman
    //CarthaginianArcher
    //CarthaginianHorseman



}
