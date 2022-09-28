using System;
using System.Collections.Generic;
using BuberBreakfast.Controllers;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using ErrorOr;
using Xunit;
using Moq;

namespace BuberBreakfast.Tests;

public class TestBreakFastsController
{
    [Fact]
    public void Get_OnSuccess_InvokeBreakfastService()
    {
        // Arrange
        var mockBreakfastService = new Mock<IBreakfastService>();
        ErrorOr<Breakfast> breakfast = new Breakfast(Guid.Empty, "Oatmeal", "Oatmeal is a preparation of oats", DateTime.Now, DateTime.Now, DateTime.Now, new List<string>(), new List<string>());;

        mockBreakfastService
            .Setup(service => service.GetBreakfast(It.IsAny<Guid>()))
            .Returns(breakfast);

        var sut = new BreakfastsController(mockBreakfastService.Object);

        // Act
        sut.GetBreakfast(Guid.NewGuid());

        // Assert
        mockBreakfastService.Verify(
            service => service.GetBreakfast(It.IsAny<Guid>()),
            Times.Once);
    }
}