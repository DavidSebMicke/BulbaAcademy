using BulbasaurAPI.Models;
using BulbasaurAPI.Repository;

namespace BulbasaurIntegrationTests.IntegrationTests
{
    public class CaregiverRepositoryTests : IClassFixture<TestDatabaseFixture>
    {
        private TestDatabaseFixture _databaseFixture { get; }

        public CaregiverRepositoryTests(TestDatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
        }

        [Fact]
        public async Task CreateCaregiver()
        {
            using var transaction = _databaseFixture.Connection.BeginTransaction();

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
                var caregiver = caregiverRepo.Create(reqObject);

                caregiverId = caregiver.Id;
            }

            using (var context = _databaseFixture.CreateContext(transaction))
            {
                var caregiverRepo = new CaregiverRepository(context);
                var caregiver = await caregiverRepo.GetById(caregiverId);

                Assert.NotNull(caregiver);
                Assert.Equal(reqObject.SSN, caregiver.SSN);
                Assert.Equal(reqObject.FirstName, caregiver.FirstName);
                Assert.Equal(reqObject.LastName, caregiver.LastName);
                Assert.Equal(reqObject.HomeAddress.StreetAddress, caregiver.HomeAddress.StreetAddress);
                Assert.Equal(reqObject.HomeAddress.City, caregiver.HomeAddress.City);
                Assert.Equal(reqObject.HomeAddress.PostalCode, caregiver.HomeAddress.PostalCode);
                Assert.Equal(reqObject.PhoneNumber, caregiver.PhoneNumber);
                Assert.Equal(reqObject.EmailAddress, caregiver.EmailAddress);
            }
        }
    }
}