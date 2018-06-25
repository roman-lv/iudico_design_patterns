using System;
using System.Collections.Generic;

namespace Shapes
{
    /// <summary>
    /// Інтерфейс Prototype для геометричних фігур
    /// </summary>
    public interface IShape
    {
        void Draw();
        IShape Clone();
    }
    /// <summary>
    /// Клас ConcretePrototype прямокутника
    /// </summary>
    public class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        // Виводить інформацію про об'єкт
        public void Draw()
        {
            Console.WriteLine("Drawing Rectangle with width = {0} and height = {1}", Width, Height);
        }

        // Повертає поверхневу копію об'єкта
        public IShape Clone()
        {
            return this.MemberwiseClone() as IShape;
        }
    }

    /// <summary>
    /// Клас ConcretePrototype квадрата
    /// </summary>
    public class Square : IShape
    {
        public int Length { get; set; }

        public Square(int length)
        {
            Length = length;
        }

        // Виводить інформацію про об'єкт
        public void Draw()
        {
            Console.WriteLine("Drawing Square with length = {0}", Length);
        }

        // Повертає поверхневу копію об'єкта
        public IShape Clone()
        {
            return this.MemberwiseClone() as IShape;
        }
    }

    /// <summary>
    /// Клас ConcretePrototype кола
    /// </summary>
    public class Circle : IShape
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        // Виводить інформацію про об'єкт
        public void Draw()
        {
            Console.WriteLine("Drawing Circle with radius = {0}", Radius);
        }

        // Повертає поверхневу копію об'єкта
        public IShape Clone()
        {
            return this.MemberwiseClone() as IShape;
        }
    }
    /// <summary>
    /// Фабрика прототипів 
    /// </summary>
    public static class ShapeFactory
    {
        // Сховище для прототипів
        private static Dictionary<string, IShape> prototypes = new Dictionary<string, IShape>();

        // Наповнення словника прототипами
        static ShapeFactory()
        {
            prototypes.Add("Rectangle", new Rectangle(100, 50));
            prototypes.Add("Square", new Square(100));
            prototypes.Add("Circle", new Circle(50));
        }

        // Отримання вказаної копії прототипу
        public static IShape GetShape(string type)
        {
            return prototypes[type].Clone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            // Отримання копії прототипу Rectangle
            IShape rectanglePrototype = ShapeFactory.GetShape("Rectangle");
            rectanglePrototype.Draw();

            // Отримання копії прототипу Square          
            IShape squarePrototype = ShapeFactory.GetShape("Square");
            squarePrototype.Draw();

            // Отримання копії прототипу Circle
            IShape circlePrototype = ShapeFactory.GetShape("Circle");
            circlePrototype.Draw();

            // Зміна отриманої копії прототипу Circle
            (circlePrototype as Circle).Radius = 100;
            circlePrototype.Draw();


            Console.ReadKey();
        }
    }
    //Вивід програми:

    //Drawing Rectangle with width = 100 and height = 50
    //Drawing Square with length = 100
    //Drawing Circle with radius = 50
    //Drawing Circle with radius = 100



}