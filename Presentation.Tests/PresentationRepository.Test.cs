using Presentation.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace Presentation.Tests
{
    
    
    /// <summary>
    ///Это класс теста для PresentationRepository_Test, в котором должны
    ///находиться все модульные тесты PresentationRepository_Test
    ///</summary>
    [TestClass()]
    public class PresentationRepository_Test
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
        ///Тест для AddNewVote
        ///</summary>
        // TODO: убедитесь, что в атрибуте UrlToTest содержится URL-адрес страницы ASP.NET (например: 
        // http://.../Default.aspx). Это требуется для выполнения модульного теста на веб-сервере 
        // при тестировании страницы, веб-службы или службы WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("d:\\[work]\\pulled\\presentations-net\\Presentation", "/")]
        [UrlToTest("http://localhost:4737/")]
        public void AddNewVote()
        {
            PresentationRepository target = new PresentationRepository(); // TODO: инициализация подходящего значения
            Guid UserId = new Guid("419edc31-ff6f-4385-a1a5-7ecb47806465"); // TODO: инициализация подходящего значения
            int PresentationId = 18; // TODO: инициализация подходящего значения
            float Rating = 2F; // TODO: инициализация подходящего значения
            target.AddNewVote(UserId, PresentationId, Rating);
            Assert.Inconclusive("Невозможно проверить метод, не возвращающий значение.");
        }
    }
}
