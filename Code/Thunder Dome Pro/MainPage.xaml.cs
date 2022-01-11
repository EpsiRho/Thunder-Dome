using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Thunder_Dome_Pro.Classes;
using Thunder_Dome_Pro.ViewModels;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Thunder_Dome_Pro
{
    public sealed partial class MainPage : Page
    {
        //     <Page Vars>     //
        ListsListViewModel listsListViewModel { get; set; }
        SearchViewModel searchViewModel { get; set; }
        ItemsViewModel itemsViewModel { get; set; }
        ItemsViewModel reserveItemsViewModel { get; set; }
        ProvidersViewModel providersViewModel { get; set; }
        double TimeOut { get; set; }
        Item CurrentSelectedItem { get; set; }
        bool SettingsCanChange { get; set; }


        //     <Page Setup>     //
        public MainPage()
        {
            this.InitializeComponent();
            SettingsCanChange = false;
            itemsViewModel = new ItemsViewModel();
            searchViewModel = new SearchViewModel();
            reserveItemsViewModel = new ItemsViewModel();
            providersViewModel = new ProvidersViewModel();
            TimeOut = 0;
            FetchLists();
        }


        //     <Settings Functions>     //
        private void LoadSettings()
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string List = (string)localSettings.Values["DefaultList"];
            if(List == null)
            {
                localSettings.Values["DefaultList"] = "N/A";
            }
            else if (List != "N/A")
            {
                if (listsListViewModel.Lists.Contains(List))
                {
                    LoadList(List);
                    DefaultListSelection.SelectedItem = List;
                }
                else
                {
                    localSettings.Values["DefaultList"] = "N/A";
                    DefaultListSelection.SelectedIndex = -1;
                }
            }

            string SelectionSpeed = (string)localSettings.Values["SelectionSpeed"];
            if (SelectionSpeed == null)
            {
                localSettings.Values["SelectionSpeed"] = "500";
            }
            else
            {
                SpeedSlider.Value = Convert.ToUInt32(SelectionSpeed);
            }

            string ElimWeight = (string)localSettings.Values["ElimWeight"];
            if (ElimWeight == null)
            {
                localSettings.Values["ElimWeight"] = "0.5";
            }
            else
            {
                WeightSlider.Value = Convert.ToDouble(ElimWeight);
            }

            string FullElim = (string)localSettings.Values["FullElim"];
            if (FullElim == null)
            {
                localSettings.Values["FullElim"] = "True";
            }
            else
            {
                if(FullElim == "True") { FullElimCheck.IsChecked = true; }
                else { FullElimCheck.IsChecked = false; }
            }

            string EnableSus = (string)localSettings.Values["EnableSus"];
            if (FullElim == null)
            {
                localSettings.Values["EnableSus"] = "True";
            }
            else
            {
                if (EnableSus == "True") { EnableSuspense.IsChecked = true; }
                else { EnableSuspense.IsChecked = false; }
            }

            string ElimAni = (string)localSettings.Values["ElimAni"];
            if (ElimAni == null)
            {
                localSettings.Values["ElimAni"] = "True";
            }
            else
            {
                if (ElimAni == "True") { ElimAnimationCheck.IsChecked = true; }
                else { ElimAnimationCheck.IsChecked = false; }
            }

            SettingsCanChange = true;
        }
        private void DefaultListSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!SettingsCanChange) { return; }
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["DefaultList"] = DefaultListSelection.SelectedItem as string;
        }
        private void SpeedSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (!SettingsCanChange) { return; }
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["SelectionSpeed"] = SpeedSlider.Value.ToString();
        }
        private void FullElimCheck_Click(object sender, RoutedEventArgs e)
        {
            if (!SettingsCanChange) { return; }
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["FullElim"] = FullElimCheck.IsChecked.ToString();
        }
        private void EnableSuspense_Click(object sender, RoutedEventArgs e)
        {
            if (!SettingsCanChange) { return; }
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["EnableSus"] = EnableSuspense.IsChecked.ToString();
        }
        private void ElimAnimationCheck_Click(object sender, RoutedEventArgs e)
        {
            if (!SettingsCanChange) { return; }
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["ElimAni"] = ElimAnimationCheck.IsChecked.ToString();
        }

        private void WeightSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (!SettingsCanChange) { return; }
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["ElimWeight"] = WeightSlider.Value.ToString();
        }
        private void OverlayGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SettingsClose.Begin();
        }


        //     <File Management Functions>     //
        // Creats a new file for a newly added list
        private async void CreateNewListFile(string name)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync($"{name}.lst", CreationCollisionOption.ReplaceExisting);
            listsListViewModel.Lists.Add(name);
        }
        // Gets all the list files from the application folder
        private async void FetchLists()
        {
            listsListViewModel = new ListsListViewModel();
            IReadOnlyList<StorageFile> fileList = await ApplicationData.Current.LocalFolder.GetFilesAsync();
            foreach (StorageFile file in fileList)
            {
                listsListViewModel.Lists.Add(file.Name.Replace(".lst", ""));
            }
            LoadSettings();
        }
        // Saves the current itemsViewModel state to the current list file
        private async void SaveToFile(string name)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile listFile = await storageFolder.GetFileAsync($"{name}.lst");

            List<Item> toSerialize = new List<Item>();
            foreach(var item in itemsViewModel.Items)
            {
                toSerialize.Add(item);
            }

            string output = JsonConvert.SerializeObject(toSerialize);

            await Windows.Storage.FileIO.WriteTextAsync(listFile, output);
        }
        // Reads the last saved itemsViewModel state from a list file
        private async void ReadFromFile(string name)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile listFile = await storageFolder.GetFileAsync($"{name}.lst");

            string text = await Windows.Storage.FileIO.ReadTextAsync(listFile);

            var items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(text);

            itemsViewModel.Items.Clear();
            if (items != null)
            {
                foreach (Item item in items)
                {
                    item.HoldStatus = "Hold";
                    item.IsHeld = new SolidColorBrush(Color.FromArgb(255, 31, 31, 31));
                    item.ShowElim = Visibility.Collapsed;
                    item.ShowSel = Visibility.Collapsed;
                    item.Shield = 0;
                    itemsViewModel.Items.Add(item);
                }
            }
        }


        //     <API Functions>     //
        // Searches TMDB for movies
        private async void SearchMovies(string movie)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                SearchProgress.Visibility = Visibility.Visible;
            });
            var client = new RestClient();
            var request = new RestRequest(RestSharp.Method.GET); 
            client.BaseUrl = new Uri("https://api.themoviedb.org/3/search/movie?");

            request.AddQueryParameter("api_key", "c797dd0df1221d4b0b9a60c7169f41b2");
            request.AddQueryParameter("query", movie);
            request.AddQueryParameter("page", "1");

            var response = client.Execute(request);

            Search results = JsonConvert.DeserializeObject<Search>(response.Content);

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                searchViewModel.Items.Clear();
            });
            foreach (var item in results.results)
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    item.full_poster_path = $"https://image.tmdb.org/t/p/w200{item.poster_path}";
                    searchViewModel.Items.Add(item);
                });
            }
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                SearchProgress.Visibility = Visibility.Collapsed;
            });
        }


        //     <Item Grid Functions>     //
        // Gets the item right clicked on from the items grid, and sets it as a page variable so the right click menu functions can see it
        private void ItemGrid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Grid parent = sender as Grid;
            CurrentSelectedItem = parent.DataContext as Item;
        }
        // Holds or unholds an item, this is a temporary marking that makes it be instantly eliminated in the first round of the thunder dome.
        private void HoldFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentSelectedItem.HoldStatus == "Hold")
            {
                itemsViewModel.Items.ElementAt(itemsViewModel.Items.IndexOf(CurrentSelectedItem)).HoldStatus = "Unhold";
                itemsViewModel.Items.ElementAt(itemsViewModel.Items.IndexOf(CurrentSelectedItem)).IsHeld = new SolidColorBrush(Color.FromArgb(255,255,0,0));
            }
            else
            {
                itemsViewModel.Items.ElementAt(itemsViewModel.Items.IndexOf(CurrentSelectedItem)).HoldStatus = "Hold";
                itemsViewModel.Items.ElementAt(itemsViewModel.Items.IndexOf(CurrentSelectedItem)).IsHeld = new SolidColorBrush(Color.FromArgb(255, 31, 31, 31));
            }

        }
        // Removes an item from the list
        private void RemoveFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            itemsViewModel.Items.Remove(CurrentSelectedItem);
            SaveToFile(ListTitle.Text);
        }
        // Adds "Sheild" to the item clicked, this lets the item tank an elimination. Can only be given 3 Sheild max.
        private void ItemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Item selected = e.ClickedItem as Item;
            if (itemsViewModel.Items.ElementAt(itemsViewModel.Items.IndexOf(selected)).Shield < 3) {
                itemsViewModel.Items.ElementAt(itemsViewModel.Items.IndexOf(selected)).Shield++;
            }
            else
            {
                itemsViewModel.Items.ElementAt(itemsViewModel.Items.IndexOf(selected)).Shield = 0;
            }
        }


        //     <List Changing Functions>     //
        // Loads a list from file and updates the UI
        private void ListsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadList(e.ClickedItem as string);
        }
        private void LoadList(string name)
        {
            ListTitle.Text = name;
            ReadFromFile(name);
            AddButon.IsEnabled = true;
            PlayButton.IsEnabled = true;
            SelectListPopup.IsOpen = false;
        }


        //     <List Adding Functions>     //
        // Opens the dialog for adding a new list
        private void AddNewPopup_CloseButtonClick(Microsoft.UI.Xaml.Controls.TeachingTip sender, object args)
        {
            AddNewPopup.IsOpen = false;
            NewListDialog.ShowAsync();
        }
        // Confirms adding the new list, calls to create list file
        private void NewListDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(ListNameEntry.Text != "")
            {
                CreateNewListFile(ListNameEntry.Text);
            }
        }


        //     <Adding Items Functions>     //
        // Shows the dialog that has the search box for adding new items
        private void AddNewPopup_ActionButtonClick(Microsoft.UI.Xaml.Controls.TeachingTip sender, object args)
        {
            AddNewPopup.IsOpen = false;
            NewItemsDialog.ShowAsync();
        }
        // Adds an item once it's been selected from the search list and then the primary button is hit
        private void NewItemsDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Result res = MoviesListView.SelectedItem as Result;
            Item newItem = new Item();
            newItem.Name = res.title;
            newItem.Id = res.id;
            newItem.HoldStatus = "Hold";
            newItem.PosterLink = $"https://image.tmdb.org/t/p/w500{res.poster_path}";
            newItem.IsHeld = new SolidColorBrush(Color.FromArgb(255,31,31,31));
            newItem.ShowElim = Visibility.Collapsed;
            newItem.ShowSel = Visibility.Collapsed;
            newItem.Shield = 0;
            itemsViewModel.Items.Add(newItem);
            NewItemsDialog.Hide();
            NewItemsDialog.IsPrimaryButtonEnabled = false;
            NewItemEntry.Text = "";
            searchViewModel.Items.Clear();
            SaveToFile(ListTitle.Text);
        }
        // Handles input for the search box, setting the timer back to max whenever a key is pressed and starting the timer after a search.
        private void NewItemEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(NewItemEntry.Text == "")
            {
                return;
            }
            if (TimeOut <= 0)
            {
                TimeOut = 0.6;
                Thread t = new Thread(TimerThread);
                t.Start();
            }
            TimeOut = 0.6;
            NewItemsDialog.IsPrimaryButtonEnabled = false;

        }
        // Enables the add item button after a slection has been made
        private void MoviesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewItemsDialog.IsPrimaryButtonEnabled = true;
        }


        //     <Helper Functions>     //
        // Counts down from the last time the search box in the add items dialog was typed in.
        // Searches when it hits 0
        private async void TimerThread()
        {
            while (true)
            {
                Thread.Sleep(100);
                TimeOut = TimeOut - 0.1;
                if(TimeOut <= 0.0)
                {
                    string name = "";
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        name = NewItemEntry.Text;
                    });
                    SearchMovies(name);
                    return;
                }
            }
        }


        //     <Actions Bar Functions>     //
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(ThunderDomeStart);
            t.Start();
            ButtonPanelStoryBoardExit.Begin();
        }
        private void AddButon_Click(object sender, RoutedEventArgs e)
        {
            AddNewPopup.IsOpen = !AddNewPopup.IsOpen;
        }
        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            SelectListPopup.IsOpen = !SelectListPopup.IsOpen;
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            if (SettingsGrid.Height == 0)
            {
                SettingsOpen.Begin();
            }
            else if (SettingsGrid.Height == 500)
            {
                SettingsClose.Begin();
            }
        }
        // Shows / Hides the action bar when it's clicked
        private void Border_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (ButtonPanelTransform.X != 0)
            {
                ButtonPanelStoryBoardEnter.Begin();
            }
            else
            {
                ButtonPanelStoryBoardExit.Begin();
            }
        }


        //     <Thunder Dome Functions>     //
        // Starts and runs the animation and picking process 
        private async void ThunderDomeStart()
        {
            int round = 1;
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                RoundTextOpen.Begin();
            });
            // Save Current Items
            reserveItemsViewModel.Items.Clear();
            foreach (var item in itemsViewModel.Items)
            {
                reserveItemsViewModel.Items.Add(new Item(item));
            }

            // Remove Held Items
            foreach (var item in reserveItemsViewModel.Items)
            {
                if (item.HoldStatus == "Unhold")
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        itemsViewModel.Items.Remove(itemsViewModel.Items.First(o => o.Id == item.Id));
                    });
                }
            }

            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            while (true) 
            {
                List<bool> vs = new List<bool>();
                while (true)
                {
                    // Generate a list of randomized bools, these will deterimine if an item gets eeliminated
                    Random rand = new Random();
                    for (int i = 0; i < itemsViewModel.Items.Count; i++)
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            itemsViewModel.Items[i].ShowSel = Visibility.Collapsed;
                            itemsViewModel.Items[i].ShowElim = Visibility.Collapsed;
                            itemsViewModel.Items[i].needsClean = false;
                        });
                        if (rand.NextDouble() >= Convert.ToDouble(localSettings.Values["ElimWeight"]))
                        {
                            vs.Add(true);
                        }
                        else
                        {
                            vs.Add(false);
                        }
                    };
                    if ((string)localSettings.Values["FullElim"] == "True")
                    {
                        break;
                    }
                    else
                    {
                        if (vs.Contains(false) && vs.Contains(true))
                        {
                            break;
                        }
                        else
                        {
                            vs.Clear();
                        }
                    }
                }

                if ((string)localSettings.Values["EnableSus"] == "True" || (string)localSettings.Values["FullElim"] == "False")
                {
                    Thread.Sleep(2000);
                }

                // Preform the check on each item, display if they were eliminated or survived
                for (int i = 0; i < itemsViewModel.Items.Count; i++)
                {
                    if (vs[i] == true)
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            itemsViewModel.Items[i].ShowSel = Visibility.Visible;
                        });
                    }
                    else
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            itemsViewModel.Items[i].needsClean = true;
                            itemsViewModel.Items[i].ShowElim = Visibility.Visible;
                        });
                    }
                    Thread.Sleep(Convert.ToUInt16(localSettings.Values["SelectionSpeed"]));
                }

                if ((string)localSettings.Values["EnableSus"] == "True")
                {
                    Thread.Sleep(1000);
                }
                // Clean up the losers
                int count = itemsViewModel.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    if (itemsViewModel.Items[i].needsClean == true)
                    {
                        if (itemsViewModel.Items[i].Shield > 0)
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                            {
                                itemsViewModel.Items[i].Shield--;
                                itemsViewModel.Items[i].needsClean = false;
                            });
                        }
                        else
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                            {
                                itemsViewModel.Items.Remove(itemsViewModel.Items[i]);
                            });
                            count--;
                            i--;
                            if ((string)localSettings.Values["ElimAni"] == "True")
                            {
                                Thread.Sleep(50);
                            }
                        }
                    }
                }

                vs.Clear();

                // Check to see how many items are left
                if (itemsViewModel.Items.Count == 1)
                {
                    // Winning condition
                    ThunderDomeWin();
                    return;
                }
                else if(itemsViewModel.Items.Count == 0)
                {
                    foreach (var item in reserveItemsViewModel.Items)
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            itemsViewModel.Items.Add(item);
                        });
                    }
                    Thread.Sleep(1000);
                }
                // Sure - Austin Maxwell 2021
                round++;
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    RoundTitle.Text = $"Round {round}";
                });
            }
        }
        // Loads information about the winning item
        private async void ThunderDomeWin()
        {
            int MovieId = 0;
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                MovieId = itemsViewModel.Items[0].Id;
                WinningOpenHalf.Begin();
                RoundTextClose.Begin();
                RoundTitle.Text = $"Round 1";
            });

            // Get Info
            var client = new RestClient();
            var request = new RestRequest(RestSharp.Method.GET);
            client.BaseUrl = new Uri($"https://api.themoviedb.org/3/movie/{MovieId}");

            request.AddQueryParameter("api_key", "c797dd0df1221d4b0b9a60c7169f41b2");

            var response = client.Execute(request);

            MovieInfo results = JsonConvert.DeserializeObject<MovieInfo>(response.Content);

            // Get Provider Info

            var sClient = new RestClient();
            var sRequest = new RestRequest(RestSharp.Method.GET);
            client.BaseUrl = new Uri($"https://api.themoviedb.org/3/movie/{MovieId}/watch/providers?");

            sRequest.AddQueryParameter("api_key", "c797dd0df1221d4b0b9a60c7169f41b2");

            var sResponse = client.Execute(sRequest);

            Providers sResults = JsonConvert.DeserializeObject<Providers>(sResponse.Content);

            if (sResults.results.US.flatrate != null)
            {
                foreach (var p in sResults.results.US.flatrate)
                {
                    p.logo_path = $"https://image.tmdb.org/t/p/w200/{p.logo_path}";
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        providersViewModel.Items.Add(p);
                    });
                }
            }

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                WinningPoster.Source = new BitmapImage(new Uri($"https://image.tmdb.org/t/p/w200{results.poster_path}"));
                WinningTitle.Text = results.title;
                WinningDesc.Text = results.overview;
                WinningRating.Text = $"{results.vote_average}/10";
                WinningReleaseDate.Text = results.release_date;
                WinningOpenFull.Begin();
            });
        }



        //     <Item Info Panel Functions     //
        // Brings you to the pirate bay
        private async void PirateButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            string link = "https://thepiratebay.org/search.php?q=";
            string query = WinningTitle.Text;
            query = query.Replace(" ", "+");
            await Windows.System.Launcher.LaunchUriAsync(new Uri($"{link}{query}&cat=0"));
        }
        // Closes the Info Panel
        private void CloseWinningPanelButton_Click(object sender, RoutedEventArgs e)
        {
            WinningClosing.Begin();
            itemsViewModel.Items.Clear();
            providersViewModel.Items.Clear();
            foreach (var item in reserveItemsViewModel.Items)
            {
                item.ShowElim = Visibility.Collapsed;
                item.ShowSel = Visibility.Collapsed;
                itemsViewModel.Items.Add(item);
            }
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ((Rectangle)sender).Translation += new Vector3(0, 0, 32);
        }
    }
}
