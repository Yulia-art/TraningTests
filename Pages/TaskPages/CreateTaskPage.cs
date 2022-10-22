using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraningTests.Pages.TaskPages
{
    class CreateTaskPage
    {
        private IWebDriver driver;

        private readonly By _categoryDropdown = By.XPath("//*[@name='category_id']");
        private readonly By _reproducibilityDropdown = By.XPath("//*[@name='reproducibility']");
        private readonly By _severityDropdown = By.XPath("//*[@name='severity']");
        private readonly By _priorityDropdown = By.XPath("//*[@name='priority']");
        private readonly By _productVersionDropdown = By.XPath("//*[@name='product_version']");
        private readonly By _profileDropdown = By.XPath("//*[@title='+']");
        private readonly By _platformField = By.XPath("//*[@name='platform']");
        private readonly By _operationSystemField = By.XPath("//*[@name='os']");
        private readonly By _osVersionField = By.XPath("//*[@name='os_build']");
        private readonly By _theme = By.XPath("//*[@name='summary']");
        private readonly By _description = By.XPath("//textarea[@name='description']");
        private readonly By _steps = By.XPath("//textarea[@name='steps_to_reproduce']");
        private readonly By _additionalInfo = By.XPath("//textarea[@name='additional_info']");
        private readonly By _attachFileField = By.XPath("//input[@name='if (attachFile)']");
        private readonly By _createTaskButton = By.CssSelector(".btn-round");

        public CreateTaskPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ChooseCategory(int option = 2) //static id
        {
            driver.FindElement(_categoryDropdown).Click();
            driver.FindElement(By.XPath($"//*[@id='category_id']/option[{option}]")).Click();
        }

        public void ChooseReproducibility (int option = 2)
        {
            driver.FindElement(_reproducibilityDropdown).Click();
            driver.FindElement(By.XPath($"//*[@id='reproducibility']/option[{option}]")).Click();
        }

        public void ChooseSeverity(int option = 2)
        {
            driver.FindElement(_severityDropdown).Click();
            driver.FindElement(By.XPath($"//*[@id='severity']/option[{option}]")).Click();
        }

        public void ChoosePriority(int option = 2)
        {
            driver.FindElement(_priorityDropdown).Click();
            driver.FindElement(By.XPath($"//*[@id='priority']/option[{option}]")).Click();
        }

        public void ChooseProductVersion(int option = 2)
        {
            driver.FindElement(_productVersionDropdown).Click();
            driver.FindElement(By.XPath($"//*[@id='product_version']/option[{option}]")).Click();
        }

        public void ChooseProfile(string text)
        {
            var profileDropdown = By.XPath($"//*[@title='{text}']");
            if (text == "+") 
            {
                driver.FindElement(_profileDropdown).Click();
            }
            
            driver.FindElement(_platformField).SendKeys(text);
            driver.FindElement(_operationSystemField).SendKeys(text);
            driver.FindElement(_osVersionField).SendKeys(text);
        }

        public void FillTheme(string theme)
        {
            driver.FindElement(_theme).SendKeys(theme);
        }

        public void FillDescription(string description)
        {
            driver.FindElement(_description).SendKeys(description);
        }

        public void FillSteps(string steps)
        {
            driver.FindElement(_steps).SendKeys(steps);
        }

        public void FillAdditionalInfo(string addInfo)
        {
            driver.FindElement(_additionalInfo).SendKeys(addInfo);
        }

        public void AttachFile(bool attachFile = true)
        {
            if (attachFile)
                driver.FindElement(_attachFileField).SendKeys("C:\\Users\\julia\\source\\repos\\TraningTests\\Test_File.txt");
        }

        public void AddTaskButtonClick()
        {
            driver.FindElement(_createTaskButton).Click();
        }

        public TaskViewPage FillTaskFields(string theme, string text, string description, string steps, string addInfo)
        {
            ChooseCategory();
            ChooseReproducibility();
            ChooseSeverity();
            ChoosePriority();
            ChooseProfile(text);
            ChooseProductVersion();
            FillTheme(theme);
            FillDescription(description);
            FillSteps(steps);
            FillAdditionalInfo(addInfo);
            //AttachFile(); я не нахожу нужный инпут
            AddTaskButtonClick();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return new TaskViewPage(driver);
        }
    }
}
