using System;

namespace dp_F_Mt_Computer_Creator_Csh
{


    public abstract class ComputerCreator
    {
        protected Comp comp;
        public ComputerCreator() : base()
        {
            // super();
        }
        public Comp Create()
        {
            comp = new Comp();

            comp.setProc(GetProcessor());
            comp.setKeys(GetKeyBoard());
            comp.setScreen(GetMonitor());
            comp.setName(GetName());
            return comp;
        }
        // Factory Methods
        public virtual Monitor GetMonitor()
        {
            return new Monitor(17, 10, 1.5f);
        }
        public virtual Processor GetProcessor()
        {
            return new Processor(1500, 300);
        }
        public virtual KeyBoard GetKeyBoard()
        {
            return new KeyBoard(102);
        }
        public virtual String GetName()
        {
            return "Computer";
        }
    }

    public class Monitor
    {
        protected int screenSize;
        protected int weight;
        protected float brightness;
        public Monitor(int screenSize, int weight, float brightness) : base()
        {
            this.screenSize = screenSize;
            this.weight = weight;
            this.brightness = brightness;
        }
        public float getBrightness()
        {
            return brightness;
        }
        public void setBrightness(float brightness)
        {
            this.brightness = brightness;
        }
        public int getScreenSize()
        {
            return screenSize;
        }
        public void setScreenSize(int screenSize)
        {
            this.screenSize = screenSize;
        }
        public int getWeight()
        {
            return weight;
        }
        public void setWeight(int weight)
        {
            this.weight = weight;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine("Monitor: ");
            Console.Write("screen size: ");
            Console.Write(screenSize);
            Console.Write(", weight: ");
            Console.Write(weight);
            Console.Write(", brightness: ");
            Console.WriteLine(brightness);
        }
    }
    public class KeyBoard
    {
        protected int keyNum = 101;
        public KeyBoard(int keyNum) : base()
        {
            this.keyNum = keyNum;
        }
        public int getKeyNum()
        {
            return keyNum;
        }
        public void setKeyNum(int keyNum)
        {
            this.keyNum = keyNum;
        }
        public virtual void PrintInfo()
        {
            Console.Write("KeyBoard: ");
            Console.Write(keyNum);
            Console.WriteLine(" keys");
        }
    }
    public class Processor
    {
        protected int freq;
        protected int bus;
        public Processor(int freq, int bus) : base()
        {
            this.freq = freq;
            this.bus = bus;
        }
        public int getBus()
        {
            return bus;
        }
        public void setBus(int bus)
        {
            this.bus = bus;
        }
        public int getFreq()
        {
            return freq;
        }
        public void setFreq(int freq)
        {
            this.freq = freq;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine("Processor: ");
            Console.Write("freq: ");
            Console.Write(freq);
            Console.Write(", bus: ");
            Console.WriteLine(bus);
        }
    }

    public class PentiumCreator : ComputerCreator
    {

        public override KeyBoard GetKeyBoard()
        {
            return new KeyBoardFull(111, true);
        }

        public override Processor GetProcessor()
        {
            return new Processor64(3500, 1000, 8);
        }

        public override String GetName()
        {
            return "Pentium";
        }
    }
    public class KeyBoardFull : KeyBoard
    {
        protected bool highlight = true;
        public KeyBoardFull(int keyNum, bool highlight) : base(keyNum)
        {
            this.highlight = highlight;
        }
        public bool isHighlight()
        {
            return highlight;
        }

        public override void PrintInfo()
        {
            Console.Write("KeyBoard: ");
            Console.Write(keyNum);
            Console.Write(" keys");
            Console.Write(", highlight: ");
            Console.WriteLine(highlight);
        }
    }
    public class Processor64 : Processor
    {
        int coreNum;
        public Processor64(int freq, int bus, int num) : base(freq, bus)
        {
            coreNum = num;
        }
        public int getCoreNum()
        {
            return coreNum;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Processor 64: ");
            Console.Write("freq: ");
            Console.Write(freq);
            Console.Write(", bus: ");
            Console.Write(bus);
            Console.Write(", cores: ");
            Console.WriteLine(coreNum);
        }
    }

    public class AMDCreator : ComputerCreator
    {


        public override Processor GetProcessor()
        {
            return new AMDSempron(3500, 1000, 8, 512);
        }

        public override Monitor GetMonitor()
        {
            return new LSDMonitor(19, 15, 1.8f);
        }

        public override String GetName()
        {
            return "AMD";
        }
    }
    public class AMDSempron : Processor
    {
        protected int L2Cache = 512;
        public AMDSempron(int freq, int bus, int num, int l2) : base(freq, bus)
        {
            L2Cache = l2;
        }
        public int getL2Cache()
        {
            return L2Cache;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Processor AMD Sempron: ");
            Console.Write("freq: ");
            Console.Write(freq);
            Console.Write(", bus: ");
            Console.Write(bus);
            Console.Write(", L2Cache: ");
            Console.WriteLine(L2Cache);
        }
    }
    public class LSDMonitor : Monitor
    {
        protected bool lsd = true;
        public LSDMonitor(int screenSize, int weight, float brightness) : base(screenSize, weight, brightness)
        {
        }
        public bool isLsd()
        {
            return lsd;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("LCD Monitor: ");
            Console.Write("screen size: ");
            Console.Write(screenSize);
            Console.Write(", weight: ");
            Console.Write(weight);
            Console.Write(", brightness: ");
            Console.WriteLine(brightness);
        }
    }

    public class Comp
    {
        protected Monitor monitor;
        protected Processor processor;
        protected KeyBoard keyBoard;
        protected String name;
        public void setProc(Processor p)
        {
            processor = p;
        }
        public void setKeys(KeyBoard k)
        {
            keyBoard = k;
        }
        public void setScreen(Monitor m)
        {
            monitor = m;
        }
        public void setName(String s)
        {
            name = s;
        }
        public void PrintInfo()
        {
            Console.WriteLine(name);
            monitor.PrintInfo();
            processor.PrintInfo();
            keyBoard.PrintInfo();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ComputerCreator cc = new AMDCreator();
            Comp comp = cc.Create();
            comp.PrintInfo();
            cc = new PentiumCreator();
            comp = cc.Create();
            comp.PrintInfo();


            Console.ReadKey();
        }
    }
}
