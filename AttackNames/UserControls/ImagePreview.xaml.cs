using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AttackNames.UserControls
{
    public sealed partial class ImagePreview : UserControl
    {
        public static readonly DependencyProperty PreviewImageProperty = DependencyProperty.Register(
            nameof(PreviewImage),
            typeof(BitmapImage),
            typeof(ImagePreview),
            new PropertyMetadata(null, BitmapImagePropertyChangedCallback));

        public static readonly DependencyProperty PreviewFilepathProperty = DependencyProperty.Register(
            nameof(PreviewFilepath),
            typeof(string),
            typeof(ImagePreview),
            new PropertyMetadata(string.Empty));

        public ImagePreview()
        {
            this.InitializeComponent();
        }

        public BitmapImage PreviewImage
        {
            get { return (BitmapImage)this.GetValue(PreviewImageProperty); }
            set { this.SetValue(PreviewImageProperty, value); }
        }

        public string PreviewFilepath
        {
            get { return (string)this.GetValue(PreviewFilepathProperty); }
            set { this.SetValue(PreviewFilepathProperty, value); }
        }

        private static void BitmapImagePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImagePreview thisImagePreview = d as ImagePreview;
            thisImagePreview.UpdateImageVisibilities(thisImagePreview.PreviewImage != null);
        }

        private void UpdateImageVisibilities(bool hasImage)
        {
            this.preview.Visibility = hasImage ? Visibility.Visible : Visibility.Collapsed;
            this.placeholder.Visibility = hasImage ? Visibility.Collapsed : Visibility.Visible;

            this.preview.Source = this.PreviewImage;
        }
    }
}
