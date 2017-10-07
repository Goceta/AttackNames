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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AttackNames.UserControls
{
    public sealed partial class EditableMetadata : UserControl
    {
        public EditableMetadata()
        {
            this.InitializeComponent();
        }

        public string AttackName
        {
            get { return this.attackName.EntryText; }
        }

        public string TitleName
        {
            get { return this.titleName.EntryText; }
        }

        public string FranchiseName
        {
            get { return this.franchiseName.EntryText; }
        }

        public string User
        {
            get { return this.user.EntryText; }
        }

        public string MediaType
        {
            get { return this.mediaTypes.SelectedItem as string; }
        }

        public string ReleaseDate
        {
            get { return this.releaseDate.Date.ToString(); }
        }

        private void OnLoading(FrameworkElement sender, object args)
        {
            this.SetupMediaTypesComboBox();
        }

        private void SetupMediaTypesComboBox()
        {
            List<string> mediaTypes = new List<string>();
            mediaTypes.Add(AttackNames.Metadata.MediaTypeHelper.MediaTypeToString(Metadata.MediaType.Anime));
            mediaTypes.Add(AttackNames.Metadata.MediaTypeHelper.MediaTypeToString(Metadata.MediaType.Game));
            mediaTypes.Add(AttackNames.Metadata.MediaTypeHelper.MediaTypeToString(Metadata.MediaType.Movie));

            this.mediaTypes.ItemsSource = mediaTypes;
        }
    }
}
