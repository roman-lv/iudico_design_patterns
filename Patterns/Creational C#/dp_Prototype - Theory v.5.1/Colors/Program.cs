using System;
using System.Collections.Generic;

namespace Colors
{

    /// <summary>
    /// Інтерефейс Prototype
    /// </summary>
    public interface IColorPrototype
    {
        IColorPrototype Clone();
    }

    /// <summary>
    /// Клас ConcretePrototype
    /// </summary>
    public class Color : IColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;

        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        // Реалізуємо клонування поверненням поверхневої копії об'єкта
        public IColorPrototype Clone()
        {
            // Виводимо повідомлення про клонування
            Console.WriteLine("Cloning color RGB: ({0,3}, {1,3}, {2,3})\n", _red, _green, _blue);
            return this.MemberwiseClone() as IColorPrototype;
        }
    }

    /// <summary>
    /// Диспетчер прототипів
    /// </summary>
    public class ColorManager
    {
        private static Dictionary<string, IColorPrototype> colors =
              new Dictionary<string, IColorPrototype>();

        // Додаємо до диспетчера стандартні кольори
        static ColorManager()
        {
            colors.Add("red", new Color(255, 0, 0));
            colors.Add("green", new Color(0, 255, 0));
            colors.Add("blue", new Color(0, 0, 255));
        }

        // Індексатор для отримання і додавання прототипів
        public IColorPrototype this[string key]
        {
            get { return colors[key]; }
            set { colors.Add(key, value); }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            // Створення екземляру ColorManager
            ColorManager colormanager = new ColorManager();

            // Додавання власних кольорів користувачем:
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // Запит користуачем кольорів
            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;


            Console.ReadKey();
        }
    }

    //Вивід програми:

    //Cloning color RGB: (255,   0,   0)
    //Cloning color RGB: (128, 211, 128)
    //Cloning color RGB: (211,  34,  20)


}