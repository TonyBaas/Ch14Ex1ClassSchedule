using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Controllers;
using Microsoft.AspNetCore.Http;

namespace ClassScheduleTests
{
    public class HomeControllerTests
    {
        /*Needing to dping something to upload*/
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            var uow = new Mock<IClassScheduleUnitOfWork>();
            var classes = new Mock<IRepository<Class>>();
            var days = new Mock<IRepository<Day>>();
            uow.Setup(r => r.Classes).Returns(classes.Object);
            uow.Setup(r => r.Days).Returns(days.Object);

            var http = new Mock<IHttpContextAccessor>();
            var controller = new HomeController(uow.Object, http.Object);

            var result = controller.Index(0);

            Assert.IsType<ViewResult>(result);
        }
    }
}
