using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SIT313A2
{
	public partial class MainPage : TabbedPage
	{

        int imagePositon = 1;
        public MainPage()
		{
			InitializeComponent();
		}



        public void OnButtonClicked(object sender, EventArgs args)
        {
        }
        public async void TakePhotoButton_OnClicked(object sender, EventArgs e)
        {

            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {

                

                switch (imagePositon) {

                    case 1:

                        imagePositon++;
                        var file = await CrossMedia.Current.TakePhotoAsync(
                            new StoreCameraMediaOptions
                            {
                                SaveToAlbum = true,
                                Name = "Test.jpg"
                            });
                        if (file == null)
                            return;

                        Image1.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                        Console.WriteLine(imagePositon);
                        break;

                    case 2:

                         file = await CrossMedia.Current.TakePhotoAsync(
                            new StoreCameraMediaOptions
                            {
                                SaveToAlbum = true,
                                Name = "Test.jpg"
                            });
                        if (file == null)
                            return;

                        Image2.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                        imagePositon++;
                        break;

                    case 3:

                        file = await CrossMedia.Current.TakePhotoAsync(
                           new StoreCameraMediaOptions
                           {
                               SaveToAlbum = true,
                               Name = "Test.jpg"
                           });
                        if (file == null)
                            return;

                        Image3.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                        imagePositon++;
                        break;

                    case 4:

                        file = await CrossMedia.Current.TakePhotoAsync(
                           new StoreCameraMediaOptions
                           {
                               SaveToAlbum = true,
                               Name = "Test.jpg"
                           });
                        if (file == null)
                            return;

                        Image4.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                        imagePositon++;
                        break;

                    case 5:

                        file = await CrossMedia.Current.TakePhotoAsync(
                           new StoreCameraMediaOptions
                           {
                               SaveToAlbum = true,
                               Name = "Test.jpg"
                           });
                        if (file == null)
                            return;

                        Image5.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                        imagePositon++;
                        break;

                    case 6:

                        file = await CrossMedia.Current.TakePhotoAsync(
                           new StoreCameraMediaOptions
                           {
                               SaveToAlbum = true,
                               Name = "Test.jpg"
                           });
                        if (file == null)
                            return;

                        Image6.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                        imagePositon++;
                        break;

                }

            }
            else
            {
                await DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
                //On iOS you may want to send your user to the settings screen.
                //CrossPermissions.Current.OpenAppSettings();
            }




        }

        }
}
