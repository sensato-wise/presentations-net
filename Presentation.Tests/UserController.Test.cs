using Presentation.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using Presentation.Models;

namespace Presentation.Tests
{
    
    
    /// <summary>
    ///Это класс теста для UserController_Test, в котором должны
    ///находиться все модульные тесты UserController_Test
    ///</summary>
    [TestClass()]
    public class UserController_Test
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Тест для Конструктор UserController
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void UserControllerConstructor()
        {
            UserController target = new UserController();
            Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для ChangeRole
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void ChangeRole()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            string Name = string.Empty; // TODO: инициализация подходящего значения
            string ViewType = string.Empty; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.ChangeRole(Name, ViewType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для ChangeRole
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void ChangeRole1()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            UserEditModel model = null; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.ChangeRole(model);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для ChangeRoleSuccess
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void ChangeRoleSuccess()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.ChangeRoleSuccess();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для Delete
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void Delete()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            string Name = string.Empty; // TODO: инициализация подходящего значения
            string ViewType = string.Empty; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.Delete(Name, ViewType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для Delete
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void Delete1()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            UserEditModel model = null; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.Delete(model);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для DeleteSuccess
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void DeleteSuccess()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            string Status = string.Empty; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.DeleteSuccess(Status);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для Details
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void Details()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            string Name = string.Empty; // TODO: инициализация подходящего значения
            string ViewType = string.Empty; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.Details(Name, ViewType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для Dispose
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        [DeploymentItem("Presentation.dll")]
        public void Dispose()
        {
            UserController_Accessor target = new UserController_Accessor(); // TODO: инициализация подходящего значения
            bool disposing = false; // TODO: инициализация подходящего значения
            target.Dispose(disposing);
            Assert.Inconclusive("Невозможно проверить метод, не возвращающий значение.");
        }

        /// <summary>
        ///Тест для Edit
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void Edit()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            string Name = string.Empty; // TODO: инициализация подходящего значения
            string ViewType = string.Empty; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.Edit(Name, ViewType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для Edit
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void Edit1()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            UserEditModel model = null; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.Edit(model);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для Index
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void Index()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            ViewResult expected = null; // TODO: инициализация подходящего значения
            ViewResult actual;
            actual = target.Index();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для ResetPassword
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void ResetPassword()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            UserEditModel model = null; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.ResetPassword(model);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для ResetPassword
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void ResetPassword1()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            string Name = string.Empty; // TODO: инициализация подходящего значения
            string ViewType = string.Empty; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.ResetPassword(Name, ViewType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для ResetPasswordSuccess
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void ResetPasswordSuccess()
        {
            UserController target = new UserController(); // TODO: инициализация подходящего значения
            string NewPassword = string.Empty; // TODO: инициализация подходящего значения
            string ViewType = string.Empty; // TODO: инициализация подходящего значения
            string UserName = string.Empty; // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.ResetPasswordSuccess(NewPassword, ViewType, UserName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
