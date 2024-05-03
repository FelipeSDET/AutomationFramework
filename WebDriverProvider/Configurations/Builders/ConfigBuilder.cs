using Microsoft.Extensions.Configuration;

namespace WebDriverProvider.Configurations
{
    public class ConfigBuilder
    {
        private static readonly ConfigBuilder _instance = new ConfigBuilder();
        private readonly IConfigurationBuilder builder;
        private IConfigurationRoot Config { get; }

        private ConfigBuilder()
        {
            var envPath = AppContext.BaseDirectory + "Configurations//testbed.env";
            if (File.Exists(envPath))
            {
                DotNetEnv.Env.Load(envPath);
            }
            else
            {
                DotNetEnv.Env.TraversePath().Load();
            }
            builder = new ConfigurationBuilder().AddJsonFile(AppContext.BaseDirectory + "Configurations//appsettings.json", false, true);
            Config = builder.Build();
        }
        public static ConfigBuilder Instance => _instance;

        public string GetString(string key)
        {
            string res = DotNetEnv.Env.GetString(key);

            return res != null ? res : throw new Exception($"Key {key} not found");
        }

        public string GetString(string framework, string key)
        {
            var res = DotNetEnv.Env.GetString(key);

            if (res != null)
            {
                return res;
            }

            res = Config.GetSection(framework)[key]!;

            return res != null ? res : throw new Exception($"Framework '{framework}' or key '{key}' not found.");
        }

        public int GetInt(string key)
        {
            return Convert.ToInt32(DotNetEnv.Env.GetInt(key));
        }

        public int GetInt(string framework, string key)
        {
            var res = DotNetEnv.Env.GetInt(key);

            if (res != 0)
            {
                return res;
            }

            try
            {
                return Convert.ToInt32(Config.GetSection(framework)[key]);
            }
            catch (Exception)
            {
                throw new Exception($"Framework '{framework}' or key '{key}' not found.");
            }
        }

        public bool GetBool(string key)
        {
            return DotNetEnv.Env.GetBool(key);
        }

        public bool GetBool(string framework, string key)
        {
            try
            {
                var res = DotNetEnv.Env.GetBool(key);
                if (res)
                {
                    return true;
                }

                return Convert.ToBoolean(Config.GetSection(framework)[key]);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid format for key.");
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException($"Framework '{framework}' or key '{key}' not found.");
            }
        }

        public TimeSpan GetTimeSpan(string key)
        {
            string value = DotNetEnv.Env.GetString(key);
            if (TimeSpan.TryParse(value, out TimeSpan result))
            {
                return result;
            }

            throw new FormatException($"Invalid TimeSpan format for key: {key}.");
        }

        public TimeSpan GetTimeSpan(string framework, string key)
        {
            try
            {
                string value = DotNetEnv.Env.GetString(key);
                if (TimeSpan.TryParse(value, out TimeSpan result))
                {
                    return result;
                }

                value = Config.GetSection(framework)[key]!;
                if (TimeSpan.TryParse(value, out result))
                {
                    return result;
                }

                throw new FormatException($"Invalid TimeSpan format for key: {key}.");
            }
            catch (FormatException)
            {
                throw new FormatException($"Invalid TimeSpan format for framework '{framework}' and key '{key}'.");
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException($"Framework '{framework}' or key '{key}' not found.");
            }
        }

    }
}

 