using System.Reflection;

namespace Providers.Providers.Interfaces
{
    public interface IConfigurationProviderCreator
    {
        object LoadSettings(PropertyInfo propertyInfo, ProviderType providerType);
        void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue, ProviderType providerType);
    }
}
