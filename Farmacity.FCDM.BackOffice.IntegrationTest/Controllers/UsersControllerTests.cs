using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using System.Net;
using Farmacity.FCDM.BackOffice.IntegrationTest.Helpers;
using Farmacity.FCDM.BackOffice.Context;
 

namespace Farmacity.FCDM.BackOffice.IntegrationTest.Controllers
{
    public class UsersControllerTests : IClassFixture<Request<Startup>>
    {
        private readonly Request<Startup> request;
        private readonly DB_FCDM_BackOfficeContext context;


        public UsersControllerTests( Request<Startup> request)
        {
            this.request = request;
        }

        [Fact]
        public async Task ShouldReturn_AllUsers()
        {
            var response = await request.Get("/api/User");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}