using ReflectionConsoleApp.Attributes;
using ReflectionConsoleApp.Providers.Interfaces;

namespace ReflectionConsoleApp.Configurations
{
    public class ConfigurationComponentIntValue : ConfigurationComponentBase<int>
    {
        public ConfigurationComponentIntValue(IConfigurationProviderCreator configurationProvider) : base(configurationProvider)
        {
        }

        [ConfigurationItem("IntValue", Providers.ProviderType.File)]
        public new int Value { get; set; }
    }
}
