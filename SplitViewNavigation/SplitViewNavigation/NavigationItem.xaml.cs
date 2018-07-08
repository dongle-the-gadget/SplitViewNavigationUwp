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

namespace SplitViewNavigation
{
    public sealed partial class NavigationItem : UserControl
    {
        private IconElement iconElement;
        public IconElement Icon { get { return iconElement; } set { if (MainItem.Children.Count == 2) { MainItem.Children.RemoveAt(0); } MainItem.Children.Insert(0, value); iconElement = value; } }

        private string text;      
        public string Text { get { return text; } set { TextBlock.Text = value; text = value; } }
        public Type NavigateTo { get; set; }
        public NavigationItem()
        {
            this.InitializeComponent();
        }
    }
}
