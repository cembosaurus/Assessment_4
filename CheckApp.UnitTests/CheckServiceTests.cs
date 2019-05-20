using CheckApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Check.Controllers;
using Moq;

namespace CheckApp.UnitTests
{
    [TestFixture]
    class CheckServiceTests
    {

        private ICheckService _service;
        private Mock<ICheckService> _service_m; 

        [SetUp]
        public void SetUp()
        {
            _service = new CheckService();
            _service_m = new Mock<ICheckService>();
        }


        [Test]
        [TestCase(3005000150.65, "Three Billion, Five Million, One Hundred Fifty Dollars and Sixty-Five Cents")]
        [TestCase(0.1, "Zero Dollars and Ten Cents")]
        [TestCase(123.45, "One Hundred Twenty Three Dollars and Fourty-Five Cents")]
        public void MoneyToWords_WhenDecimal_ReturnNumberInWords(decimal d, string expectedResult)
        {
            var service = new CheckService();
            var result = service.MoneyToWords(d);

            Assert.That(result, Is.EqualTo(expectedResult));
        }



    }
}
