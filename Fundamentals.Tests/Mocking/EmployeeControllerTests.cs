using NUnit.Framework;
using Fundamentals.Mocking;
using Moq;

namespace Fundaementals.UnitTests.Mocking
{
    [TestFixture()]
    public class EmployeeControllerTests
    {

        [Test()]
        public void DeleteEmployee_WhenCalled_DeleteFromDb()
        {
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            controller.Delete(1);
            storage.Verify(s => s.DeleteEmployee(1));

        }

        [Test()]
        public void DeleteEmployee_WhenCalled_ReturnObjectActionResult()
        {
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            var result=controller.Delete(1);

            Assert.That(result, Is.InstanceOf<Fundamentals.ActionResult>());

        }

    }
}