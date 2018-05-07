using System;

namespace Template
{
    abstract class CProduct // Product
    {
        public abstract void GetName();
    };

    class CTable : CProduct // ConcreteProduct1
    {
        public override void GetName()
        {
            Console.WriteLine("It's a table!");
        }
    };

    class CChair : CProduct // ConcreteProduct2
    {
        public override void GetName()
        {
            Console.WriteLine("It's a chair!");
        }
    };

    class CBed : CProduct // ConcreteProduct3
    {
        public override void GetName()
        {
            Console.WriteLine("It's a bed!");
        }
    };


    abstract class CCreator // Creator
    {
        public abstract CProduct CreateProduct();
    };


    class TCreator<TheProduct> : CCreator where TheProduct : CProduct, new() // ConcreteCreator
    {
        public override CProduct CreateProduct()
        {
            return new TheProduct();
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            CCreator pCreator = new TCreator<CTable>();
            CProduct pConcreteProduct = pCreator.CreateProduct();
            pConcreteProduct.GetName();


            Console.ReadKey();
        }
    }
}
