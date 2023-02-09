using Avalonia.Collections;
using DynamicData;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Models;

namespace Ryujinx.Ava.UI.ViewModels
{
    public class ModManagerViewModel : BaseModel
    {
        private AvaloniaList<ModModel> _mods = new();
        private AvaloniaList<ModModel> _views = new();
        private AvaloniaList<ModModel> _selectedMods = new();

        private string _search;

        public AvaloniaList<ModModel> Mods
        {
            get => _mods;
            set
            {
                _mods = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ModCount));
                Sort();
            }
        }

        public AvaloniaList<ModModel> Views
        {
            get => _views;
            set
            {
                _views = value;
                OnPropertyChanged();
            }
        }

        public AvaloniaList<ModModel> SelectedMods
        {
            get => _selectedMods;
            set
            {
                _selectedMods = value;
                OnPropertyChanged();
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged();
                Sort();
            }
        }

        public string ModCount
        {
            get => string.Format(LocaleManager.Instance[LocaleKeys.DlcWindowHeading], Mods.Count);
        }

        public ModManagerViewModel()
        {
            LoadMods();
        }

        private void LoadMods()
        {

        }

        public void Sort()
        {
            Mods.AsObservableChangeSet()
                .Filter(Filter)
                .Bind(out var view).AsObservableList();

            _views.Clear();
            _views.AddRange(view);
            OnPropertyChanged(nameof(Views));
        }

        private bool Filter(object arg)
        {
            if (arg is DownloadableContentModel content)
            {
                // return string.IsNullOrWhiteSpace(_search) || content.FileName.ToLower().Contains(_search.ToLower()) || content.TitleId.ToLower().Contains(_search.ToLower());
            }

            return false;
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}