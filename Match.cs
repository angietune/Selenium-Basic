using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MatchTest
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
        public void Test3()
        {
            IWebElement login = driver.FindElement(By.XPath("//input[@id='Name']"));
            IWebElement password = driver.FindElement(By.XPath("//input[@id='Password']"));
            IWebElement submitBtn = driver.FindElement(By.XPath("//input[@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitBtn.Click();

            IWebElement product = driver.FindElement(By.XPath("//a[contains(text(),'All Products')]"));
            product.Click();

            IWebElement productLine = driver.FindElement(By.XPath("//a[contains(text(),'Pinapple')]"));
            productLine.Click();
            IWebElement productName = driver.FindElement(By.Id("ProductName"));
            IWebElement productCategory = driver.FindElement(By.XPath("//*[@id='CategoryId']/option[9]"));
            IWebElement productSupplier = driver.FindElement(By.XPath("//*[@id='SupplierId']/option[2]"));
            IWebElement productPrice = driver.FindElement(By.Id("UnitPrice"));
            IWebElement productQuantity = driver.FindElement(By.Id("QuantityPerUnit"));
            IWebElement productStock = driver.FindElement(By.Id("UnitsInStock"));
            IWebElement productOrder = driver.FindElement(By.Id("UnitsOnOrder"));
            IWebElement productLevel = driver.FindElement(By.Id("ReorderLevel"));

            Assert.AreEqual(productName.GetAttribute("value"), "Pinapple");
            Assert.AreEqual(productCategory.Text, "Seafood");
            Assert.AreEqual(productSupplier.Text, "Exotic Liquids");
            Assert.AreEqual(productPrice.GetAttribute("value"), "5,0000");
            Assert.AreEqual(productQuantity.GetAttribute("value"), "1");
            Assert.AreEqual(productStock.GetAttribute("value"), "10");
            Assert.AreEqual(productOrder.GetAttribute("value"), "10");
            Assert.AreEqual(productLevel.GetAttribute("value"), "1");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}