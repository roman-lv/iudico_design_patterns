using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeTest
{
    class SuperSmartTvController
    {
        static void Main(string[] args)
        {
            MySuperSmartTV myTv = new MySuperSmartTV();

            Console.WriteLine("Select A source to get TV Guide and Play");
            ConsoleKeyInfo input;
            do
            {
                Console.WriteLine("1. Local Cable TV\n2. Local Dish TV\n3. IP TV\n4. For turn off TV");

                input = Console.ReadKey();
                // Запитуємо у користувача, яке джерело прийому він хоче використовувати
                switch (input.KeyChar)
                {
                    case '1':
                        myTv.VideoSource = new LocalCabelTv();
                        break;
                    case '2':
                        myTv.VideoSource = new LocalDishTv();
                        break;
                    case '3':
                        myTv.VideoSource = new IPTvService();
                        break;
                    case '4':
                        Console.WriteLine("\nBye");
                        return;
                }
                Console.WriteLine();
                //Відображаємо TvGuide
                myTv.ShowTvGuide();
                //Працюємо з необхідним джерелом TV
                myTv.PlayTV();
                Console.WriteLine();
            }
            while (true);
        }
    }



    class MySuperSmartTV
    {
        IVideoSource currentVideoSource = null;

        public IVideoSource VideoSource
        {
            get
            {
                return currentVideoSource;
            }
            set
            {
                currentVideoSource = value;
            }
        }

        public void ShowTvGuide()
        {
            if (currentVideoSource != null)
            {
                Console.WriteLine(currentVideoSource.GetTvGuide());
            }
            else
            {
                Console.WriteLine("Please select a Video Source to get TV guide from");
            }
        }

        public void PlayTV()
        {
            if (currentVideoSource != null)
            {
                Console.WriteLine(currentVideoSource.PlayVideo());
            }
            else
            {
                Console.WriteLine("Please select a Video Source to play");
            }
        }

    }





    class LocalDishTv : IVideoSource
    {
        const string SOURCE_NAME = "Local DISH TV";

        string IVideoSource.GetTvGuide()
        {
            return string.Format("Getting TV guide from - {0}", SOURCE_NAME);
        }

        string IVideoSource.PlayVideo()
        {
            return string.Format("Playing - {0}", SOURCE_NAME);
        }
    }




    class LocalCabelTv : IVideoSource
    {
        const string SOURCE_NAME = "Local Cabel TV";

        string IVideoSource.GetTvGuide()
        {
            return string.Format("Getting TV guide from - {0}", SOURCE_NAME);
        }

        string IVideoSource.PlayVideo()
        {
            return string.Format("Playing - {0}", SOURCE_NAME);
        }
    }





    interface IVideoSource
    {
        string GetTvGuide();
        string PlayVideo();
    }





    class IPTvService : IVideoSource
    {
        const string SOURCE_NAME = "IP TV";

        string IVideoSource.GetTvGuide()
        {
            return string.Format("Getting TV guide from - {0}", SOURCE_NAME);
        }

        string IVideoSource.PlayVideo()
        {
            return string.Format("Playing - {0}", SOURCE_NAME);
        }
    }

}