using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Thunder_Dome_3._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Winner : Page
    {
        public Winner()
        {
            this.InitializeComponent();
            try
            {
                MovieName.Content = GlobalVars.Name;
            }
            catch (Exception)
            {
                
            }
            if(MovieName.Content == null)
            {
                MovieName.Content = "Testing";
            }
        }

        private void Reroll_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void MovieName_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string link = "https://thepiratebay.org/search.php?q=";
            string query = MovieName.Content.ToString();
            query.Replace(" ", "+");
            await Windows.System.Launcher.LaunchUriAsync(new Uri(link+query+"&cat=0"));
        }

        private async void Remove_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                List<string> writeString = new List<string>();
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
                        writeString.Add(temp);
                    }
                }
                stream.Dispose();

                int i = writeString.IndexOf((string)MovieName.Content);
                writeString.RemoveAt(i);
                Remove.Visibility = Visibility.Collapsed;
                WriteFileChange(writeString);
            }
            catch (Exception)
            {

            }
        }
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
    }

}
