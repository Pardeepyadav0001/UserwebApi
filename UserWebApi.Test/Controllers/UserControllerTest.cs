using System.Threading.Tasks;
using EntityframeworkCore.MySql.Controllers;
using EntityframeworkCore.MySql.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



using UserWebApi.Models;
using Xunit;

namespace UserWebApi.Test.Controllers
{
    public class UserControllerTest
    {
        private DbContextOptions<AppDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql("Server=localhost;Port=3306;Database=User;User=root;Pwd=admin;",
                    new MySqlServerVersion(new Version(8, 0, 23))) // Specify your MySQL server version
                .Options;
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            using (var context = new AppDbContext(GetDbContextOptions()))
            {
                var controller = new UserController(context);

                // Act
                var result = await controller.GetAll() as OkObjectResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal(200, result.StatusCode);
                // Add more assertions based on your specific implementation
            }
        }

      
    }
}
