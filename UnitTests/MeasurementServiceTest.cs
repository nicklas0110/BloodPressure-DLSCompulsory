using AutoMapper;
using MeasurementService.Core.Entities;
using MeasurementService.Core.DTOs;
using MeasurementService.Core.Repositories.Interfaces;
using Moq;
using Xunit;    


namespace UnitTests;

public class MeasurementServiceTest
{
    private readonly MeasurementService.Services.MeasurementService _service;
    private readonly Mock<IMeasurementRepository> _measurementRepositoryMock = new Mock<IMeasurementRepository>();
    private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

    public MeasurementServiceTest()
    {
        _service = new MeasurementService.Services.MeasurementService(_measurementRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task DeleteMeasurementById_validId()
    {
        // Arrange
        int validId = 1;
        _measurementRepositoryMock.Setup(r => r.DeleteMeasurement(validId)).Returns(Task.CompletedTask);

        // Act
        await _service.DeleteMeasurement(validId);

        // Assert
        _measurementRepositoryMock.Verify(r => r.DeleteMeasurement(validId), Times.Once);

    }

    // [Fact]
    // public async Task DeleteMeasurementById_InvalidId()
    // {
    //     // Arrange
    //     int invalidId = 0;
    //
    //     // Act & Assert
    //     ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(
    //         () => _service.DeleteMeasurement(invalidId)
    //     );
    //
    //     Assert.Equal("Id cannot be less than 1", exception.Message);
    // }
}