using ReflectionConsoleApp.Configurations;
using ReflectionConsoleApp.Providers;
using System;

namespace ReflectionConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConfigurationComponentBase<object> configurationComponentBase = new(new ConfigurationProviderCreator<object>());

            Console.WriteLine(configurationComponentBase.LoadSettings("IntValue"));

            configurationComponentBase.LoadSettings("FloatValue");

            configurationComponentBase.LoadSettings("StringValue");

            configurationComponentBase.LoadSettings("TimeSpanValue");
        }
    }
}
