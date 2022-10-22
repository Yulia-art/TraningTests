using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraningTests.Pages.SignInPages
{
    class PasswordPage
    {
        private IWebDriver driver;

        private readonly By _passwordField = By.XPath("//input[@name='password']");
        private readonly By _rememberCheckbox = By.XPath("//*[@for='remember-login']");
        private readonly By _secureCheckbox = By.XPath("//*[@for='secure-session']");
        private readonly By _enterButton = By.XPath("//input[@type='submit'][@value='Вход']");
        private readonly By _forgotPasswordLink = By.XPath("//a[contains(@href, 'lost_pwd_page.php')]");

        public PasswordPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MainPage FillPasswordAndClickEnterButton(string password)
        {
            driver.FindElement(_passwordField).SendKeys(password);
            driver.FindElement(_enterButton).Click();

            return new MainPage(driver);
        }

        public PasswordResetPage ForgotPasswordClick()
        {
            driver.FindElement(_forgotPasswordLink).Click();

            return new PasswordResetPage(driver);
        }

        public void RememberCheckboxClick()
        {
            driver.FindElement(_rememberCheckbox).Click();
        }

        public void SecureCheckboxClick()
        {
            driver.FindElement(_secureCheckbox).Click();
        }

        public bool IsRememberCheckboxChecked()
        {
            try
            {
                driver.FindElement(_rememberCheckbox).GetAttribute("checked");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsSecureCheckboxChecked()
        {
            try
            {
                driver.FindElement(_secureCheckbox).GetAttribute("checked");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
