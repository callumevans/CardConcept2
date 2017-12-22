using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication5.Api.Controllers;
using WebApplication5.Api.Requests;
using WebApplication5.Api.Services;
using Xunit;

namespace Api.Tests
{
    public class AccountsTests
    {
        private readonly AccountService accountService;

        private readonly AuthController controller;

        public AccountsTests()
        {
            accountService = new AccountService();

            controller = new AuthController(accountService);
        }

        [Fact]
        public async Task CreateAccount_ReturnsCreatedAtRouteResult()
        {
            // Arrange
            var request = new CreateAccount
            {
                EmailAddress = "test@email.com",
                Password = "testpassword"
            };

            // Act
            var result = await controller.Register(request);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }
    }
}
