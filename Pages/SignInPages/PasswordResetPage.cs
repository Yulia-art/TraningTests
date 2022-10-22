using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraningTests.Pages.SignInPages
{
    class PasswordResetPage
    {
        private IWebDriver driver;

        public PasswordResetPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
