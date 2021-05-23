using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace RemoveProduct
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
        public void Test4()
        {
            IWebElement login = driver.FindElement(By.XPath("//input[@id='Name']"));
            IWebElement password = driver.FindElement(By.XPath("//input[@id='Password']"));
            IWebElement submitBtn = driver.FindElement(By.XPath("//input[@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitBtn.Click();

            IWebElement product = driver.FindElement(By.XPath("//a[contains(text(),'All Products')]"));
            product.Click();
            IWebElement productRemove = driver.FindElement(By.XPath("//a[contains(text(), 'Pinapple')]/parent::td/parent::tr/td[position()=12]/a"));
            productRemove.Click();
            driver.SwitchTo().Alert().Accept();

            Assert.IsTrue(productRemove.Displayed);
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}