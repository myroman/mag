using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Business.Services;

using Moq;

using NUnit.Framework;

namespace Mag.Business.Tests.Account
{
    [TestFixture]
    [Category("UserService")]
    public class UserServiceTests
    {
        [Test]
        public void RightAccessCodeDoesntThrowException_Test()
        {
            var m = new Mock<IAgentsRepository>();
            m.Setup(x => x.Add(It.IsAny<Agent>()));
            m.Setup(x => x.FindByEmail(It.IsAny<string>())).Returns((Agent)null);

            var a = new Mock<IAccountSettings>();
            a.Setup(x => x.RegistrationAccessCode).Returns("some code");

            var userService = new UserService(m.Object, new SimpleAes(), a.Object);
            var user = AgentFactory.Mock.KnowsAccessCode("some code");
            try
            {
                userService.RegisterUser(user);
            }
            catch (DomainException)
            {
                Assert.Fail("This exception shouldn't have been thrown!");
            }
            
            m.Verify(x => x.Add(It.IsAny<Agent>()), Times.Exactly(1));
        }

        [Test]
        public void WrongAccessCodeThrowsException_Test()
        {
            var m = new Mock<IAgentsRepository>();
            m.Setup(x => x.Add(It.IsAny<Agent>()));
            var a = new Mock<IAccountSettings>();
            a.Setup(x => x.RegistrationAccessCode).Returns("some code");

            var userService = new UserService(m.Object, new SimpleAes(), a.Object);
            var user = AgentFactory.Mock;
            try
            {
                userService.RegisterUser(user);
            }
            catch (DomainException exc)
            {
                Assert.AreEqual("Вы ввели неверный код доступа", exc.Message);
                return;
            }
            Assert.Fail();
        }
    }
}