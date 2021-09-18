using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using log4net;
using log4net.Repository;
using System.Reflection;
using System.IO;

namespace HTMLReportGenerationDemo
{
    
    public class UploadFile
    {
        public static IWebDriver driver;
        public static readonly ILog LogInfo = LogManager.GetLogger(typeof(Tests));
        public static readonly ILoggerRepository loggerRepository = log4net.LogManager.GetRepository(Assembly.GetCallingAssembly());

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            var file = new FileInfo("log4net.config");
            log4net.Config.XmlConfigurator.Configure(loggerRepository, file);
            LogInfo.Info("Initializing SetUp");
        }

        [Test]
        public void SeleniumKeys()
        {
            driver.Navigate().GoToUrl("http:www.google.com");
            LogInfo.Debug("Navigating to URL");

            System.Threading.Thread.Sleep(300);
            TakeScreenshot1();
            IWebElement MyElement = driver.FindElement(By.Name("q"));
            System.Threading.Thread.Sleep(300);
            MyElement.SendKeys(Keys.ArrowUp); 
            MyElement.SendKeys(Keys.ArrowDown);
            MyElement.SendKeys(Keys.NumberPad4);
            MyElement.SendKeys(Keys.Enter);
            MyElement.SendKeys(Keys.Control + "a");
        }

        [Test]
        public void TakeScreenshot()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://easyupload.io/");
            System.Threading.Thread.Sleep(300);
            TakeScreenshot1();
            LogInfo.Debug("Taken a screenshot!!");
        }

        [Test]
        public void UploadFile_InApplication()
        {
            driver.Navigate().GoToUrl("https://www.monsterindia.com/seeker/registration");
            System.Threading.Thread.Sleep(300);
            IWebElement browse = driver.FindElement(By.XPath("//input[@id='file-upload']"));
          
            //click on ‘Choose file’ to upload the desired file
            try
            {
                browse.SendKeys("C:\\Users\\dell\\Downloads\\pdf-23-1066007.pdf"); //Uploading the file using sendKeys
                TakeScreenshot1();
                System.Threading.Thread.Sleep(1000);
                LogInfo.Debug("Uploaded File!!");

            }
            catch
            {
                throw new System.Exception("File not found Exception!!");
            }
        }  

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        } 

        public static void TakeScreenshot1()
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;

            Screenshot screenshot = screenshotDriver.GetScreenshot();
           
            screenshot.SaveAsFile(@"C:\Users\dell\source\repos\HTMLReportGenerationDemo\HTMLReportGenerationDemo\Screenshot\test1"+ DateTime.Now.ToString("HHmmss") + ".png");
        }
    }
}
