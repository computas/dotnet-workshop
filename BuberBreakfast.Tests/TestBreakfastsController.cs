using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BuberBreakfast.Controllers;
using BuberBreakfast.Dtos.Breakfast.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace BuberBreakfast.Tests;

public class TestBreakFastsController
{
    [Fact]
    public void Should_return_200_ok_on_success()
    {
        // Arrange
        var mockBreakfastService = new Mock<IBreakfastService>();
        ErrorOr<Breakfast> breakfast = new Breakfast(Guid.Empty, "Oatmeal", "Oatmeal is a preparation of oats", DateTime.Now, DateTime.Now, DateTime.Now, new List<string>(), new List<string>());;

        mockBreakfastService
            .Setup(service => service.GetBreakfast(It.IsAny<Guid>()))
            .Returns(breakfast);

        var sut = new BreakfastsController(mockBreakfastService.Object);

        // Act
        var result = sut.GetBreakfast(Guid.NewGuid()) as ObjectResult;

        // Assert
        mockBreakfastService.Verify(
            service => service.GetBreakfast(It.IsAny<Guid>()),
            Times.Once);

        // TODO Oppgave #3-> test at statuscode er slik som forventet
    }

    [Fact]
    public void Should_return_500_and_problem_response_on_error()
    {
        // Arrange
        var mockBreakfastService = new Mock<IBreakfastService>();

        mockBreakfastService
            .Setup(service => service.GetBreakfast(It.IsAny<Guid>()))
            .Returns(new Error());


        var sut = new BreakfastsController(mockBreakfastService.Object);

        // Act
        var result = sut.GetBreakfast(Guid.NewGuid()) as ObjectResult;
        var breakfastResponse = result?.Value as ProblemDetails;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, result?.StatusCode);
        Assert.IsType<ProblemDetails>(breakfastResponse);
    }
}