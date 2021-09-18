
// Video Link : https://www.youtube.com/watch?v=vmWmCw_8WsE
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutoItX3Lib;
using AventStack.ExtentReports;

namespace HTMLReportGenerationDemo
{
    public class AutoITUpload
    {
        public static IWebDriver driver;
        ExtentReports reports = Tests.report();
        ExtentTest test;
        [SetUp]
        public void setUp()
        {
            test = reports.CreateTest("Tests");
            test.Log(Status.Info, "Automating Facebook Login Page");
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            driver = new ChromeDriver(options);
            driver.Url = "https://www.facebook.com/";
        }

        [Test]
        public void Upload_file()
        {

            IWebElement email = driver.FindElement(By.Name("email"));
            email.SendKeys("testingtestdatablz@gmail.com");

            IWebElement password = driver.FindElement(By.Id("pass"));
            password.SendKeys("testing123");

            IWebElement loginbtn = driver.FindElement(By.Name("login"));
            loginbtn.Click();
            System.Threading.Thread.Sleep(10000);


            IWebElement uploadPhoto = driver.FindElement(By.XPath("//span[contains(text(),'Photo/Video')]"));
            uploadPhoto.Click();
            System.Threading.Thread.Sleep(500);

            //upload a photo
            IWebElement addPhoto = driver.FindElement(By.XPath("//span[contains(text(),'Add photos/videos')]"));
            addPhoto.Click();

            //For Error solving link - https://stackoverflow.com/questions/14644258/how-to-get-autoit-reference-working-in-c
            AutoItX3 AutoIt = new AutoItX3();
            AutoIt.WinActivate("Open");
            AutoIt.Send(@"C:\Users\dell\Downloads\IMG_20210917_111845.jpg");
            System.Threading.Thread.Sleep(500);
            AutoIt.Send("{ENTER}");
            System.Threading.Thread.Sleep(500);

            test.Log(Status.Pass, "Test PAsses");

            reports.Flush();
        }

       /* [TearDown]
        public void TearDown()
        {
            driver.Close();
        }*/
    }
}
