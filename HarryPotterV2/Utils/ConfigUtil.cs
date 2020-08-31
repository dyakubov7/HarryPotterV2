namespace HarryPotterV2.Utils
{
    using Microsoft.Extensions.Configuration;


    /// <summary>
    /// Loads config via a JSON file and optionally environment variables
    /// </summary>
    public static class ConfigUtil
    {
        /// <summary>
        /// Loads the config from the JSON file
        /// </summary>
        /// <returns>
        /// The configuration
        /// </returns>
        /// <param name="settingsFile">
        /// File name of the settings file (Example: appsettings.json)
        /// </param>
        public static IConfiguration Build(string settingsFile)
        {
            return new ConfigurationBuilder()
                .AddJsonFile(settingsFile, optional: true, reloadOnChange: true)
                .Build();
        }

        /// <summary>
        /// Loads the config from the JSON file and environment variables
        /// </summary>
        /// <returns>
        /// The configuration
        /// </returns>
        /// <param name="settingsFile">
        /// File name of the settings file (Example: appsettings.json)
        /// </param>
        public static IConfiguration BuildWithEnv(string settingsFile)
        {
            return new ConfigurationBuilder()
                .AddJsonFile(settingsFile, optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
