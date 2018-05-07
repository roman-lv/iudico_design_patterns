using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggingProvider
{
    class Program
    {
        // інтерфейс із визначеною логікою логування, тобто Product
        interface ILogger
        {
            void LogMessage(string message);
            void LogError(string message);
            void LogVerboseInformation(string message);
        }
        // конкретна реалізація інтерфейсу логування, тобто ConcreteProduct
        class Log4NetLogger : ILogger
        {
            public void LogMessage(string message)
            {
                Console.WriteLine(string.Format("{0}: {1}", "Log4Net message", message));
            }

            public void LogError(string message)
            {
                Console.WriteLine(string.Format("{0}: {1}", "Log4Net error", message));
            }
            public void LogVerboseInformation(string message)
            {
                Console.WriteLine(string.Format("{0}: {1}", "Log4Net information", message));
            }
        }
        // конкретна реалізація інтерфейсу логування, тобто ConcreteProduct
        class EnterpriseLogger : ILogger
        {
            public void LogMessage(string message)
            {
                Console.WriteLine(string.Format("{0}: {1}", "EnterpriseLogger message", message));
            }
            public void LogError(string message)
            {
                Console.WriteLine(string.Format("{0}: {1}", "EnterpriseLogger error", message));
            }
            public void LogVerboseInformation(string message)
            {
                Console.WriteLine(string.Format("{0}: {1}", "EnterpriseLogger information", message));
            }
        }
        // Клас, що представляє собою фабрику по створенню об'єктів, тобто Creator
        class LoggerProviderFactory
        {
            // статичний параметризований фабричний метод
            public static ILogger GetLoggingProvider(LoggingProviders logProviders)
            {
                switch (logProviders)
                {
                    case LoggingProviders.Enterprise:
                        return new EnterpriseLogger();
                    case LoggingProviders.Log4Net:
                        return new Log4NetLogger();
                    default:
                        return new EnterpriseLogger();
                }
            }

            // функція вибору логінг провайдера
            private static LoggingProviders GetTypeOfLoggingProviderFromConfigFile()
            {
                //щоб не ускладнювати прикладу 
                return LoggingProviders.Log4Net;
            }

            // функція запуску для демонстрації
            public static void Run()
            {
                var providerType = GetTypeOfLoggingProviderFromConfigFile();
                ILogger logger = LoggerProviderFactory.GetLoggingProvider(providerType);
                logger.LogMessage("Hello Factory Method Design Pattern.");
            }
        }

        enum LoggingProviders
        {
            Enterprise,
            Log4Net
        };

        static void Main(string[] args)
        {
            LoggerProviderFactory.Run();

            Console.ReadKey();
        }
    }
}
