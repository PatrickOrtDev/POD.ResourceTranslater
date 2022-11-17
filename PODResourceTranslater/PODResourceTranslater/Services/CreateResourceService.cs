using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PODResourceTranslater.Services
{
    public class CreateResourceService
    {
        private readonly string _exportPath;
        private readonly bool _useExportPaths;

        public CreateResourceService(string exportPath, bool useExportPaths)
        {
            this._exportPath = exportPath;
            _useExportPaths = useExportPaths;
        }

        public void CreateResource(Dictionary<string, Dictionary<string, string>> resources)
        {
        }
    }
}