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

        public Dictionary<string, ResourceEntity> GetAllResources()
        {
            Dictionary<string, ResourceEntity> result = new Dictionary<string, ResourceEntity>();

            string[] pathsToResources = Directory.GetFiles(this._importPath, "*.resx", SearchOption.AllDirectories);
            var serializer = new XmlSerializer(typeof(ResourceEntity));

            foreach (string resourcePath in pathsToResources)
            {
                using (Stream reader = new FileStream(resourcePath, FileMode.Open))
                {
                    result.Add(resourcePath, (ResourceEntity)serializer.Deserialize(reader)!);
                }
            }

            return result;
        }
    }
}