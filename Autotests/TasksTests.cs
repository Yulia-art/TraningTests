using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraningTests.Pages.SignInPages;
using TraningTests.Pages.TaskPages;

namespace TraningTests.Autotests
{
    public class TasksTests
    {
        private IWebDriver driver;

        private const string ApplicationUrl = "https://www.mantisbt.org/bugs/login_page.php";
        private const string ViewTaskUrl = "https://www.mantisbt.org/bugs/view.php";

        private const string _userName = "Yulia Karablina";
        private const string _anonName = "anonymous";
        private const string _password = "Pass123!";
        private const string _anyText = "text";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(ApplicationUrl);
            driver.Manage().Window.Maximize();

            
        }

        [Test]
        public void Tasks_AddNewTaskViaButton_AuthUser_Success()
        {
            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);
            var mainPage = new MainPage(driver);
            var chooseProjectPage = new ChooseProjectPage(driver);
            var createTaskPage = new CreateTaskPage(driver);
            var taskViewPage = new TaskViewPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);
            passwordPage.FillPasswordAndClickEnterButton(_password);
            mainPage.AddTaskViaButton();
            createTaskPage.FillTaskFields(_anyText, _anyText, _anyText, _anyText, _anyText);

            Assert.AreEqual("Просмотр задачи", taskViewPage.GetPageTitle());
        }

        [Test]
        public void Tasks_AddNewTaskViaRegistry_AuthUser_Success()
        {
            var loginPage = new LoginPage(driver);
            var passwordPage = new PasswordPage(driver);
            var mainPage = new MainPage(driver);
            var chooseProjectPage = new ChooseProjectPage(driver);
            var createTaskPage = new CreateTaskPage(driver);
            var taskViewPage = new TaskViewPage(driver);

            loginPage.FillNameAndClickEnterButton(_userName);
            passwordPage.FillPasswordAndClickEnterButton(_password);
            mainPage.AddTaskViaRegistry();
            createTaskPage.FillTaskFields(_anyText, _anyText, _anyText, _anyText, _anyText);

            Assert.AreEqual("Просмотр задачи", taskViewPage.GetPageTitle());
        }

        [Test]
        public void Tasks_AddNewTaskViaButton_AnonUser_Failed()
        {
            var loginPage = new LoginPage(driver);
            var mainPage = new MainPage(driver);

            loginPage.AnonymousLoginClick();

            Assert.False(mainPage.IsAddTaskButtonPresent());
        }

        [Test]
        public void Tasks_AddNewTaskViaegistry_AnonUser_Failed()
        {
            var loginPage = new LoginPage(driver);
            var mainPage = new MainPage(driver);

            loginPage.AnonymousLoginClick();

            Assert.False(mainPage.IsAddTaskMenuPresent());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
