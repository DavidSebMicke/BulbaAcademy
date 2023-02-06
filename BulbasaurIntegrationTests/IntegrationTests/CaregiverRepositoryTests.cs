using BulbasaurAPI.Models;
using BulbasaurAPI.Repository;
using System.Security;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace BulbasaurIntegrationTests.IntegrationTests
{
    public class CaregiverRepositoryTests : IClassFixture<TestDatabaseFixture>
    {
        private TestDatabaseFixture _databaseFixture { get; }
        private ITestOutputHelper _outputHelper { get; }

        public CaregiverRepositoryTests(TestDatabaseFixture databaseFixture, ITestOutputHelper testOutputHelper)
        {
            _databaseFixture = databaseFixture;
            _outputHelper = testOutputHelper;
        }

        [Fact]
        public async Task GetById_DoesntExistReturnsNull()
        {
            await using var transaction = await _databaseFixture.Connection.BeginTransactionAsync();

            var caregiverId = 21;

            using var context = _databaseFixture.CreateContext(transaction);
            var caregiverRepo = new CaregiverRepository(context);

            var caregiver = await caregiverRepo.GetById(caregiverId);

            Assert.Null(caregiver);
        }

        [Fact]
        public async Task GetAll()
        {
            await using var transaction = await _databaseFixture.Connection.BeginTransactionAsync();
            using var context = _databaseFixture.CreateContext(transaction);
            var caregiverRepo = new CaregiverRepository(context);

            var caregivers = await caregiverRepo.GetAll();

            Assert.Equal(Constants.PeopleToGenerate, caregivers.Count());
        }

        [Fact]
        public async Task CreateCaregiver()
        {
            await using var transaction = await _databaseFixture.Connection.BeginTransactionAsync();

            var caregiverId = 0;

            var reqObject = new Caregiver()
            {
                SSN = "199701011234",
                FirstName = "FirstnameTest",
                LastName = "LastnameTest",
                HomeAddress = new Address("TestStreet", "TestCity", 12345),
                PhoneNumber = "0712345678",
                EmailAddress = "test@email.com"
            };

            using (var context = _databaseFixture.CreateContext(transaction))
            {
                var caregiverRepo = new CaregiverRepository(context);

                var caregiver = await caregiverRepo.Create(reqObject);
                await caregiverRepo.SaveChangesAsync();

                caregiverId = caregiver.Id;
            }

            using (var context = _databaseFixture.CreateContext(transaction))
            {
                var caregiverRepo = new CaregiverRepository(context);

                var fetchedCaregiver = await caregiverRepo.GetById(caregiverId);

                Assert.NotNull(fetchedCaregiver);
                Assert.Equal(reqObject.SSN, fetchedCaregiver.SSN);
                Assert.Equal(reqObject.FirstName, fetchedCaregiver.FirstName);
                Assert.Equal(reqObject.LastName, fetchedCaregiver.LastName);
                Assert.Equal(reqObject.HomeAddress.StreetAddress, fetchedCaregiver.HomeAddress.StreetAddress);
                Assert.Equal(reqObject.HomeAddress.City, fetchedCaregiver.HomeAddress.City);
                Assert.Equal(reqObject.HomeAddress.PostalCode, fetchedCaregiver.HomeAddress.PostalCode);
                Assert.Equal(reqObject.PhoneNumber, fetchedCaregiver.PhoneNumber);
                Assert.Equal(reqObject.EmailAddress, fetchedCaregiver.EmailAddress);
            }
        }

        [Fact]
        public async Task UpdateCaregiver()
        {
            await using var transaction = await _databaseFixture.Connection.BeginTransactionAsync();

            var caregiverId = 8;

            Caregiver reqObject;

            using (var context = _databaseFixture.CreateContext(transaction))
            {
                var caregiverRepo = new CaregiverRepository(context);

                reqObject = await caregiverRepo.GetById(caregiverId);

                Assert.NotNull(reqObject);

                reqObject.SSN = "200001011234";
                reqObject.FirstName = "Changed name";
                reqObject.LastName = "Change name";
                reqObject.PhoneNumber = "+468727632";
                reqObject.EmailAddress = "NewEmail@email.com";
                reqObject.HomeAddress.StreetAddress = "New street";
                reqObject.HomeAddress.City = "New city";
                reqObject.HomeAddress.PostalCode = 12345;

                await caregiverRepo.Update(reqObject);

                await caregiverRepo.SaveChangesAsync();
            }

            using (var context = _databaseFixture.CreateContext(transaction))
            {
                var caregiverRepo = new CaregiverRepository(context);

                var fetchedCaregiver = await caregiverRepo.GetById(caregiverId);

                Assert.NotNull(fetchedCaregiver);
                Assert.Equal(reqObject.SSN, fetchedCaregiver.SSN);
                Assert.Equal(reqObject.FirstName, fetchedCaregiver.FirstName);
                Assert.Equal(reqObject.LastName, fetchedCaregiver.LastName);
                Assert.Equal(reqObject.HomeAddress.StreetAddress, fetchedCaregiver.HomeAddress.StreetAddress);
                Assert.Equal(reqObject.HomeAddress.City, fetchedCaregiver.HomeAddress.City);
                Assert.Equal(reqObject.HomeAddress.PostalCode, fetchedCaregiver.HomeAddress.PostalCode);
                Assert.Equal(reqObject.PhoneNumber, fetchedCaregiver.PhoneNumber);
                Assert.Equal(reqObject.EmailAddress, fetchedCaregiver.EmailAddress);
            }
        }
    }
}