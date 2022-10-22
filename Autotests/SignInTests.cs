using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TraningTests.Pages.SignInPages;
using Xunit;

namespace TraningTests.Autotests
{
    public class SignInTests
    {
        private IWebDriver driver;

        private const string ApplicationUrl = "https://www.mantisbt.org/bugs/login_page.php";
        private const string SignUpUrl = "https://www.mantisbt.org/bugs/signup_page.php";
        private const string PasswordResetUrl = "https://www.mantisbt.org/bugs/lost_pwd_page.php?username=Yulia+Karablina";

        private const string _userName = "Yulia Karablina";
        private const string _anonName = "anonymous";
        private const string _password = "Pass123!";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(ApplicationUrl);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SignIn_AllFieldFilled_Success()
        {
            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);
            var mainPage = new MainPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);
            passwordPage.FillPasswordAndClickEnterButton(_password);

            string expectedName = mainPage.GetUserLogin();

            Assert.AreEqual(_userName, expectedName);
        }

        [Test]
        public void SignIn_EmptyLogin_Failed()
        {
            var loginPage = new LoginPage(driver);

            loginPage.FillNameAndClickEnterButton(String.Empty);

            Assert.True(loginPage.IsAlarmTextPresent());
        }

        [Test]
        public void SignIn_EmptyPassword_Failed()
        {
            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);
            passwordPage.FillPasswordAndClickEnterButton(String.Empty);

            Assert.True(loginPage.IsAlarmTextPresent());
        }

        [Test]
        public void SignIn_WrongLoginName_Failed()
        {
            string wrongName = _userName + new Random().NextInt64(1, 99).ToString();

            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);

            loginPage.FillNameAndClickEnterButton(wrongName);
            passwordPage.FillPasswordAndClickEnterButton(_password);

            Assert.True(loginPage.IsAlarmTextPresent());
        }

        [Test]
        public void SignIn_WrongPassword_Failed()
        {
            string wrongPassword = new Random().NextInt64(10000000, 99999999).ToString();

            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);
            passwordPage.FillPasswordAndClickEnterButton(wrongPassword);

            Assert.True(loginPage.IsAlarmTextPresent());
        }

        [Test]
        public void SignIn_LoginUpperCase_Success() //Bug?
        {
            string wrongName = _userName.ToUpper();

            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);
            var mainPage = new MainPage(driver);

            loginPage.FillNameAndClickEnterButton(wrongName);
            passwordPage.FillPasswordAndClickEnterButton(_password);

            string expectedName = mainPage.GetUserLogin();

            Assert.AreEqual(_userName, expectedName);
        }

        [Test]
        public void SignIn_LoginLowerCase_Success() //Bug?
        {
            string wrongName = _userName.ToLower();

            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);
            var mainPage = new MainPage(driver);

            loginPage.FillNameAndClickEnterButton(wrongName);
            passwordPage.FillPasswordAndClickEnterButton(_password);

            string expectedName = mainPage.GetUserLogin();

            Assert.AreEqual(_userName, expectedName);
        }

        [Test]
        public void SignIn_PasswordUpperCase_Failed()
        {
            string wrongPassword = _password.ToUpper();

            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);
            passwordPage.FillPasswordAndClickEnterButton(wrongPassword);

            Assert.True(loginPage.IsAlarmTextPresent());
        }

        [Test]
        public void SignIn_PasswordLowerCase_Failed()
        {
            string wrongPassword = _password.ToLower();

            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);
            passwordPage.FillPasswordAndClickEnterButton(wrongPassword);

            Assert.True(loginPage.IsAlarmTextPresent());
        }

        [Test]
        public void SignIn_GoToSignUpPage_Success()
        {
            var loginPage = new LoginPage(driver);

            loginPage.SignUpNewAccountClick();

            Assert.AreEqual(SignUpUrl, driver.Url);
        }

        [Test]
        public void SignIn_AnonymousLogin_Success()
        {
            var loginPage = new LoginPage(driver);
            var mainPage = new MainPage(driver);

            loginPage.AnonymousLoginClick();

            string expectedName = mainPage.GetUserLogin();

            Assert.AreEqual(_anonName, expectedName);
        }

        [Test]
        public void SignIn_RememberCheckboxIsUnchecked_Success() //no checked attribute
        {
            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);

            Assert.False(passwordPage.IsRememberCheckboxChecked());
        }

        [Test]
        public void SignIn_SecureCheckboxIsUnchecked_Success() //Bug?
        {
            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);

            Assert.False(passwordPage.IsSecureCheckboxChecked());
        }

        [Test]
        public void SignIn_RememberUser_Success()
        {
            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);
            var mainPage = new MainPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);
            passwordPage.RememberCheckboxClick();
            passwordPage.FillPasswordAndClickEnterButton(_password);

            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Navigate().GoToUrl(ApplicationUrl);

            string expectedName = mainPage.GetUserLogin();

            Assert.AreEqual(_userName, expectedName);
        }

        [Test]
        public void SignIn_GoToForgotPasswordPage_Success()
        {
            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);
            passwordPage.ForgotPasswordClick();

            Assert.AreEqual(PasswordResetUrl, driver.Url);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}