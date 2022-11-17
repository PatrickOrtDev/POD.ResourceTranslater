using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PODResourceTranslater.Services
{
    public class GetResourcesService
    {
        private readonly string _importPath;

        public GetResourcesService(string importPath)
        {
            this._importPath = importPath;
            this._importPath =
                @"C:\Users\Portm\Documents\GitHub\POD.ResourceTranslater\PODResourceTranslater\PODResourceTranslater\";
        }

        public Dictionary<string, Dictionary<string, string>> GetAllResources()
        {
            var result = new Dictionary<string, Dictionary<string, string>>();

            string[] pathsToResources = Directory.GetFiles(this._importPath, "*.resx", SearchOption.AllDirectories);
            var serializer = new XmlSerializer(typeof(ResourceEntity));

            foreach (string resourcePath in pathsToResources)
            {
                ResourceEntity resourceEntity;
                using (Stream reader = new FileStream(resourcePath, FileMode.Open))
                {
                    resourceEntity = (ResourceEntity)serializer.Deserialize(reader)!;
                    foreach (var data in resourceEntity.Data)
                    {
                        if (!result.ContainsKey(resourcePath))
                        {
                            result.Add(resourcePath, new Dictionary<string, string>());
                        }

                        result[resourcePath].Add(data.Name, data.Value);
                    }
                }
            }

            return result;
        }
    }
}