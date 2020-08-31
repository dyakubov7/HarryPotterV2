namespace HarryPotterV2.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public static class ConfigReaderUtil
    {
        public static IDictionary<string, string> XmlToDictionary(string configFilepath, string key, string value, XName baseElm)
        {
            XElement configXml = XElement.Load(configFilepath);
            string xmlAsString = configXml.ToString();
            var configDataAsDictionary = XElement.Parse(xmlAsString)
                            .Elements(baseElm)
                                        .ToDictionary(
                                 el => (string)el.Attribute(key),
                                       el => (string)el.Attribute(value)
                                           );

            // It appears this code is here with the intent of allowing a developer to dump out the dictionary to the console.  Hence this code
            // should only be run under the debugger.
#if DEBUG
            foreach (var key1 in configDataAsDictionary.Keys)
            {
                Console.Write(configDataAsDictionary[key1]);
            }
#endif

            return configDataAsDictionary;
        }
    }
}