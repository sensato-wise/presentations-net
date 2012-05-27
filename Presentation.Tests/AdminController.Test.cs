using Presentation.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;

namespace Presentation.Tests
{
    
    
    /// <summary>
    ///Это класс теста для AdminController_Test, в котором должны
    ///находиться все модульные тесты AdminController_Test
    ///</summary>
    [TestClass()]
    public class AdminController_Test
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
        ///Тест для Конструктор AdminController
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void AdminControllerConstructor()
        {
            AdminController target = new AdminController();
            Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для Dashboard
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\[work]\\last\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void Dashboard()
        {
            AdminController target = new AdminController(); // TODO: инициализация подходящего значения
            ActionResult expected = null; // TODO: инициализация подходящего значения
            ActionResult actual;
            actual = target.Dashboard();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
