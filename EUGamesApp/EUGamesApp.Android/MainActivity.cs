using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android;
using EUGamesApp.Models;
using Android.Gms.Maps;


namespace EUGamesApp.Droid
{
    [Activity(Label = "EUGamesApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher =false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const string permission = Manifest.Permission.AccessFineLocation;
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            //Android.Support.Design.Widget.TabLayout tabBar = FindViewById<Android.Support.Design.Widget.TabLayout>(Resource.Id.sliding_tabs);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Screen.HeightPrixels = Resources.DisplayMetrics.HeightPixels;
            Screen.WidthPixels = Resources.DisplayMetrics.WidthPixels;
            Screen.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            Screen.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);

            Screen.TabSizePixels = 200;
            Screen.TabSize = (int)(Screen.TabSizePixels / Resources.DisplayMetrics.Density);
            Screen.Density = (float)Resources.DisplayMetrics.Density;


            //var x = this.FragmentManager.FindFragmentById(Resource.Id.sliding_tabs);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;



            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);


            await TryToGetPermissions();

            while (CheckSelfPermission(permission) != (int)Android.Content.PM.Permission.Granted)
            {
                await Task.Delay(10);
            }

            LoadApplication(new App());
        }

        #region RuntimePermissions

        async Task TryToGetPermissions()
        {
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                await GetPermissionsAsync();
                return;
            }

        }
        const int RequestLocationId = 0;

        readonly string[] PermissionsGroupLocation =
            {
                            Manifest.Permission.AccessCoarseLocation,
                            Manifest.Permission.AccessFineLocation,
             };

        async Task GetPermissionsAsync()
        {


            if (CheckSelfPermission(permission) == (int)Android.Content.PM.Permission.Granted)
            {
                //TODO change the message to show the permissions name
                //Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();
                return;
            }

            if (ShouldShowRequestPermissionRationale(permission))
            {
                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetPositiveButton("Request Permissions", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestLocationId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();


                return;
            }

            RequestPermissions(PermissionsGroupLocation, RequestLocationId);

        }
        public override async void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == (int)Android.Content.PM.Permission.Granted)
                        {
                            //Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();

                        }
                        else
                        {
                            //Permission Denied :(
                            //Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();

                        }
                    }
                    break;
            }
            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        #endregion
    }
}