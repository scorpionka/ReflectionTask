using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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

            ConfigurationComponentBase configurationComponentBase = new(new ConfigurationProviderCreator());


            ConfigurationSettings configurationSettings = new ConfigurationSettings();

            configurationSettings.IntValue = 3;
            configurationSettings.FloatValue = 1.25F;
            configurationSettings.StringValue = "hello";
            configurationSettings.TimeSpanValue = TimeSpan.FromSeconds(1);

            configurationComponentBase.SaveSettings(configurationSettings);

            configurationComponentBase.LoadSettings(configurationSettings);
        }
    }
}
