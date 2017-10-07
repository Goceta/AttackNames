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
    public sealed partial class TextPicker : UserControl
    {
        public static readonly DependencyProperty HeaderNameProperty = DependencyProperty.Register(
            nameof(Header),
            typeof(String),
            typeof(TextPicker),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty CategoryTypeProperty = DependencyProperty.Register(
            nameof(CategoryType),
            typeof(String),
            typeof(TextPicker),
            new PropertyMetadata(string.Empty));

        public TextPicker()
        {
            this.InitializeComponent();
        }

        public String Header
        {
            get { return (String)this.GetValue(HeaderNameProperty); }
            set { this.SetValue(HeaderNameProperty, value); }
        }

        public string CategoryType
        {
            get { return (string)this.GetValue(CategoryTypeProperty); }
            set { this.SetValue(CategoryTypeProperty, value); }
        }

        public string EntryText
        {
            get { return this.entry.Text; }
        }

        private void recents_Click(object sender, RoutedEventArgs e)
        {
            // TODO: open a popup with a list of context-appropriate tags that a user can select.
            string replacementEntry = string.Empty; // (returned from the popup)
            if (!string.IsNullOrWhiteSpace(replacementEntry))
            {
                this.entry.Text = replacementEntry;
            }
        }

        private void recentEntry_Click(object sender, RoutedEventArgs e)
        {
            Button selection = sender as Button;
            if (selection != null)
            {
                this.entry.Text = selection.Content as string;
            }

            this.recentsFlyout.Hide();
        }

        private void On_Loading(FrameworkElement sender, object args)
        {
            // TODO: retrieve the recents list from memory or file i/o, using the CategoryType string-key.

            List<string> testEntries = new List<string>();
            testEntries.Add("dbz");
            testEntries.Add("gundam");
            testEntries.Add("devil_may_cry");

            this.recentsList.ItemsSource = testEntries;
        }
    }
}
