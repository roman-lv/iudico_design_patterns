using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_Game
{
    /// <summary>
    /// Basic class for all elements
    /// </summary>
    public class GameElement
    {
        public int pos;
        public string name;
        public GameElement(int pos, string name)
        {
            this.pos = pos;
            this.name = name;
        }
        public override string ToString()
        {
            return "Element: \"" + name + "\" Is at position: " + pos.ToString();
        }
    }
    /// <summary>
    /// Base class for all blocks. 
    /// </summary>
    public abstract class Block : GameElement
    {
        protected Block(int pos, string name) : base(pos, name) { }
    }
    /// <summary>
    /// Basic alsss for all marios
    /// </summary>
    public abstract class Mario : GameElement
    {
        protected Mario(int pos, string name) : base(pos, name) { }
    }
    /// <summary>
    /// Factory interface
    /// </summary>
    public interface IGameFactory
    {
        Block CreateBlock(int pos);
        Mario CreateMario(int pos);
    }
    /// <summary>
    /// New block item
    /// </summary>
    class NewBlock : Block
    {
        public NewBlock(int pos) : base(pos, "New Block") { }
    }
    /// <summary>
    /// New mario item inherited from abstract Mario class
    /// </summary>
    class NewMario : Mario
    {
        public NewMario(int pos) : base(pos, "New Mario") { }
    }
    /// <summary>
    /// Factory for old items that implements iterface IBlockFactory
    /// </summary>
    public class NewGameFactory : IGameFactory
    {
        public Mario CreateMario(int pos)
        {
            return new NewMario(pos);
        }
        public Block CreateBlock(int pos)
        {
            return new NewBlock(pos);
        }
    }
    /// <summary>
    /// Old block item
    /// </summary>
    class OldBlock : Block
    {
        public OldBlock(int pos) : base(pos, "Old Block") { }
    }
    /// <summary>
    /// Concrete mario class(old style).
    /// </summary>
    class OldMario : Mario
    {
        public OldMario(int pos) : base(pos, "Old Mario") { }
    }
    /// <summary>
    /// Concrete factory for old elements.
    /// </summary>
    public class OldGameFactory : IGameFactory
    {
        public Mario CreateMario(int pos)
        {
            return new OldMario(pos);
        }
        public Block CreateBlock(int pos)
        {
            return new OldBlock(pos);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Here we crete factory for new game elements
            IGameFactory F = new NewGameFactory();
            //create game elements from our freshly created factory. We can be shure that all this items will be new-styled.
            Block block = F.CreateBlock(1);
            Mario mario = F.CreateMario(0);
            //Write into console to inshure we created right items.
            Console.WriteLine(block.ToString());
            Console.WriteLine(mario.ToString());

            //Now set factory to create old fashioned elements
            F = new OldGameFactory();
            //Create old items. 
            block = F.CreateBlock(2);
            mario = F.CreateMario(3);
            //Write old items.
            Console.WriteLine(block.ToString());
            Console.WriteLine(mario.ToString());

            //Fait for user key.
            Console.ReadKey();
        }
    }
    //Вивід програми:

    //Element: "New Block" Is at position: 1
    //Element: "New Mario" Is at position: 0
    //Element: "Old Block" Is at position: 2
    //Element: "Old Mario" Is at position: 3


}
