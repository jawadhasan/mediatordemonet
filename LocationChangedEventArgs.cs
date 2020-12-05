using System;

namespace mediatordemonet
{
    public class LocationChangedEventArgs: EventArgs
    {
        public string RegNo {get;set;}
        public Location Location {get;set;}
    }
}
