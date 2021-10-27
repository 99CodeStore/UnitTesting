using NUnit.Framework;
using Fundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundaementals.Tests
{
    [TestFixture()]
    public class CustomerControllerTests
    {
        private CustomerController _customerController;
        [SetUp]
        public void SetupMethod()
        {
            _customerController = new CustomerController();
        }
        [Test()]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var result = _customerController.GetCustomer(0);
            Assert.That(result, Is.TypeOf<NotFound>()); // Only Check the Type of NotFound object Class
        }

        [Test()]
        public void GetCustomer_IdIsGreaterZero_ReturnOk()
        {
            var result = _customerController.GetCustomer(1);
            Assert.That(result, Is.InstanceOf<OK>()); // Check OK and one of its derivatives
        }
    }
}