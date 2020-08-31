using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace HarryPotterV2.Utils
{
    public static class ReportingUtil
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static ExtentV3HtmlReporter htmlReporter;
        public static ExtentReports InitializeExtentReport(string htmlExtentReportFileName)
        {
            extent = new ExtentReports();
            string dateTimeStamp = DateTime.Now.ToString("_D-MMddyyyy_T-HHmmss");
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string htmlReportFilePath = Path.Combine(projectPath + "TestOutput", htmlExtentReportFileName + dateTimeStamp + ".html");
            string extentConfigFilePath = Path.Combine(projectPath + "Config", "Extent-Config.xml");
            htmlReporter = new ExtentV3HtmlReporter(htmlReportFilePath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            htmlReporter.LoadConfig(extentConfigFilePath);
            return extent;
        }
    }
}
