using System.Configuration;
using MultiAgentWinFormsApp.Extensions;

namespace MultiAgentWinFormsApp
{
    public class Section : ConfigurationSection
    {
        private static volatile ConfigurationProperty? s_propAppSettings;

        public Section(ConfigurationSection configurationSection)
            : base()
        {
            if (configurationSection == null)
                throw new ArgumentNullException(nameof(configurationSection));

            SectionInformation.SetRawXml(configurationSection.SectionInformation.GetRawXml());
            SectionInformation.ConfigSource = configurationSection.SectionInformation.ConfigSource;

            SectionInformation.SetPropertyUsingReflection("ConfigKey", configurationSection.SectionInformation.SectionName);
            SectionInformation.SetPropertyUsingReflection("Name", configurationSection.SectionInformation.Name);

            var configSourceStreamName = configurationSection.SectionInformation.GetPropertyUsingReflection<SectionInformation, string>("ConfigSourceStreamName");
            SectionInformation.SetPropertyUsingReflection("ConfigSourceStreamName", configSourceStreamName);

            var rawXml = configurationSection.SectionInformation.GetPropertyUsingReflection<SectionInformation, string>("RawXml");
            SectionInformation.SetPropertyUsingReflection("RawXml", rawXml);

            var protectionProviderName = configurationSection.SectionInformation.GetPropertyUsingReflection<SectionInformation, string>("ProtectionProviderName");
            SectionInformation.SetPropertyUsingReflection("ProtectionProviderName", protectionProviderName);

            var configRecord = configurationSection.SectionInformation.GetFieldUsingReflection<SectionInformation, object>("_configRecord");
            SectionInformation.SetFieldUsingReflection("_configRecord", configRecord);

            var factoryRecord = configurationSection.SectionInformation.CallMethodUsingReflection("FindParentFactoryRecord", false);
            if (factoryRecord != null)
            {
                var factoryTypeName = factoryRecord.GetPropertyUsingReflection<object, string>("FactoryTypeName");
                SectionInformation.SetFieldUsingReflection("_typeName", factoryTypeName);

                var allowDefinition = factoryRecord.GetPropertyUsingReflection<object, bool>("AllowDefinition");
                SectionInformation.SetFieldUsingReflection("_allowDefinition", allowDefinition);

                var allowExeDefinition = factoryRecord.GetPropertyUsingReflection<object, bool>("AllowExeDefinition");
                SectionInformation.SetFieldUsingReflection("_allowExeDefinition", allowDefinition);

                var overrideModeDefault = factoryRecord.GetPropertyUsingReflection<object, bool>("OverrideModeDefault");
                SectionInformation.SetFieldUsingReflection("_overrideModeDefault", overrideModeDefault);
            }

            if (s_propAppSettings == null)
            {
                s_propAppSettings = new ConfigurationProperty(
                    name: null,
                    type: typeof(KeyValueConfigurationCollection),
                    defaultValue: null,
                    options: ConfigurationPropertyOptions.IsDefaultCollection);
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public KeyValueConfigurationCollection Settings => (KeyValueConfigurationCollection)base[s_propAppSettings];
    }
}
