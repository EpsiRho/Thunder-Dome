using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Thunder_Dome_3._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public class GlobalVars
    {
        public static string Name;
        public static List<Item> originList;
        public static int FontSize;
        public static List<Item> OnHoldItems;
    }

    public sealed partial class MainPage : Page
    {
        // Page Vars //
        public ItemsViewModel ViewModel { get; set; }
        public bool weightChangable; // Is Left item grid available for changes (wieghts/hold/add/remove)
        public bool paused; // Pause Request Checking
        public bool stopped; // Stop Request Checking
        public int MainFontSize; // Holds the current font size
        public int Speed; // Holds the current speed

        // Page Load //
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new ItemsViewModel();
            weightChangable = true;
            paused = false;
            stopped = false;
            Speed = 500;
            SpeedNumberText.Text = "500";
            LoadList();
        }
        public async void LoadList()
        {
            try
            {
                try
                {
                    foreach (Item i in GlobalVars.originList)
                    {
                        ViewModel.AddLeftItem(i);
                    }
                }
                catch (Exception) 
                { 
                    StorageFile itemsFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("items.txt", CreationCollisionOption.OpenIfExists);
                    var stream = await itemsFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                    string text = await Windows.Storage.FileIO.ReadTextAsync(itemsFile);
                    string[] items = text.Split("\n");
                    foreach (string item in items)
                    {
                        string temp = item.Replace("\r", "");
                        temp = temp.Replace("\n", "");
                        if (temp != "")
                        {
                            ViewModel.AddLeftItem(temp);
                            Bindings.Update();
                        }
                    }
                    ViewModel.AddRightItem(new Item());
                    MainFontSize = GlobalVars.FontSize;
                    stream.Dispose();
                    Bindings.Update();
                    ViewModel.ClearLists(2);
                }
            }
            catch (Exception)
            {

            }
        }

        // File Access
        public async void WriteFileChange(List<string> itemsList)
        {
            try
            {
                StorageFile itemsFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("items.txt", CreationCollisionOption.ReplaceExisting);
                var stream = await itemsFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                using (var outputStream = stream.GetOutputStreamAt(stream.Size))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                    {
                        foreach (string str in itemsList)
                        {
                            byte[] fileBuffer = Encoding.ASCII.GetBytes(str + "\n");
                            dataWriter.WriteBytes(fileBuffer);
                            await dataWriter.StoreAsync();
                            await outputStream.FlushAsync();
                        }
                    }
                }
                stream.Dispose();
            }
            catch (Exception)
            {

            }
        }

        // Item Grid Interaction //
        private void LeftItemGrid_ItemClick(object sender, ItemClickEventArgs e) // Change the weight ammount when clicking on an Item
        {
            if (weightChangable)
            {
                try
                {
                    Item pick = (Item)e.ClickedItem;
                    ProgressBar bar = FindDescendant<ProgressBar>(LeftItemGrid.ItemContainerGenerator.ContainerFromIndex(LeftItemGrid.Items.IndexOf(pick)));
                    if (pick.Progress == 0)
                    {
                        ViewModel.ChangeLeftItemWeight(pick, 33);
                        bar.Value = 33;
                    }
                    else if (pick.Progress == 33)
                    {
                        ViewModel.ChangeLeftItemWeight(pick, 66);
                        bar.Value = 66;
                    }
                    else if (pick.Progress == 66)
                    {
                        ViewModel.ChangeLeftItemWeight(pick, 100);
                        bar.Value = 100;
                    }
                    else if (pick.Progress == 100)
                    {
                        ViewModel.ChangeLeftItemWeight(pick, 0);
                        bar.Value = 0;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        } 
        private void LeftItemGrid_RightTapped(object sender, RightTappedRoutedEventArgs e) // Open Flyout Menu on right click 
        {
            try
            {
                if (weightChangable)
                {
                    Item ClickedItem = (e.OriginalSource as FrameworkElement).DataContext as Item;
                    LeftItemGrid.SelectedItem = ClickedItem;
                    MenuFlyout myFlyout = new MenuFlyout();
                    MenuFlyoutItem firstItem = new MenuFlyoutItem { Text = "Hold" };
                    MenuFlyoutItem secondItem = new MenuFlyoutItem { Text = "Remove" };
                    firstItem.Click += new RoutedEventHandler(HoldMenuFlyoutItem_Click);
                    secondItem.Click += new RoutedEventHandler(RemoveMenuFlyoutItem_Click);
                    myFlyout.Items.Add(firstItem);
                    myFlyout.Items.Add(secondItem);
                    myFlyout.ShowAt(sender as UIElement, e.GetPosition(sender as UIElement));
                }
            }
            catch (Exception)
            {

            }
        }
        private void HoldMenuFlyoutItem_Click(object sender, RoutedEventArgs e) // Handles Adding/Removing Items in hold when clicking on Flyout 
        {
            Item selectedItem = (Item)LeftItemGrid.SelectedItem;
            SymbolIcon icon = FindDescendant<SymbolIcon>(LeftItemGrid.ItemContainerGenerator.ContainerFromIndex(LeftItemGrid.Items.IndexOf(selectedItem)));
            if (icon.Symbol == Symbol.Cut)
            {
                GlobalVars.OnHoldItems.Remove(selectedItem);
                icon.Symbol = Symbol.Placeholder;
                icon.Visibility = Visibility.Collapsed;
            }
            else
            {
                GlobalVars.OnHoldItems.Add(selectedItem);
                icon.Symbol = Symbol.Cut;
                icon.Visibility = Visibility.Visible;
            }
        }
        private void RemoveMenuFlyoutItem_Click(object sender, RoutedEventArgs e) // Handles Removing Items from the list view and the txt file 
        {
            Item selectedItem = (Item)LeftItemGrid.SelectedItem;
            List<string> writeString = new List<string>();
            foreach (Item item in LeftItemGrid.Items)
            {
                writeString.Add(item.Name);
            }
            int i = writeString.IndexOf(selectedItem.Name);
            writeString.RemoveAt(i);
            WriteFileChange(writeString);
            ViewModel.RemoveLeftItem(selectedItem);
        }

        // Side Controls Interations //
        private void PlayPause_Tapped(object sender, TappedRoutedEventArgs e) // Handle start / stop when hitting the play/pause button 
        {
            if(PlayPauseIcon.Symbol == Symbol.Play)
            {
                PlayPauseIcon.Symbol = Symbol.Pause;
                PlayPauseText.Text = "Pause";
                PlayPauseButton.Margin = new Thickness(-4,0,0,2);
                AddButton.Visibility = Visibility.Collapsed;
                StopButton.Visibility = Visibility.Visible;
                weightChangable = false;
                Thread pickingThread = new Thread(new ThreadStart(RandomPickThread));
                if (!paused)
                {
                    GlobalVars.originList = new List<Item>();
                    foreach (Item item in LeftItemGrid.Items)
                    {
                        GlobalVars.originList.Add(item);
                    }
                    foreach (Item item in GlobalVars.OnHoldItems)
                    {
                        try
                        {
                            ViewModel.RemoveLeftItem(item);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    pickingThread.Start();
                }
                else
                {
                    paused = false;
                }
            }
            else
            {
                paused = true;
                PlayPauseIcon.Symbol = Symbol.Play;
                PlayPauseText.Text = "Start";
                PlayPauseButton.Margin = new Thickness(-1, 0, 0, 2);
            }
            PlayPauseButton.IsSelected = false;
        }
        private void TestButton_Tapped(object sender, TappedRoutedEventArgs e ) // Used for testing the winner page 
        {
            this.Frame.Navigate(typeof(Winner));
        }
        private void AddButton_Tapped(object sender, TappedRoutedEventArgs e)   // |\ 
        {
           if (AddItemPopup.IsOpen)
           {
               AddItemPopup.IsOpen = false;
           }
           else
           {
               AddItemPopup.IsOpen = true;
           }
           AddButton.IsSelected = false;
           Thread fuck = new Thread(new ThreadStart(setFocus));
           fuck.Start();
        }
        private void AddItemPopupButton_Click(object sender, RoutedEventArgs e) // |-|-> Handle Adding Items with the popup 
        {
            if(AddItemTextBox.Text != "")
            {
                List<string> writeString = new List<string>();
                foreach (Item item in LeftItemGrid.Items)
                {
                    writeString.Add(item.Name);
                }
                writeString.Add(AddItemTextBox.Text);
                WriteFileChange(writeString);
                ViewModel.AddLeftItem(AddItemTextBox.Text);
            }
            AddItemPopup.IsOpen = false;
            AddItemTextBox.Text = "";
        }
        private void AddButton_KeyDown(object sender, KeyRoutedEventArgs e)     // |/ 
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (AddItemTextBox.Text != "")
                {
                    List<string> writeString = new List<string>();
                    foreach (Item item in LeftItemGrid.Items)
                    {
                        writeString.Add(item.Name);
                    }
                    writeString.Add(AddItemTextBox.Text);
                    WriteFileChange(writeString);
                    ViewModel.AddLeftItem(AddItemTextBox.Text);
                }
                AddItemPopup.IsOpen = false;
                AddItemTextBox.Text = "";

            }
        }
        private void StopButton_Tapped(object sender, TappedRoutedEventArgs e) // Requests the Rolling thread to stop 
        {
            stopped = true;
            StopButton.Visibility = Visibility.Collapsed;
            AddButton.Visibility = Visibility.Visible;
            paused = false;
            PlayPauseIcon.Symbol = Symbol.Play;
            PlayPauseText.Text = "Start";
            weightChangable = true;
            PlayPauseButton.Margin = new Thickness(-1, 0, 0, 2);
        }
        private void FontChangeButtonDown_Click(object sender, RoutedEventArgs e) // Makes font size smaller on left click 
        {
            GlobalVars.FontSize -= 5;
            MainFontSize -= 5;
            ChangeSize.IsSelected = false;
            Bindings.Update();
        }
        private void FontChangeButtonUp_Click(object sender, RoutedEventArgs e) // Makes font size bigger on right click 
        {
            GlobalVars.FontSize += 5;
            MainFontSize += 5;
            ChangeSize.IsSelected = false;
            Bindings.Update();
        }
        private void SpeedIndicatorItem_Tapped(object sender, TappedRoutedEventArgs e) // Increases time between picks on left click 
        {
            Speed += 50;
            SpeedNumberText.Text = Speed.ToString();
            SpeedIndicatorItem.IsSelected = false;
            Bindings.Update();
        }
        private void SpeedIndicatorItem_RightTapped(object sender, RightTappedRoutedEventArgs e) // Decreases time bewtween picks on right click 
        {
            Speed -= 50;
            SpeedNumberText.Text = Speed.ToString();
            SpeedIndicatorItem.IsSelected = false;
            Bindings.Update();
        }

        // Thunder Dome //
        public async void RandomPickThread() // Main random picking code
        {
            
            while (true)
            {
                try
                {
                    // Put items in a list so list doesn't change when going through(code doesn't like when you change somethings being iterated on)
                    List<Item> itemList = new List<Item>();
                    foreach (Item item in LeftItemGrid.Items)
                    {
                        itemList.Add(item);
                    }
                    // For each item in the list..
                    foreach (Item item in itemList)
                    {
                        ProgressBar barLeft = null; // Holds pointer to Progressbar on the Left grid. Used to find the weight value
                        SymbolIcon icon = null; // Holds a point to the Symbol on the left of each name. Used to switch it to X or Check mark
                        GridViewItem aItem = null; // Grabs Grid View Item parent. Used to switch background
                        SolidColorBrush gBrush = null; // New Brushes must be made on the UI Thread (why tho?)
                        SolidColorBrush rBrush = null;
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => // Call Shit needed from UI Thread
                        {
                            barLeft = FindDescendant<ProgressBar>(LeftItemGrid.ItemContainerGenerator.ContainerFromIndex(LeftItemGrid.Items.IndexOf(item)));
                            icon = FindDescendant<SymbolIcon>(LeftItemGrid.ItemContainerGenerator.ContainerFromIndex(LeftItemGrid.Items.IndexOf(item)));
                            aItem = FindDescendant<GridViewItem>(LeftItemGrid.ItemContainerGenerator.ContainerFromIndex(LeftItemGrid.Items.IndexOf(item)));
                            gBrush = new SolidColorBrush(Color.FromArgb(80, 0, 255, 0));
                            rBrush = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                        });
                        var rand = new Random(); // New Random Number to decide item's fate
                        if (rand.Next(2) == 0)// 0 = failure, but check for a weight below
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => // More UI thread required work
                            {
                                // Check the weight value(I should have made this 1-3 and not 0-100 but it's too late and I'm lazy)
                                if (barLeft.Value != 0 && barLeft.Value != 100)
                                {
                                    ViewModel.AddRightItem(item); // Add the Item to the right list 
                                    icon.Symbol = Symbol.Cancel; // Set the symbol
                                    icon.Visibility = Visibility.Visible; // Show the symbol on the left
                                    Item RightItem = (Item)RightItemGrid.Items[RightItemGrid.Items.IndexOf(item)]; // get the item on the right side
                                    RightItem.Progress = RightItem.Progress - 33; // update the weight to be 1 less than the left
                                    aItem.Background = gBrush; // set the background to green
                                }
                                else if (barLeft.Value == 100) // Same shit here as above
                                {
                                    ViewModel.AddRightItem(item); 
                                    icon.Symbol = Symbol.Cancel;
                                    icon.Visibility = Visibility.Visible;
                                    Item RightItem = (Item)RightItemGrid.Items[RightItemGrid.Items.IndexOf(item)];
                                    RightItem.Progress = 66;
                                    aItem.Background = gBrush;
                                }
                                else // Same shit here except no weight so item gets left behind
                                {
                                    icon.Visibility = Visibility.Visible;
                                    icon.Symbol = Symbol.Cancel;
                                    aItem.Background = rBrush;
                                }
                            });
                        }
                        else // 1 so Item lives on
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => // UI thread call
                            {
                                icon.Symbol = Symbol.Accept; // Set the symbol
                                icon.Visibility = Visibility.Visible; // Show the symbol
                                ViewModel.AddRightItem(item); // Add the item to the right side
                                aItem.Background = gBrush; // set the background
                            });
                        }
                        if (stopped) // One cycle complete, check to see if a stop has been called
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => // tell UI thread to clear both lists
                            {
                                ViewModel.ClearLists();
                            });
                            foreach (Item i in GlobalVars.originList) // Grab the original List and reset the left list.
                            {
                                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                                {
                                    ViewModel.AddLeftItem(i);
                                });
                            }
                            Thread.Sleep(300); // wait for it to update
                            foreach (Item i in GlobalVars.OnHoldItems) // check the hold to see if icons need to be updated
                            {
                                try
                                {
                                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => // UI thread call
                                    {
                                        SymbolIcon symbol = FindDescendant<SymbolIcon>(LeftItemGrid.ItemContainerGenerator.ContainerFromIndex(LeftItemGrid.Items.IndexOf(i))); // find symbol child
                                        symbol.Symbol = Symbol.Cut; // set symbol to cut
                                        symbol.Visibility = Visibility.Visible; // make symbol visible
                                    });
                                }
                                catch (Exception)
                                {

                                }
                            }
                            stopped = false; // Return stopped check to false
                            return; // Kill the thread
                        }
                        while (paused) // Check to see if pause has been called. If so, Do nothing except check for a stop call. 
                        {
                            if (stopped) // Same as above
                            {
                                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                                {
                                    ViewModel.ClearLists();
                                });
                                foreach (Item i in GlobalVars.originList)
                                {
                                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                                    {
                                        ViewModel.AddLeftItem(i);
                                    });
                                }
                                Thread.Sleep(300);
                                foreach (Item i in GlobalVars.OnHoldItems) 
                                {
                                    try
                                    {
                                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => 
                                        {
                                            SymbolIcon symbol = FindDescendant<SymbolIcon>(LeftItemGrid.ItemContainerGenerator.ContainerFromIndex(LeftItemGrid.Items.IndexOf(i))); 
                                            symbol.Symbol = Symbol.Cut;
                                            symbol.Visibility = Visibility.Visible; 
                                        });
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                                stopped = false;
                                return;
                            }
                        }
                        Thread.Sleep(Speed); // No pauses or stops, so wait the set amount of time
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            Bindings.Update(); // update any bindings(progressbars mostly)
                        });
                    }
                    
                    // List has been iterated through, wait a second 

                    if (RightItemGrid.Items.Count == 0) // If the up next grid is empty, return left list to normal and reroll
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            ViewModel.ClearLists();
                        });
                        foreach (Item item in GlobalVars.originList)
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                            {
                                ViewModel.AddLeftItem(item);
                            });
                        }
                    }
                    else if (RightItemGrid.Items.Count == 1) // If only one is left, Declare the winner
                    {
                        Item win = (Item)RightItemGrid.Items[0]; // get the winning item
                        GlobalVars.Name = win.Name; // steal it's name and chuck it into the globalvars
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            this.Frame.Navigate(typeof(Winner)); // move to the winner page
                        });
                        weightChangable = true; // reset checking variable
                        return; // kill the rolling thread
                    }
                    else // more than one item left, continue rolling
                    {
                        itemList.Clear();  // clear the list
                        foreach (Item item in RightItemGrid.Items) // refill the list with the next up grid
                        {
                            itemList.Add(item);
                        }

                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            ViewModel.ClearLists(); // reset both grids
                        });

                        foreach(Item item in itemList)
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                            {
                                ViewModel.AddLeftItem(item); // add all the up next items into the left grid
                            });
                        }
                    }
                    Thread.Sleep(1200); // wait a second for things to load
                }
                catch (Exception) // error handling
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        ViewModel.ClearLists();
                    });
                    foreach (Item item in GlobalVars.originList)
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            ViewModel.AddLeftItem(item);
                        });
                    }
                    StopButton.Visibility = Visibility.Collapsed;
                    AddButton.Visibility = Visibility.Visible;
                    paused = false;
                    PlayPauseIcon.Symbol = Symbol.Play;
                    PlayPauseText.Text = "Start";
                    weightChangable = true;
                    return;
                }
            }
        }

        // Helper Functions //
        public T FindDescendant<T>(DependencyObject obj) where T : DependencyObject // Finds a child from a parent object. Used to find objects in item grid 
        {
            // Check if this object is the specified type
            if (obj is T)
                return obj as T;

            // Check for children
            int childrenCount = VisualTreeHelper.GetChildrenCount(obj);
            if (childrenCount < 1)
                return null;

            // First check all the children
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child is T)
                    return child as T;
            }

            // Then check the childrens children
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = FindDescendant<T>(VisualTreeHelper.GetChild(obj, i));
                if (child != null && child is T)
                    return child as T;
            }

            return null;
        }
        private async void setFocus() // Sets focus to the textbox when adding a new item
        {
            Thread.Sleep(300);
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                bool x = AddItemTextBox.Focus(FocusState.Keyboard);
                if (x)
                {

                }
            });
        }












    }
}
