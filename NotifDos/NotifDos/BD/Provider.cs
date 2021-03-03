using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NotifDos.BD
{
    public class Provider : IProvider
    {
        public void Pintar(string token)
        {
            Page pagina = App.Current.MainPage;
            Entry miEntry = pagina.FindByName<Entry>("MiEntry");
            miEntry.Text = token;
        }
    }
}
