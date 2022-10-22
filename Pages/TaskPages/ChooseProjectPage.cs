using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraningTests.Pages.TaskPages
{
    class ChooseProjectPage
    {
        private IWebDriver driver;

        private readonly By _defaultCheckbox = By.XPath("//*[@name='make_default']/..");
        private readonly By _chooseProjectButton = By.CssSelector(".btn-white");

        public ChooseProjectPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void DefaultCheckboxClick()
        {
            driver.FindElement(_defaultCheckbox).Click();
        }

        public CreateTaskPage ChooseProjectClick()
        {
            driver.FindElement(_chooseProjectButton).Click();

            return new CreateTaskPage (driver);
        }
    }
}
