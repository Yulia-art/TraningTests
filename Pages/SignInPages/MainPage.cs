using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraningTests.Pages.TaskPages;

namespace TraningTests.Pages.SignInPages
{
    class MainPage
    {
        private IWebDriver driver;

        private readonly By _userLogin = By.XPath("//span[@class='user-info']");
        private readonly By _addTaskButton = By.XPath("//a[@href='bug_report_page.php']");
        private readonly By _addTaskMenu = By.XPath("//a[@href='/bugs/bug_report_page.php']");

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUserLogin()
        {
            string userName = driver.FindElement(_userLogin).Text;

            return userName;
        }

        public CreateTaskPage AddTaskViaButton()
        {
            driver.FindElement(_addTaskButton).Click();

            return new CreateTaskPage(driver);
        }

        public CreateTaskPage AddTaskViaRegistry()
        {
            driver.FindElement(_addTaskMenu).Click();

            return new CreateTaskPage(driver);
        }

        public bool IsAddTaskButtonPresent()
        {
            try
            {
                driver.FindElement(_addTaskButton);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsAddTaskMenuPresent()
        {
            try
            {
                driver.FindElement(_addTaskMenu);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
