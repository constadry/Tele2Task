using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Moq;
using Tele2Task.Models;
using Tele2Task.Repositories;
using Tele2Task.Services;
using Xunit;

namespace Tele2Task.Tests;

public class UserServiceTest
{
    private readonly IUserService _userService;
    private readonly UserParameters _userParams;
    private readonly Mock<IUserRepository> _mockRepository;

    public UserServiceTest()
    {
        _mockRepository = new Mock<IUserRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        _userService = new UserService(_mockRepository.Object, mockUnitOfWork.Object);
        _userParams = new UserParameters();
    }
    
    [Fact]
    public async Task GetAllUsers()
    {
        _mockRepository.Setup(repo=> repo.GetAll(_userParams)).Returns(GetTestUsers);

        var result = await _userService.GetAll(_userParams);

        Assert.Equal(GetTestUsers().Result.Count(), result.Count());
    }

    [Fact]
    public async Task GetUser()
    {
        const string userId = "dfssasd2";
        _mockRepository.Setup(repo=> repo.Get(userId)).Returns(GetTestUser);

        var result = await _userService.Get(userId);

        Assert.Equal(GetTestUser().Result.Name, result.User.Name);
    }

    private static async Task<User> GetTestUser()
    {
        return new User
        {
            UserId = "dfssasd2",
            Name = "Dave",
            Age = 35,
            Sex = Sex.Male
        };
    }

    private static async Task<IEnumerable<User>> GetTestUsers()
    {
        var users = new List<User>
        {
            new() { UserId = "sasvsd1", Name = "Tom", Age = 35, Sex = Sex.Male},
            new() { UserId = "sasvfd1", Name = "Alice", Age = 29, Sex = Sex.Female},
            new() { UserId = "sgsvsd1", Name = "Sam", Age = 32, Sex = Sex.Male},
            new() { UserId = "sasvbd1", Name = "Kate", Age = 30, Sex = Sex.Female}
        };
        return users;
    }
}