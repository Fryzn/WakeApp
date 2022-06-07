using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using static System.Console;

namespace WakeApp
{
    internal class XmlConfig : Program
    {
        // Directory & File paths
        private readonly string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private string xmlHandlerDirectory = String.Empty;
        private string configXml = @"\config.xml";

        // XDocument
        private XDocument XConfig;

        private void FindHanlderDirectory()
        {
            foreach (string folder in Directory.GetDirectories(projectDirectory))
            {
                if (folder.Contains("XmlHandler"))
                {
                    xmlHandlerDirectory = folder;
                }
            }
        }

        public void Check()
        {
            FindHanlderDirectory();
            if (!File.Exists(xmlHandlerDirectory + configXml))
            {
                CreateXml();
                configExists = true;
            }
            else if (File.Exists(xmlHandlerDirectory + configXml))
            {
                configExists = true;
            }
        }

        private void CreateXml()
        {
            XConfig = new XDocument(
                new XDeclaration("1.0", "utf-8", ""),
                new XComment("Auto-Gen xml file to save the last alarm clock!"),
                new XElement("root",
                    new XElement("alarmclock",
                        new XAttribute("profile", "1"),
                        new XElement("arrival-time", "",
                            new XAttribute("type", "string")
                        ),
                        new XElement("route-duration", "",
                            new XAttribute("type", "string")
                        ),
                        new XElement("get-ready-time", "", 
                            new XAttribute("type", "string")
                        ),
                        new XElement("other-delays", "", 
                            new XAttribute("type", "string")
                        ),
                        new XElement("buffer-time", "", 
                            new XAttribute("type", "string")
                        )
                    )
                )
            );
            XConfig.Save(xmlHandlerDirectory + configXml);
        }

        public void Load()
        {
            FindHanlderDirectory();
            XConfig = XDocument.Load(xmlHandlerDirectory + configXml);
            XElement XAlarmClock = XConfig.Root.Element("alarmclock");
            valuesInConfig = false;

            foreach (XElement XElem in XAlarmClock.Elements())
            {
                if (XAlarmClock.Attribute("profile").Value.ToString().Equals("1"))
                {
                    if (XElem.Name.ToString().Equals("arrival-time") & XElem.Value.Length > 0 & XElem.Attribute("type").Value.ToString().Equals("string"))
                    {
                        valuesInConfig = true;
                        arrivalTime = XElem.Value.ToString();
                    }
                    else if (XElem.Name.ToString().Equals("route-duration") & XElem.Value.Length > 0 & XElem.Attribute("type").Value.ToString().Equals("string"))
                    {
                        valuesInConfig = true;
                        routeDuration = XElem.Value.ToString();
                    }
                    else if (XElem.Name.ToString().Equals("get-ready-time") & XElem.Value.Length > 0 & XElem.Attribute("type").Value.ToString().Equals("string"))
                    {
                        valuesInConfig = true;
                        getReadyTime = XElem.Value.ToString();
                    }
                    else if (XElem.Name.ToString().Equals("other-delays") & XElem.Value.Length > 0 & XElem.Attribute("type").Value.ToString().Equals("string"))
                    {
                        valuesInConfig = true;
                        otherDelays = XElem.Value.ToString();
                    }
                    else if (XElem.Name.ToString().Equals("buffer-time") & XElem.Value.Length > 0 & XElem.Attribute("type").Value.ToString().Equals("string"))
                    {
                        valuesInConfig = true;
                        bufferTime = XElem.Value.ToString();
                    }
                }
            }
        }

        public void Save()
        {
            FindHanlderDirectory();
            XConfig = XDocument.Load(xmlHandlerDirectory + configXml);
            XElement XAlarmClock = XConfig.Root.Element("alarmclock");

            foreach (XElement XElem in XAlarmClock.Elements())
            {
                if (XAlarmClock.Attribute("profile").Value.ToString().Equals("1"))
                {
                    if (XElem.Name.ToString().Equals("arrival-time"))
                    {
                        XElem.Value = arrivalTime;
                    }
                    else if (XElem.Name.ToString().Equals("route-duration"))
                    {
                        XElem.Value = routeDuration;
                    }
                    else if (XElem.Name.ToString().Equals("get-ready-time"))
                    {
                        XElem.Value = getReadyTime;
                    }
                    else if (XElem.Name.ToString().Equals("other-delays"))
                    {
                        XElem.Value = otherDelays;
                    }
                    else if (XElem.Name.ToString().Equals("buffer-time"))
                    {
                        XElem.Value = bufferTime;
                    }
                }
            }
            XConfig.Save(xmlHandlerDirectory + configXml);
        }
    }
}
