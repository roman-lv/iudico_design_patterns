using System;

namespace Example_2
{
    //************************************************ 
    //                                          Object 
    // клас складної структури
    class Laptop        // Object
    {
        public string MonitorResolution { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string HDD { get; set; }
        public string Battery { get; set; }
    }
    //************************************************ 


    //************************************************ 
    //                                 AbstructBuilder 
    // абстрактний будівельник Laptop
    abstract class LaptopBuilder      // AbstructBuilder 
    {
        protected Laptop Laptop { get; private set; }
        // створення та отримання об'єкта Laptop
        public void CreateNewLaptop()
        {
            Laptop = new Laptop();
        }
        public Laptop GetLaptop()
        {
            return Laptop;
        }
        // методи, необхідні для встановлення компонент Laptop
        public abstract void SetMonitorResolution();
        public abstract void SetProcessor();
        public abstract void SetMemory();
        public abstract void SetHDD();
        public abstract void SetBattery();
    }
    //************************************************ 


    //************************************************ 
    //                                 ConcreteBuilder  
    // Laptop для обробки та монтажу відео
    class VideoMontageLaptopBuilder : LaptopBuilder      // ConcreteBuilder 
    {
        public override void SetMonitorResolution()
        {
            Laptop.MonitorResolution = "1900x1200";
        }
        public override void SetProcessor()
        {
            Laptop.Processor = "Core i7, 3.9 GHz";
        }
        public override void SetMemory()
        {
            Laptop.Memory = "8 Gb";
        }
        public override void SetHDD()
        {
            Laptop.HDD = "2 Tb";
        }
        public override void SetBattery()
        {
            Laptop.Battery = "6 lbs";
        }
    }

    // Laptop для домашньої роботи
    class HomeLaptopBuilder : LaptopBuilder              // ConcreteBuilder 
    {
        public override void SetMonitorResolution()
        {
            Laptop.MonitorResolution = "1900x800";
        }
        public override void SetProcessor()
        {
            Laptop.Processor = "Core i3, 3.1 GHz";
        }
        public override void SetMemory()
        {
            Laptop.Memory = "4 Gb";
        }
        public override void SetHDD()
        {
            Laptop.HDD = "1 Tb";
        }
        public override void SetBattery()
        {
            Laptop.Battery = "4 lbs";
        }
    }
    //************************************************ 


    //************************************************ 
    //                                        Director 
    // директор
    class BuyLaptop                // Director 
    {
        private LaptopBuilder _laptopBuilder;
        public void SetLaptopBuilder(LaptopBuilder lBuilder)
        {
            _laptopBuilder = lBuilder;
        }
        public Laptop GetLaptop()
        {
            return _laptopBuilder.GetLaptop();
        }

        // побудувати Laptop
        public void ConstructLaptop()
        {
            _laptopBuilder.CreateNewLaptop();
            _laptopBuilder.SetMonitorResolution();
            _laptopBuilder.SetProcessor();
            _laptopBuilder.SetMemory();
            _laptopBuilder.SetHDD();
            _laptopBuilder.SetBattery();
        }
    }
    //************************************************ 


    //************************************************ 
    //                                            Main  
    static class Example
    {
        public static void Main()
        {
            // будівельники
            var hBuilder = new HomeLaptopBuilder();
            var vmBuilder = new VideoMontageLaptopBuilder();
            // директор 
            var shop = new BuyLaptop();

            // купити Laptop для домашнього використання
            shop.SetLaptopBuilder(hBuilder);
            shop.ConstructLaptop();
            Laptop laptop = shop.GetLaptop();

            // вивід результату
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", laptop.MonitorResolution,
                laptop.Processor, laptop.Memory, laptop.HDD, laptop.Battery);

            // подальше використання laptop
            // ...

            //Wait for user key
            Console.ReadKey();
        }
    }
    //************************************************ 
}

//Вивід програми:

//1900x800, Core i3, 3.1 GHz, 4 Gb, 1 Tb, 4 lbs