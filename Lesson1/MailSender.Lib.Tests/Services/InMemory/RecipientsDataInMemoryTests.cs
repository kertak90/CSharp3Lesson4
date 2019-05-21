using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSenderLib.Linq2SQL;
using MailSenderLib.Services.InMemory;
using System.Linq;

namespace MailSender.Lib.Tests.Services.InMemory
{
    /// <summary>
    /// Сводное описание для RecipientsDataInMemoryTests
    /// </summary>
    [TestClass]
    public class RecipientsDataInMemoryTests
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestFinalize()
        {

        }

        public RecipientsDataInMemoryTests()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

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

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Add_Method_AddNewItemService()
        {
            //AAA
            //Arange
            string expected_name = "testRecepient";
            string expected_email = "Test email";
            var new_recepient = new Recepients
            {
                Name = expected_name,
                Email = expected_email
            };

            var service = new RecipientsDataInMemory();

            //Act

            var actual_id = service.Add(new_recepient);

            //Assert
            Assert.AreEqual(new_recepient.Id, actual_id);
            Assert.IsTrue(service.GetAll().Contains(new_recepient));


            if (service.GetById(new_recepient.Id) != new_recepient)
                throw new AssertFailedException("В сервисе под указанным идентификатором хранится неверная сущность");
        }

        [TestMethod]
        public void GetById_returnCorrectItem()
        {
            string expected_name = "testRecepient";
            string expected_email = "Test email";
            var new_recepient = new Recepients
            {
                Name = expected_name,
                Email = expected_email
            };
            var service = new RecipientsDataInMemory();
            var max_id = service.GetAll().Max(recipient => recipient.Id);
            var actual_id = service.Add(new_recepient);
            var expected_id = max_id + 1;

            var actual_recipient = service.GetById(expected_id);
            Assert.AreEqual(new_recepient, actual_recipient);
        }

        [TestMethod, Timeout(150), ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetById_Throw_ArgumentOutOfRangeException_OnNegativeId()
        {
            const int id = -5;
            var service = new RecipientsDataInMemory();
            service.GetById(id);
        }
    }
}
