using EM.Application.Abstract.Services;
using EM.Application.CQRS.Salaries.Queries.GetSalaryStatisticsQuery;
using EM.Application.Models;
using EM.Core.Models;
using EM.Test.Common;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace EM.Test.CQRS.Salaries.Queries.GetSalaryStatistics;

public class GetSalaryStatisticsQueryHandlerTests : BaseTest
{
    private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
    private readonly GetSalaryStatisticsQueryHandler _handler;
    private readonly Mock<ISalaryService> _salaryService;
    
    public GetSalaryStatisticsQueryHandlerTests()
    {
        _userManagerMock = MockUserManager<ApplicationUser>();
        _salaryService = new Mock<ISalaryService>();

        _handler = new GetSalaryStatisticsQueryHandler(_salaryService.Object);
    }

    [Fact]
    public async Task Handle_FilledSalaryStatistics_ReturnsCorrectly()
    {
        //Arrange
        var query = new GetSalaryStatisticsQuery();

        var salaryStatisticResponseModels = new[]
        {
            new SalaryStatisticResponseModel(5, 1000, 2000),
            new SalaryStatisticResponseModel(2, 2000, 3000),
            new SalaryStatisticResponseModel(1, 3000, 5000),
        };
        _salaryService.Setup(x => x.GetEmployeeSalaryStatistics())
            .ReturnsAsync(salaryStatisticResponseModels);

        //Act
        var result = await _handler.Handle(query, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.Equivalent(salaryStatisticResponseModels, result);
    }

    [Fact]
    public async Task Handle_EmptySalaryStatistics_ReturnsEmptyList()
    {
        //Arrange
        var query = new GetSalaryStatisticsQuery();

        _salaryService.Setup(x => x.GetEmployeeSalaryStatistics())
            .ReturnsAsync(Enumerable.Empty<SalaryStatisticResponseModel>());

        //Act
        var result = await _handler.Handle(query, CancellationToken.None);
        
        //Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task Handle_NullSalaryStatistics_ThrowsException()
    {
        //Setup
        var query = new GetSalaryStatisticsQuery();

        _salaryService.Setup(x => x.GetEmployeeSalaryStatistics())!
            .ReturnsAsync((IEnumerable<SalaryStatisticResponseModel>)null!);
        
        //Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _handler.Handle(query, CancellationToken.None));
    }
}