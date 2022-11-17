using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PODResourceTranslater
{
    public class CreateResourceService
    {
        private readonly string _exportPath;

        public CreateResourceService(string exportPath)
        {
            this._exportPath = exportPath;
        }

        public void CreateResource(Dictionary<string, string> resources)
        {
        }
    }
}