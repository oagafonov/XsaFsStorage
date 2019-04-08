using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace XsaFsStorage
{
    public sealed class StorageConfig
    {
        private readonly string _xsaServices;

        public StorageConfig()
        {

        }

        public StorageConfig(string xsaServices)
        {
            _xsaServices = xsaServices;
        }

        public string GetStoragePath()
        {
            var xsaServices = Environment.GetEnvironmentVariable("VCAP_SERVICES") ?? _xsaServices;
            if (string.IsNullOrWhiteSpace(xsaServices))
            {
                throw new Exception("Environment variable VCAP_SERVICES not found");
            }

            var xsaServicesJObject = JObject.Parse(xsaServices);
            return xsaServicesJObject["fs-storage"].ToObject<JArray>().Where(i => i["name"].Value<string>() == "pump-storage").First()["volume_mounts"].ToObject<JArray>().First()["container_dir"].Value<string>();
        }
    }
}
