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
            this.LocationData = new LocationData();
        }
        internal void SetMediator(MarkerMediator mediator)
        {
            this._mediator = mediator;
        }

        public void SetLocation(LocationData locationData)
        {
            this.LocationData = locationData;
        }

        public void BroadcastLocation()
        {
            Console.WriteLine($"{this.Identifier} is broadcasting location");
            this._mediator.Send(this.LocationData, this);
            Console.WriteLine("--------");
        }


        //This method will recieve location notifications from other markers
        public void ReceiveLocation(LocationData location)
        {
            Console.WriteLine("--------");
            Console.WriteLine($"{this.Identifier} Recieving marker");
            Console.WriteLine($"ts:{location.TimeStamp}, x:[{location.Longitude}] y:[{location.Latitude}]");

            //process location here....e.g.
            var distance = CalculateDistance(location);
            if (distance < 100)
            {
                //this.backColor = Color.Red
            }
            else if (distance > 100 && 1 == 1)
            { //some other conditon
                //this.backColor = Color.Green etc...
            } 

        }

        private double CalculateDistance(LocationData locationData)
        {
            var var1 = Math.Pow(locationData.Longitude - this.LocationData.Longitude, 2);
            var var2 = Math.Pow(locationData.Latitude - this.LocationData.Latitude,2);
            var result = Math.Sqrt(var1 + var2);
            return result;
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
