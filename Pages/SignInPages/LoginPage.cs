using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TraningTests.Pages.SignInPages
{
    class LoginPage
    {
        private IWebDriver driver;

        private readonly By _nameField = By.XPath("//input[@name='username']");
        private readonly By _enterButton = By.XPath("//input[@type='submit'][@value='Вход']");
        private readonly By _signUpNewAccount = By.XPath("//a[@href='signup_page.php']");
        private readonly By _anonLogin = By.XPath("//a[@href='login_anon.php?return=index.php']");
        private readonly By _alertMessage = By.CssSelector(".alert-danger");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public PasswordPage FillNameAndClickEnterButton(string name)
        {
            driver.FindElement(_nameField).SendKeys(name);
            driver.FindElement(_enterButton).Click();

            return new PasswordPage(driver);
        }

        public SignUpPage SignUpNewAccountClick()
        {
            driver.FindElement(_signUpNewAccount).Click();

            return new SignUpPage(driver);
        }

        public MainPage AnonymousLoginClick()
        {
            driver.FindElement(_anonLogin).Click();

            return new MainPage(driver);
        }

        public bool IsAlarmTextPresent()
        {
            try
            {
                driver.FindElement(_alertMessage);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
