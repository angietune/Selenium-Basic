using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LoginTest
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
        }

        [Test]
        public void Test1()
        {
            IWebElement login = driver.FindElement(By.XPath("//input[@id='Name']"));
            IWebElement password = driver.FindElement(By.XPath("//input[@id='Password']"));
            IWebElement submitBtn = driver.FindElement(By.XPath("//input[@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitBtn.Click();

            IWebElement logout = driver.FindElement(By.XPath("//a[contains(.,'Logout')]"));

            Assert.AreEqual(logout.Text, "Logout");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}