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
    public sealed partial class SplitView : UserControl
    {
        private bool isPaneOpen;
        public bool IsPaneOpen { get { return isPaneOpen; } set { Splitter.IsPaneOpen = value; isPaneOpen = value; } }

        private IList<NavigationItem> topItems = new List<NavigationItem>();
        public IList<NavigationItem> TopItems { get { return topItems; } set { foreach (var item in value) { TopListView.Items.Add(item); } topItems = value; } }

        private IList<NavigationItem> bottomItems = new List<NavigationItem>();
        public IList<NavigationItem> BottomItems { get { return bottomItems; } set { foreach (var item in value) { BottomListView.Items.Add(item); } bottomItems = value; } }
        public SplitView()
        {
            this.InitializeComponent();
            frame = rootFrame;
        }
        private Frame frame;
        public Frame Frame { get { return Frame; } }

        private void TopListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView mainSender = sender as ListView;
            if(mainSender.SelectedIndex == -1)
            {
                return;
            }
            BottomListView.SelectedIndex = -1;
            Type page = ((NavigationItem)mainSender.SelectedItem).NavigateTo;
            Frame.Navigate(page);
        }

        private void BottomListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView mainSender = sender as ListView;
            if (mainSender.SelectedIndex == -1)
            {
                return;
            }
            TopListView.SelectedIndex = -1;
            Type page = ((NavigationItem)mainSender.SelectedItem).NavigateTo;
            Frame.Navigate(page);
        }
    }
}
