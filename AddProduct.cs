using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AddProduct
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
        public void Test2()
        {
            IWebElement login = driver.FindElement(By.XPath("//input[@id='Name']"));
            IWebElement password = driver.FindElement(By.XPath("//input[@id='Password']"));
            IWebElement submitBtn = driver.FindElement(By.XPath("//input[@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitBtn.Click();

            IWebElement product = driver.FindElement(By.XPath("//a[contains(text(),'All Products')]"));
            product.Click();

            IWebElement create = driver.FindElement(By.XPath("//a[contains(text(),'Create new')]"));
            create.Click();

            IWebElement productName = driver.FindElement(By.XPath("//input[@id='ProductName']"));
            IWebElement productCategory = driver.FindElement(By.XPath("//select[@id='CategoryId']"));
            SelectElement productCategoryValue = new SelectElement(productCategory);
            IWebElement productSupplier = driver.FindElement(By.XPath("//select[@id='SupplierId']"));
            SelectElement productSupplierValue = new SelectElement(productSupplier);
            IWebElement productPrice = driver.FindElement(By.XPath("//input[@id='UnitPrice']"));
            IWebElement productQuantity = driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']"));
            IWebElement productStock = driver.FindElement(By.XPath("//input[@id='UnitsInStock']"));
            IWebElement productOrder = driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']"));
            IWebElement productLevel = driver.FindElement(By.XPath("//input[@id='ReorderLevel']"));
            IWebElement CreateBtn = driver.FindElement(By.XPath("//input[@type='submit']"));

            productName.SendKeys("Pinapple");
            productCategory.Click();
            productCategoryValue.SelectByValue("8");
            productSupplier.Click();
            productSupplierValue.SelectByValue("1");
            productPrice.SendKeys("5");
            productQuantity.SendKeys("1");
            productStock.SendKeys("10");
            productOrder.SendKeys("10");
            productLevel.SendKeys("1");
            CreateBtn.Click();

            IWebElement newProduct = driver.FindElement(By.XPath("//a[contains(.,'Pinapple')]"));

            Assert.AreEqual(newProduct.Text, "Pinapple");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}