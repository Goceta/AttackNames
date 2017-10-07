using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using AttackNames.Metadata;
using AttackNames.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AttackNames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<ImageWrapper> imagesCollection;

        public MainPage()
        {
            this.InitializeComponent();

            imagesCollection = new ObservableCollection<ImageWrapper>();
            this.imagesGridView.ItemsSource = imagesCollection;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            LocalDatabase temp = new LocalDatabase();
            temp.SaveDatabase();
        }

        private async void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImageWrapper newImage = await this.OpenImage();

            if (newImage != null)
            {
                await this.ShowAddEntryDialog(newImage);
            }
        }

        private async void AddTemporaryButton_Click(object sender, RoutedEventArgs e)
        {
            ImageWrapper newImage = new ImageWrapper();
            newImage.FilePath = string.Empty;

            await this.ShowAddEntryDialog(newImage);
        }

        private async void AddFolderButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement
            await Task.FromResult<string>(null);
        }

        private void imagesGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.UpdateDetails(e?.ClickedItem as ImageWrapper);
        }

        private async Task<ImageWrapper> OpenImage()
        {
            ImageWrapper attack = null;

            var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            filePicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFile file = await filePicker.PickSingleFileAsync();
            // TODO: preserve info from the StorageFile, such as filename and possibly path
            if (file != null)
            {
                BitmapImage bitmapImage = new BitmapImage();
                var fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                bitmapImage.SetSource(fileStream);

                attack = new ImageWrapper();
                attack.BitmapImage = bitmapImage;
                attack.FilePath = file.Path;
            }

            return attack;
        }

        private void UpdateDetails(ImageWrapper source)
        {
            if (source != null)
            {
                this.previewImage.PreviewImage = source.BitmapImage;
                this.previewImage.PreviewFilepath = source.FilePath;
            }
        }

        private async Task ShowAddEntryDialog(ImageWrapper preview)
        {
            var dialog = new AttackNames.UserControls.AddEntryDialog(preview);
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                // TODO: use the data returned by this function
                dialog.GetNewEntry();

                if (preview != null)
                {
                    // TODO: update images collection to store a class that contains the BitmapImage AND metadata.
                    // This way there can be an entry that does not yet have an associated image.
                    imagesCollection.Add(preview);
                }
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            // @TODO: overwrite the metadata for the currently selected image
        }
    }
}
