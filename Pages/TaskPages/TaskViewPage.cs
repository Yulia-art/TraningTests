using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraningTests.Pages.TaskPages
{
    class TaskViewPage
    {
        private IWebDriver driver;

        private readonly By _pageTitle = By.XPath("(//*[contains(@class, 'widget-header ')])[1]");

        public TaskViewPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetPageTitle()
        {
            string pageTitle = driver.FindElement(_pageTitle).Text;

            return pageTitle;
        }
    }
}
