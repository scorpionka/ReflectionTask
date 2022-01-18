namespace ReflectionConsoleApp.Providers.Interfaces
{
    public interface IConfigurationProviderCreator
    {
        void LoadSettings(string settingName, ProviderType providerType);
        void SaveSetting(string settingName, ProviderType providerType);
    }
}
