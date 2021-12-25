using System;

namespace MediatorDemo.App
{
    public class LocationChangedEventArgs: EventArgs
    {
        public string RegNo {get;set;}
        public Location Location {get;set;}
    }
}
