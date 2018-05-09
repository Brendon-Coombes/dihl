using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using DIHL.Application.Core.Exceptions;
using DIHL.Application.Core.Utilities;
using Moq;
using Serilog;
using Xunit;

namespace DIHL.Application.Core.Tests.Utilities
{
    public class ConnectedServiceActionHandlerTests
    {
        private readonly IFixture _fixture;
        private const string _serviceName = "TestService";

        public ConnectedServiceActionHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        [Fact]
        public async Task ExecuteRunsOperationAndReturnsResult()
        {
            //Arrange
            var coreActionHandler = new ConnectedServiceActionHandler(_serviceName);
            var log = new Mock<ILogger>();

            async Task<bool> func()
            {
                await Task.Yield();
                return true;
            }

            //Act
            var result = await coreActionHandler.Execute(log.Object, func);

            //Assert
            Assert.True(result);
            log.Verify(a => a.Error(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }
      

        [Fact]
        public async Task ExecuteRethrowsIPassThroughExceptionAndDoesNotLog()
        {
            //Arrange
            var coreActionHandler = new ConnectedServiceActionHandler(_serviceName);
            var log = new Mock<ILogger>();

            async Task func()
            {
                await Task.Yield();
                throw _fixture.Build<RecordNotFoundException>().Create();
            }

            //Act
            var exception = await Assert.ThrowsAsync<RecordNotFoundException>(async () => await coreActionHandler.Execute(log.Object, func));

            //Assert
            Assert.NotNull(exception);
            log.Verify(a => a.Error(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ExecuteWrapsUnexpectedExceptionAndLogs()
        {
            //Arrange
            var coreActionHandler = new ConnectedServiceActionHandler(_serviceName);
            var log = new Mock<ILogger>();

            var exceptionToThrow = _fixture.Build<Exception>().Create();

            async Task func()
            {
                await Task.Yield();
                throw exceptionToThrow;
            }

            //Act
            var exception = await Assert.ThrowsAsync<ConnectedServiceException>(async () => await coreActionHandler.Execute(log.Object, func));

            //Assert
            Assert.NotNull(exception);
            Assert.NotNull(exception.InnerException);
            Assert.Equal(exceptionToThrow, exception.InnerException);
            Assert.NotEqual(Guid.Empty, exception.CorrelationId);
            log.Verify(a => a.Error(It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
        }
    }
}
