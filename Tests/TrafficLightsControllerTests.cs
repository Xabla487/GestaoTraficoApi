// Tests/TrafficLightsControllerTests.cs
using Microsoft.AspNetCore.Mvc;

public class TrafficLightsControllerTests
{
    // ... (configuração do teste)

    [Fact]
    public async Task GetTrafficLights_ReturnsOkResult()
    {
        // Arrange
        var controller = new TrafficLightsController(_mockTrafficLightService.Object);

        // Act
        var result = await controller.GetTrafficLights();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Value.Should().BeOfType<TrafficLightsViewModel>();
    }
}
