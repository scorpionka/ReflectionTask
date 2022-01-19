namespace ReflectionConsoleApp.Providers.Interfaces
{
    public interface IConfigurationProviderCreator<T>
    {
        T LoadSettings(string settingName, ProviderType providerType);
        void SaveSettings(string settingName, ProviderType providerType, T value);
    }
}
