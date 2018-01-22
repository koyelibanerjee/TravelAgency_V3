using System.Configuration;

namespace TravelAgency.Common
{
    /// <summary>
    /// 修改程序对应.config文件的方法，但是VS里面的app.config是看不到的，需要手动去程序目录下找到文件才能看到
    /// </summary>
    public static class AppSettingHandler
    {
        private static readonly Configuration ConfigObj
            = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public static string ReadConfig(string name)
        {
            if (ConfigObj.AppSettings.Settings[name] != null)
                return ConfigObj.AppSettings.Settings[name].Value;
            return null;
        }

        public static void AddConfig(string name, string value)
        {
            if (ReadConfig(name) != null)
            {
                ModifyConfig(name, value);
                return;
            }
            //增加元素
            ConfigObj.AppSettings.Settings.Add(name, value);
            //一定要记得保存，写不带参数的config.Save()也可以
            ConfigObj.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }

        public static bool ModifyConfig(string name, string value)
        {
            //写入元素的Value
            if (ConfigObj.AppSettings.Settings[name] != null)
            {
                ConfigObj.AppSettings.Settings[name].Value = value;
                ConfigObj.Save(ConfigurationSaveMode.Modified);
                //刷新，否则程序读取的还是之前的值（可能已装入内存）
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            return false;
        }

    }
}