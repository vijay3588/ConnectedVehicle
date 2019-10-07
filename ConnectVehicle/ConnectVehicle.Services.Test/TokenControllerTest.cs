using ConnectVehicle.Services.Controllers;
using ConnectVehicle.Services.Model;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TokenControllerTest
    {
        //Moq.Mock<Microsoft.Extensions.Configuration.IConfiguration> configuration = null;
        LoginModel loginModel = new LoginModel();
        TokenController tokenController = null;

        [SetUp]
        public void Init()
        {
            loginModel.UserName = "scania";
            loginModel.Password = "secret";
            tokenController  = new TokenController(ConnectVehicle.Services.Test.TestHelper.GetIConfigurationRoot());

            //configuration = new Moq.Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            //configuration.Setup(c => c.GetSection(Moq.It.IsAny<System.String>())).Returns(new Moq.Mock<Microsoft.Extensions.Configuration.IConfigurationSection>().Object);
        }

        /// <summary>
        /// Testing the Token controller method "CreateToken". Return status OK
        /// </summary>
        [Test]
        public void TestCreateToken_ReturnStatus_OK()
        {
            var status = tokenController.CreateToken(loginModel);
            Assert.AreEqual(200, (status as Microsoft.AspNetCore.Mvc.OkObjectResult).StatusCode);
        }

        /// <summary>
        /// Testing the Token controller method "CreateToken". Return status NOT OK
        /// </summary>
        [Test]
        public void TestCreateToken_ReturnStatus_NOTOK()
        {
            loginModel.UserName = "scania1";
            var status = tokenController.CreateToken(loginModel);
            Assert.AreEqual(401, (status as Microsoft.AspNetCore.Mvc.StatusCodeResult).StatusCode);
        }
    }
}