using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LogoutTest
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
        public void Test5()
        {
            IWebElement login = driver.FindElement(By.XPath("//input[@id='Name']"));
            IWebElement password = driver.FindElement(By.XPath("//input[@id='Password']"));
            IWebElement submitBtn = driver.FindElement(By.XPath("//input[@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitBtn.Click();

            IWebElement logout = driver.FindElement(By.XPath("//a[contains(.,'Logout')]"));
            logout.Click();

            IWebElement form = driver.FindElement(By.XPath("//form"));

            Assert.True(form.Displayed);
           
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}