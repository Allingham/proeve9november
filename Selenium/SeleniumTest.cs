using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    [TestClass]
    public class SeleniumTest
    {
        private const string URL = "https://plantebrowser2.azurewebsites.net";
        ChromeOptions options = new ChromeOptions();
        IWebDriver driver = new ChromeDriver();

        [TestInitialize]
        public void Setup()
        {
            driver.Navigate().GoToUrl(URL);
        }

        [TestMethod]
        public void TestGetByType()
        {
            IWebElement input = driver.FindElement(By.Id("imputField"));
            input.Clear();
            input.SendKeys("Rose");

            IWebElement getByType = driver.FindElement(By.Id("GetByType"));
            getByType.Click();

            var liste = driver.FindElements(By.ClassName("ul"));

            foreach (var item in liste)
            {
                Assert.IsTrue(item.Text.ToLower().Contains("rose"));
            }
        }

        [TestMethod]
        public void TestGetById()
        {
            IWebElement input = driver.FindElement(By.Id("imputField"));
            input.Clear();
            input.SendKeys("1");

            IWebElement getByType = driver.FindElement(By.Id("GetById"));
            getByType.Click();

            var liste = driver.FindElements(By.ClassName("ul"));

            foreach (var item in liste)
            {
                Assert.IsTrue(item.Text.ToLower().Contains("albertine"));
            }

            
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
