using System.IO;

namespace XsaFsStorage
{
    internal class Storage
    {
        private readonly StorageConfig _config;
        public Storage()
        {
#if Debug
            _config = new StorageConfig(@"{
    'fs-storage': [
        {
            'name': 'pump-storage',
            'label': 'fs-storage',
            'tags': [],
            'plan': 'free',
            'credentials': {
                'storage-path': '/hana/shared/DEV/xs/bin/../controller_data/fss/929b20ea-bd76-42ad-8dc7-b97ba85c9bef'
            },
            'volume_mounts': [
                {
                    'mode': 'rw',
                    'device_type': 'shared',
                    'container_dir': 'g:\\temp\\pump-temp'
                }
            ]
        }
    ]
}");
#else
            _config = new StorageConfig();
#endif
        }

        public string GetContent()
        {
            CreateIfNotExists();
            return File.ReadAllText(FileName);
        }

        public void AddText(string text)
        {
            CreateIfNotExists();

            File.AppendAllText(FileName, text);
        }

        private void CreateIfNotExists()
        {
            if (!File.Exists(FileName))
            {
                using (File.Create(FileName))
                {

                }
            }
        }

        private string FileName => Path.Combine(_config.GetStoragePath(), "test.txt");
    }
}
