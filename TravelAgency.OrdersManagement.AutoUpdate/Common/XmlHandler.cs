using System;
using System.Windows.Forms;
using System.Xml.Linq;
using DevComponents.DotNetBar;

namespace TravelAgency.OrdersManagement.AutoUpdate.Common
{
    public static class XmlHandler
    {
        public static string GetPropramVersion()
        {
            string version = "-1.0";
            try
            {
                string configpath = GlobalUtils.AppPath + "\\" + "TravelAgency.OrdersManagement.exe.config";
                XDocument xDoc = XDocument.Load(configpath);

                XElement rootElem = xDoc.Root;
                XElement settings = rootElem.Element("appSettings");

                foreach (XElement xElement in settings.Elements())
                {
                    if (xElement.Attribute("key").Value == "Version")
                    {
                        version = xElement.Attribute("value").Value;
                        return version;
                    }
                }
                return version;

            }
            catch (Exception)
            {
                MessageBoxEx.Show("无法找到配置文件，程序将关闭!");
                Application.Exit();
            }
            return version;
        }

        public static bool SetPropramVersion(string version)
        {
            try
            {
                string configpath = GlobalUtils.AppPath + "\\" + "TravelAgency.OrdersManagement.exe.config";
                XDocument xDoc = XDocument.Load(configpath);

                XElement rootElem = xDoc.Root;
                XElement settings = rootElem.Element("appSettings");

                foreach (XElement xElement in settings.Elements())
                {
                    if (xElement.Attribute("key").Value == "Version")
                    {
                        xElement.Attribute("value").SetValue(version);
                        xDoc.Save(GlobalUtils.AppPath + "\\" + "TravelAgency.OrdersManagement.exe.config");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                MessageBoxEx.Show("无法找到配置文件，程序将关闭!");
                Application.Exit();

            }
            return false;
        }


        public static string GetPropramPath()
        {
            string path = null;
            try
            {
                string configpath = GlobalUtils.AppPath + "\\" + "TravelAgency.OrdersManagement.exe.config";
                XDocument xDoc = XDocument.Load(configpath);
                try
                {
                    XElement rootElem = xDoc.Root;
                    XElement settings = rootElem.Element("appSettings");

                    foreach (XElement xElement in settings.Elements())
                    {
                        if (xElement.Attribute("key").Value == "ServerProgramPath")
                        {
                            path = xElement.Attribute("value").Value;
                            return path;
                        }
                    }
                    return path;
                }
                catch (Exception)
                {
                    MessageBoxEx.Show("解析服务器路径出错，程序将关闭!");
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                MessageBoxEx.Show("无法找到配置文件，程序将关闭!");
                Application.Exit();

            }
            return path;
        }


    }
}