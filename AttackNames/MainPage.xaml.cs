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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AttackNames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<BitmapImage> imagesCollection;

        public MainPage()
        {
            this.InitializeComponent();

            imagesCollection = new ObservableCollection<BitmapImage>();
            this.imagesGridView.ItemsSource = imagesCollection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage newImage = await this.OpenImage();
            if (newImage != null)
            {
                imagesCollection.Add(newImage);
            }
        }

        private void imagesGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.UpdateDetails(e?.ClickedItem as BitmapImage);
        }

        private async Task<BitmapImage> OpenImage()
        {
            BitmapImage bitmapImage = null;

            var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            filePicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFile file = await filePicker.PickSingleFileAsync();
            if (file != null)
            {
                bitmapImage = new BitmapImage();
                var fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                bitmapImage.SetSource(fileStream);
            }

            return bitmapImage;
        }

        private void UpdateDetails(BitmapImage source)
        {
            if (source != null)
            {
                this.previewImage.Source = source;
            }
        }
    }
}
