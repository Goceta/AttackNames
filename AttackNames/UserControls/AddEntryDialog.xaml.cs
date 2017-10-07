using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using AttackNames.ViewModels;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AttackNames.UserControls
{
    public sealed partial class AddEntryDialog : ContentDialog
    {
        private ImageWrapper preview = null;

        public AddEntryDialog()
        {
            this.InitializeComponent();
        }

        public AddEntryDialog(ImageWrapper preview)
            : this()
        {
            this.preview = preview;
            this.UpdateImagePreview();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void UpdateImagePreview()
        {
            if (this.preview?.BitmapImage != null)
            {
                this.imagePreview.PreviewImage = this.preview.BitmapImage;
            }

            this.imagePreview.PreviewFilepath = this.preview.FilePath;
        }

        public object GetNewEntry()
        {
            // TODO: instanciate a new object with all the image info and metadata then return it.
            return null;
        }
    }
}
