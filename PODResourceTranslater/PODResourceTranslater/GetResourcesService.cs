using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PODResourceTranslater
{
    public class GetResourcesService
    {
        private readonly string _importPath;

        public GetResourcesService(string importPath)
        {
            this._importPath = importPath;
        }

        public Dictionary<string, string> GetAllResources()
        {
        }
    }
}