using System;
namespace dp_Adapter___Theory_v._5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();

            Auto auto = new Auto();

            driver.Travel(auto);

            Airliner Airliner = new Airliner();

            ITransport AirlinerTransport = new AirlinerToTransportAdapter(Airliner);

            driver.Travel(AirlinerTransport);

            Console.ReadKey();
        }
    }
    interface ITransport
    {
        void Drive();
    }
    // клас машини
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Car...");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    // інтерфейс літака
    interface IPlane
    {
        void Fly();
    }
    // клас пасажирського літака
    class Airliner : IPlane
    {
        public void Fly()
        {
            Console.WriteLine("Airliner...");
        }
    }
    // Адаптер від Airliner до ITransport
    class AirlinerToTransportAdapter : ITransport
    {
        Airliner Airliner;
        public AirlinerToTransportAdapter(Airliner c)
        {
            Airliner = c;
        }

        public void Drive()
        {
            Airliner.Fly();
        }
    }

}

