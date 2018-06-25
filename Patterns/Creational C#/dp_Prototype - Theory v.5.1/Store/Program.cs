using System;

namespace Store
{

    public static class StoreCreator
    {
        public static IStorePrototype CreateSimpleStore()
        {
            return new Store
            {
                NumberOfFloors = 1,
                NumberOfCheckoutCounters = 1,
                OpenAllDay = false
            } as IStorePrototype;
        }

        public static IStorePrototype CreateSuperStore()
        {
            return new Store
            {
                NumberOfFloors = 2,
                NumberOfCheckoutCounters = 10,
                OpenAllDay = true
            } as IStorePrototype;
        }
    }
    


// Клас Prototype
    public interface IStorePrototype
    {
        IStorePrototype Clone();
        void Print();
    }

// Клас ConcretePrototype
public class Store : IStorePrototype
    {
        public bool OpenAllDay { get; set; }
        public string Address { get; set; }
        public int NumberOfCheckoutCounters { get; set; }
        public int NumberOfFloors { get; set; }

        public void Print()
        {
            Console.WriteLine("Adress: \t{0}", Address);
            Console.WriteLine("Number of floors: \t{0}", NumberOfFloors);
            Console.WriteLine("Number of checkout counters: \t{0}", NumberOfCheckoutCounters);
            Console.WriteLine("Open all day: \t{0}\n", OpenAllDay);
        }

        public IStorePrototype Clone()
        {
            return new Store
            {
                NumberOfCheckoutCounters = this.NumberOfCheckoutCounters,
                NumberOfFloors = this.NumberOfFloors,
                OpenAllDay = this.OpenAllDay
            } as IStorePrototype;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IStorePrototype store1 = StoreCreator.CreateSimpleStore();
            (store1 as Store).Address = "adress1";
            store1.Print();

            IStorePrototype store2 = StoreCreator.CreateSuperStore();
            (store2 as Store).Address = "adress2";
            store2.Print();

            Store store3 = StoreCreator.CreateSuperStore() as Store;
            store3.NumberOfCheckoutCounters = 8;
            store3.OpenAllDay = false;
            store3.NumberOfFloors = 5;
            store3.Address = "adress3";
            store3.Print();

            IStorePrototype store4 = store3.Clone();
            (store4 as Store).Address = "adress4";
            store4.Print();

            
            Console.ReadKey();
        }
    }

    //Вивід програми:

    //Adress:         adress1
    //Number of floors:       1
    //Number of checkout counters:    1
    //Open all day:   False

    //Adress:         adress2
    //Number of floors:       2
    //Number of checkout counters:    10
    //Open all day:   True

    //Adress:         adress3
    //Number of floors:       5
    //Number of checkout counters:    8
    //Open all day:   False

    //Adress:         adress4
    //Number of floors:       5
    //Number of checkout counters:    8
    //Open all day:   False

}
