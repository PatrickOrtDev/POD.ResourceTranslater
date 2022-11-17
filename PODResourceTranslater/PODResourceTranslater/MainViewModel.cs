using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeepL;
using PODResourceTranslater.Commands;
using PODResourceTranslater.Services;

namespace PODResourceTranslater
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private CreateResourceService _createResourceService;
        private GetResourcesService _getResourceService;

        private Dictionary<string, ResourceEntity> _entities;

        public Dictionary<string, ResourceEntity> Entities
        {
            get { return this._entities; }
            set
            {
                this._entities = value;
                this.OnPropertyChanged(nameof(this.Entities));
                this.OnPropertyChanged(nameof(this.EntityListView));
            }
        }

        public Dictionary<string, ResourceEntity> EntityListView
        {
            get
            {
                Dictionary<string, ResourceEntity> result = new Dictionary<string, ResourceEntity>();
                if (Entities == null)
                {
                    return result;
                }

                foreach (var entity in Entities)
                {
                    result.Add(entity.Key.Split('\\').Last(), entity.Value);
                }

                return result;
            }
        }

        private string _authenticationKey;
        public string AuthenticationKey { get; set; }


        private string _importPath;
        public string ImportPath { get; set; }


        private string _exportPath;
        public string ExportPath { get; set; }


        public ICommand PreviewCommand { get; set; }

        public MainViewModel()
        {
            _createResourceService = new CreateResourceService("asd", false);
            _getResourceService = new GetResourcesService("asdas");
            var read = new GetResourcesService("abc");
            PreviewCommand = new RelayCommand(OnPreviewCommand);
        }

        private void OnPreviewCommand()
        {
            this.Entities = _getResourceService.GetAllResources();
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}