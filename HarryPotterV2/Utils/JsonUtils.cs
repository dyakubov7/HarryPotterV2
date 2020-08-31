using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HarryPotterV2.Utils
{
    public static class JsonUtils
    {
        /// <summary>
        /// Gets list of json dictionary (key, value)
        /// </summary>
        /// <param name="fileName">Json file name</param>
        /// <returns>List of json data in Dictionary objects from particular json file</returns>
        public static IList<Dictionary<string, string>> GetJsonFromFile(string fileName)
        {
            string filePath = GetJsonFilepath(fileName);
            StreamReader reader = new StreamReader(filePath);
            if (File.Exists(filePath))
            {
                string jsonText = reader.ReadToEnd();
                reader.Close();
                return JsonConvert.DeserializeObject<IList<Dictionary<string, string>>>(jsonText);
            }
            else
            {
                throw new FileNotFoundException("File path is incorrect");
            }
        }

        /// <summary>
        /// Gets json file locator
        /// </summary>
        /// <param name="fileName">Json file name</param>
        /// <returns>Json file path</returns>
        public static string GetJsonFilepath(string fileName)
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath + Path.Combine("Testdata", "JsonFiles", fileName);
        }

        /// <summary>
        /// Write Json file
        /// </summary>
        /// <param name="filepath">File path of target location</param>
        /// <param name="data">object that needed to write in json file</param>
        /// <returns>when writing process is successfully will return true, if any exception has been thrown it will return false</returns>
        public static bool WriteDataToJSONFile(string filepath, object data)
        {
            try
            {
                //Convert object to JSON String
                string dataInString = JsonConvert.SerializeObject(data, Formatting.Indented);

                //Deletes the old file and create a new file each time
                using (StreamWriter tw = new StreamWriter(filepath, false))
                {
                    tw.WriteLine(dataInString.ToString());
                    tw.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Author : Ethan Goatley
        /// 
        /// Gets latest json from file
        /// 
        /// 7/22/2019 Ethan Goatley Created
        /// </summary>
        /// <returns>List of key and value in json file</returns>
        public static IList<Dictionary<string, string>> GetLatestJsonFromFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            if (File.Exists(file))
            {
                string jsonText = reader.ReadToEnd();
                reader.Close();
                return JsonConvert.DeserializeObject<IList<Dictionary<string, string>>>(jsonText);
            }
            else
            {
                throw new FileNotFoundException("File path is incorrect");
            }
        }
    }
}
