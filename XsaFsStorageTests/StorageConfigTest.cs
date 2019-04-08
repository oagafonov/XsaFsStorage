using NUnit.Framework;
using System;
using XsaFsStorage;
using XsaFsStorageTests.Properties;

namespace XsaFsStorageTests
{
    public class StorageConfigTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_VCAP_SERVICES_Is_Empty_Then_Throw_Exception_Test()
        {
            var storageConfig = new StorageConfig();
            var exception = Assert.Throws<Exception>(() =>
            {
                storageConfig.GetStoragePath();
            });
            Assert.IsTrue(exception.Message.Contains("Environment variable VCAP_SERVICES not found"));
        }

        [Test]
        public void When_VCAP_SERVICES_Is_Passed_Then_Get_Storage_Path_Return_Valid_Path_Test()
        {
            var storageConfig = new StorageConfig(Resources.VCAP_SERVICES);
            Assert.AreEqual("/hana/shared/DEV/xs/bin/../controller_data/fss/929b20ea-bd76-42ad-8dc7-b97ba85c9bef", storageConfig.GetStoragePath());
        }
    }
}