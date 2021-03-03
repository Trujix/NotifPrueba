using System;
using Android.App;
using Firebase.Iid;
using Android.Util;
using Firebase.Messaging;
using NotifDos.BD;

namespace NotifDos.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            SendRegistrationToServer(refreshedToken);

            Console.WriteLine("Token: " + refreshedToken);
        }
        void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
            FirebaseMessaging.Instance.SubscribeToTopic("todos");

            IProvider provider = new Provider();
            provider.Pintar(token);
        }
    }
}