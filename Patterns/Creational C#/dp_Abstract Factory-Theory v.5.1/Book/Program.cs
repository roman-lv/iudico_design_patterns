using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public enum CustomerLocation { EastCoast, WestCoast }
    class Program
    {
        static void Main(string[] args)
        {
            IBookStore storeA = new BookStoreA(CustomerLocation.EastCoast);

            Console.WriteLine("Book Store A with a customer from East Coast:");
            ShipBook(storeA);
            Advertise(storeA);

            IBookStore storeB = new BookStoreB(CustomerLocation.WestCoast);
            Console.WriteLine("Book Store B with a customer from West Coast:");
            ShipBook(storeB);
            Advertise(storeB);


            /////////////////////
            Console.ReadKey();

        }

        //**** client code that does not need to be changed  ***
        private static void ShipBook(IBookStore s)
        {
            IDistributor d = s.GetDistributor();
            d.ShipBook();
        }

        //**** client code that does not need to be changed  ***
        private static void Advertise(IBookStore s)
        {
            IAdvertiser a = s.GetAdvertiser();
            a.Advertise();
        }
    }


    //the factory
    public interface IBookStore
    {
        IDistributor GetDistributor();
        IAdvertiser GetAdvertiser();
    }

    //concrete factory
    public class BookStoreA : IBookStore
    {
        private CustomerLocation location;

        public BookStoreA(CustomerLocation location)
        {
            this.location = location;
        }

        IDistributor IBookStore.GetDistributor()
        {
            //internal logic on which distributor to return
            //*** logic can be changed without changing the client code  ****
            switch (location)
            {
                case CustomerLocation.EastCoast:
                    return new EastCoastDistributor();
                case CustomerLocation.WestCoast:
                    return new WestCoastDistributor();
            }
            return null;
        }

        IAdvertiser IBookStore.GetAdvertiser()
        {
            //internal logic on which distributor to return
            //*** logic can be changed without changing the client code  ****
            switch (location)
            {
                case CustomerLocation.EastCoast:
                    return new RedAdvertiser();
                case CustomerLocation.WestCoast:
                    return new BlueAdvertiser();
            }
            return null;
        }
    }

    //concrete factory
    public class BookStoreB : IBookStore
    {
        private CustomerLocation location;

        public BookStoreB(CustomerLocation location)
        {
            this.location = location;
        }

        IDistributor IBookStore.GetDistributor()
        {
            //internal logic on which distributor to return
            //*** logic can be changed without changing the client code  ****
            switch (location)
            {
                case CustomerLocation.EastCoast:
                    return new EastCoastDistributor();
                case CustomerLocation.WestCoast:
                    return new WestCoastDistributor();
            }
            return null;
        }

        IAdvertiser IBookStore.GetAdvertiser()
        {
            //internal logic on which distributor to return
            //*** logic can be changed without changing the client code  ****
            switch (location)
            {
                case CustomerLocation.EastCoast:
                    return new BlueAdvertiser();
                case CustomerLocation.WestCoast:
                    return new RedAdvertiser();
            }
            return null;
        }
    }

    //the product
    public interface IDistributor
    {
        void ShipBook();
    }

    //concrete product
    public class EastCoastDistributor : IDistributor
    {
        void IDistributor.ShipBook()
        {
            Console.WriteLine("Book shipped by East Coast Distributor");
        }
    }

    //concrete product
    public class WestCoastDistributor : IDistributor
    {
        void IDistributor.ShipBook()
        {
            Console.WriteLine("Book shipped by West Coast Distributor");
        }
    }

    //the product
    public interface IAdvertiser
    {
        void Advertise();
    }

    //concrete product
    public class RedAdvertiser : IAdvertiser
    {
        void IAdvertiser.Advertise()
        {
            Console.WriteLine("Advertised by RedAdvertiser");
        }
    }

    //concrete product
    public class BlueAdvertiser : IAdvertiser
    {
        void IAdvertiser.Advertise()
        {
            Console.WriteLine("Advertised by BlueAdvertiser");
        }
    }
}
