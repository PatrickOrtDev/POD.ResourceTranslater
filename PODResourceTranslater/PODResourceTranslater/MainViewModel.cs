using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PODResourceTranslater.Commands;
using PODResourceTranslater.Services;

namespace PODResourceTranslater
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private CreateResourceService _createResourceService;
        private GetResourcesService _getResourceService;

        private Dictionary<string, Dictionary<string, string>> _previewListView;

        public Dictionary<string, Dictionary<string, string>> PreviewListView
        {
            get { return this._previewListView; }
            set
            {
                this._previewListView = value;
                this.OnPropertyChanged(nameof(this.PreviewListView));
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
            read.GetAllResources();
            PreviewCommand = new RelayCommand(OnPreviewCommand);
        }

        private void OnPreviewCommand()
        {
            this.PreviewListView = _getResourceService.GetAllResources();
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