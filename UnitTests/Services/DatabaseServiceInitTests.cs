using NUnit.Framework;
using System.Threading.Tasks;

using Game.Models;
using Game.Services;

namespace UnitTests.Services
{
    /// <summary>
    /// This test file is separate from the DatabaseService Tests because it allows it to run in standard mode, rather than test mode.
    /// 
    /// Only test needed is the if statement on the mode
    /// 
    /// Constructor is enough to get to that code
    /// 
    /// </summary>
    [TestFixture]
    public class DatabaseServiceInitTests
    {
        DatabaseService<BodyPartModel> DataStore;

        [SetUp]
        public void Setup()
        {
            DataStore = DatabaseService<BodyPartModel>.Instance;
        }

        [TearDown]
        public async Task TearDown()
        {
            await DataStore.WipeDataListAsync();
        }

        [Test]
        public void DatabaseService_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DataStore;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void DatabaseService_GetDataConnection_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DatabaseService<BodyPartModel>.GetDataConnection();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}