using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using FluentAvalonia.UI.Controls;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.HLE.FileSystem;
using System.Threading.Tasks;

namespace Ryujinx.Ava.UI.Windows
{
    public partial class ModManagerWindow : UserControl
    {
        public ModManagerViewModel ViewModel;

        public ModManagerWindow() { }

        public ModManagerWindow(VirtualFileSystem virtualFileSystem, ulong titleId, string titleName)
        {
            DataContext = ViewModel = new ModManagerViewModel();
        }

        public static async Task Show(VirtualFileSystem virtualFileSystem, ulong titleId, string titleName)
        {
            ContentDialog contentDialog = new()
            {
                PrimaryButtonText = "",
                SecondaryButtonText = "",
                CloseButtonText = "",
                Content = new ModManagerWindow(virtualFileSystem, titleId, titleName),
                Title = string.Format(LocaleManager.Instance[LocaleKeys.ModWindowTitle], titleName, titleId.ToString("X16"))
            };

            Style bottomBorder = new(x => x.OfType<Grid>().Name("DialogSpace").Child().OfType<Border>());
            bottomBorder.Setters.Add(new Setter(IsVisibleProperty, false));

            contentDialog.Styles.Add(bottomBorder);

            await ContentDialogHelper.ShowAsync(contentDialog);
        }

        private void SaveAndClose(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
                ((ContentDialog)Parent).Hide();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            ((ContentDialog)Parent).Hide();
        }

        private void RemoveMod(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OpenLocation(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}