
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace HTMLReportGenerationDemo
{
    [TestFixture]
    public class Tests 
    {
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentReports extent;
        public static ExtentTest test;

        public static ExtentReports report()
        {
           string reportPath = @"C:\Users\dell\source\repos\HTMLReportGenerationDemo\HTMLReportGenerationDemo\Reports\MyOwnReport"+ DateTime.Now.ToString("HHmmss") + ".html";
           htmlReporter = new ExtentHtmlReporter(reportPath);
           extent = new ExtentReports();
           extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", "Windows");
                extent.AddSystemInfo("UserName", "Sheetal");
                extent.AddSystemInfo("ProjectName", "Generate Extent Report");

           string conifgPath = @"C:\Users\dell\source\repos\HTMLReportGenerationDemo\HTMLReportGenerationDemo\extent-config.xml";
           htmlReporter.LoadConfig(conifgPath);
           return extent;
        }
    }
}
