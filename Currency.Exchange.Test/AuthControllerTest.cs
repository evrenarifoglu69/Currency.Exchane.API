using Currency.Exchange.API.Controllers;
using Currency.Exchange.Test.Fixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace Currency.Exchange.Test
{
    public class AuthControllerTest : IClassFixture<ControllerFixture>
    {
        AuthController authController;

        public AuthControllerTest(ControllerFixture fixture)
        {
            authController = fixture.authController;
        }

        [Fact]
        public void Get_WithoutParam_Ok_Test()
        {
            var result = authController.GetUserInfo().Result as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.True((result.Value as string[]).Length == 2);
        }
    }
}
