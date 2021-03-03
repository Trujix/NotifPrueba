using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Xamarin.Essentials;
using Xamarin.Forms;
using NotifDos.Droid.Models;
using Android.Content;

namespace NotifDos.Droid
{
    [Activity(Label = "NotifDos", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            IsPlayServicesAvailable();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            if (Intent.Extras != null)
            {
                NotificationSendObject notifcation = new NotificationSendObject();
                foreach (var key in Intent.Extras.KeySet())
                {
                    switch (key)
                    {
                        case "object_id":
                            notifcation.objectId = Intent.Extras.GetString(key);
                            break;
                        case "notification_id":
                            notifcation.notificationId = Intent.Extras.GetString(key);
                            break;
                        case "object_type":
                            notifcation.objectType = Intent.Extras.GetString(key);
                            break;
                    }
                }
                if (notifcation.notificationId != null)
                {
                    MessagingCenter.Send(App.Current, "OnTapNotification", notifcation);
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        public void IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            bool isGooglePlayServce = resultCode != ConnectionResult.Success;
            Preferences.Set("isGooglePlayServce", isGooglePlayServce);

        }
    }
}