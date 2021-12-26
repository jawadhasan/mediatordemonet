using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorDemo.App.LocationDemo
{
    //Scenario: Location Proximity
    //Colleague objects communicate with each other about their location
    //In this example, we won't use abstract classes (e.g. vehicle, mediator) for simplicity

    //Concrete Mediator
    public class MarkerMediator
    {
        private List<Marker> markers = new List<Marker>();

        //Responsbile for creating of new marker
        //and bi-directional relationship
        public Marker CreateMarker()
        {
            var m = new Marker(Guid.NewGuid().ToString("N"));
            m.SetMediator(this);
            this.markers.Add(m);
            return m;
        }

        public void Send(LocationData location, Marker marker)
        {
            this.markers
                .Where(m => m != marker) //excluding itself marker
                .ToList()
                .ForEach(m => m.ReceiveLocation(location));
        }
    }

    //Concrete Colleague
    public class Marker
    {
        private MarkerMediator _mediator;

        public string Identifier { get; set; }
        public LocationData LocationData { get; set; }

        public Marker(string identifier)
        {
            this.Identifier = identifier;
        }
        internal void SetMediator(MarkerMediator mediator)
        {
            this._mediator = mediator;
        }

        public void ReceiveLocation(LocationData location)
        {
            Console.WriteLine("--------");
            Console.WriteLine($"{this.Identifier} Recieving marker");
            Console.WriteLine($"ts:{location.TimeStamp}, x:[{location.Longitude}] y:[{location.Latitude}]");
        }


        public void SendLocation(LocationData location)
        {
            Console.WriteLine($"{this.Identifier} Sending marker");
            _mediator.Send(location, this);
            Console.WriteLine("--------");
        }
    }

    //DTO
    public class LocationData
    {
        public DateTime TimeStamp { get; set; }
        public long Longitude { get; set; }
        public long Latitude { get; set; }
    }
}
