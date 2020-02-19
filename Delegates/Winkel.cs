using System;
using System.Collections.Generic;
using System.Text;

namespace Oef
{
    public class WinkelEventArgs : EventArgs
    {
        public Bestelling Bestelling { get; set; }
    }
    class Winkel
    {
        //1.Define a delegate
        //2.Define an event based on that delgate
        //3.Raise the event
        public delegate void VerkoopProductEventHandler(object source,WinkelEventArgs args);
        public event VerkoopProductEventHandler Verkoop;
        public void VerkoopProduct(Bestelling bestelling) 
        {
            OnVerkoop(bestelling);
        }
        protected virtual void OnVerkoop(Bestelling bestelling)
        {
            if (Verkoop != null)
                Verkoop(this, new WinkelEventArgs() {Bestelling = bestelling });
        }
    }

}
