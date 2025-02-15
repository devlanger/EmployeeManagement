using EM.Application.Abstract.Services;
using EM.Application.Extensions;
using EM.Application.CQRS.Common.Exceptions;
using EM.Application.CQRS.Salaries.Commands.GiveSalaryBonus;
using EM.Core.Models;
using EM.Test.Common;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace EM.Test.CQRS.Salaries.Commands.GiveSalaryBonusCommand;

public class GiveSalaryBonusCommandHandlerTests : BaseTest
{
    private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
    private readonly Mock<IBonusService> _bonusServiceMock;
    private readonly GiveSalaryBonusCommandHandler _handler;
    private readonly Mock<IAuditLogService> _auditLogMock;

    public GiveSalaryBonusCommandHandlerTests()
    {
        _userManagerMock = MockUserManager<ApplicationUser>();
        _bonusServiceMock = new Mock<IBonusService>();
        _auditLogMock = new Mock<IAuditLogService>();
        _handler = new GiveSalaryBonusCommandHandler(
            _userManagerMock.Object,
            _bonusServiceMock.Object,
            _auditLogMock.Object);
    }

    [Fact]
    public async Task Handle_UserNotFound_ThrowsException()
    {
        //Arrange
        var command = new Application.CQRS.Salaries.Commands.GiveSalaryBonus.GiveSalaryBonusCommand(1);
        _userManagerMock.Setup(um =>
                um.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync((ApplicationUser)null);

        //Act & Assert
        await Assert.ThrowsAsync<UserNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ValidUser_GivesBonusAndUpdatesUser()
    {
        // Arrange
        var user = new ApplicationUser { Id = 1 };
        var command = new Application.CQRS.Salaries.Commands.GiveSalaryBonus.GiveSalaryBonusCommand(1);

        _userManagerMock.Setup(um => um.FindByIdAsync(command.EmployeeId))
            .ReturnsAsync(user);
        _userManagerMock.Setup(um => um.UpdateAsync(user))
            .ReturnsAsync(IdentityResult.Success);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _bonusServiceMock.Verify(bs => bs.GiveBonus(user, 0.2m), Times.Once);
        _userManagerMock.Verify(um => um.UpdateAsync(user), Times.Once);
    }

    [Fact]
    public async Task Handle_UpdateFails_ThrowsException()
    {
        //Arrange
        var user = new ApplicationUser() { Id = 1 };
        var command = new Application.CQRS.Salaries.Commands.GiveSalaryBonus.GiveSalaryBonusCommand(1);

        _userManagerMock.Setup(x => x.FindByIdAsync(command.EmployeeId))
            .ReturnsAsync(user);
        _userManagerMock.Setup(x => x.UpdateAsync(user))
            .ThrowsAsync(new Exception());
        
        //Act && Assert
        await Assert.ThrowsAsync<UserUpdateException>(() => _handler.Handle(command, CancellationToken.None));
    }
}