using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Queries;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EcoGuardian_UnitTests
{
    [TestFixture]
    public class PlantControllerUnitTests
    {
        private Mock<IPlantCommandService> _mockCommandService;
        private Mock<IPlantQueryService> _mockQueryService;
        private PlantController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockCommandService = new Mock<IPlantCommandService>();
            _mockQueryService = new Mock<IPlantQueryService>();
            _controller = new PlantController(_mockCommandService.Object, _mockQueryService.Object);
        }

        [Test]
        public async Task CreatePlant_Returns201()
        {
            var mockFile = new Mock<IFormFile>().Object;
            var resource = new CreatePlantResource(
                "Test", mockFile, "TestType", 10, 1, 0.5, 0.5, 0.5, false, 1
            );
            _mockCommandService.Setup(s => s.Handle(It.IsAny<CreatePlantCommand>())).ReturnsAsync(new Plant());
            var result = await _controller.CreatePlant(resource) as ObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(201));
            Assert.That(result.Value, Is.Not.Null);
            var value = result.Value;
            var messageProp = value.GetType().GetProperty("message");
            var idProp = value.GetType().GetProperty("id");
            Assert.That(messageProp, Is.Not.Null);
            Assert.That(idProp, Is.Not.Null);
            Assert.That(messageProp.GetValue(value, null), Is.EqualTo("Planta creada exitosamente"));
            Assert.That(idProp.GetValue(value, null), Is.EqualTo(0));
        }

        [Test]
        public async Task GetPlantById_NotFound_Returns404()
        {
            _mockQueryService.Setup(s => s.Handle(It.IsAny<GetPlantByIdQuery>())).ReturnsAsync((Plant?)null);
            var result = await _controller.GetPlantById(999) as NotFoundResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(404));
        }

        [Test]
        public async Task GetPlantsByUserId_ReturnsOkWithList()
        {
            _mockQueryService.Setup(s => s.Handle(It.IsAny<GetPlantsByUserIdQuery>())).ReturnsAsync(new List<Plant>());
            var result = await _controller.GetPlantsByUserId(1) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.InstanceOf<List<PlantResource>>());
        }
    }
}
