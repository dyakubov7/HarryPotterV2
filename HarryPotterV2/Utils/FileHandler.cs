using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterV2.Utils
{
    public class FileHandler
    {

        public static string GetProjectPath()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath;

        }
        public static string GenerateDynamicFilePath(string filename)
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string filePath = projectPath + filename;
            return filePath;
        }
        public static string GenerateDynamicFilePathNGoUpTwoFolder()
        {
            //To get the assembly path
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            string directory = Path.GetDirectoryName(path); //one dir up
            string projectPath = Path.GetDirectoryName(directory); //one dir up
            return projectPath;
        }

        public static string GenerateDynamicFilePathNGoUpThreeFolder()
        {
            //To get the assembly path
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            string directory = Path.GetDirectoryName(path); //one dir up
            string directory1 = Path.GetDirectoryName(directory); //one dir up
            string projectPath = Path.GetDirectoryName(directory1); //one dir up
            return projectPath;
        }

        /// <summary>
        /// if you supply a folder name under user profile, it will return the full path to the folder
        /// Note: this only works for EN OS, it won't work for any other foreign languange OS.
        /// </summary>
        /// <param name="FolderName"></param>
        /// <returns></returns>
        public static string GenerateDynamicFilePathUnderUserProfile(string FolderName)
        {
            //to get download path
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), FolderName);
            return folderPath;
        }
    }
}
