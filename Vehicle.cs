using System;

namespace mediatordemonet
{
 public class Vehicle
    {
        public string RegNo {get;set;}
        public Location CurrentLocation {get;set;}
        private Random _random = new Random();

        public Vehicle(string regNo)
        {
            this.RegNo = regNo;
            this.CurrentLocation = new Location();
        }

        public void Move(){
            this.CurrentLocation.Longitude = _random.Next(0,100);
            this.CurrentLocation.Latitude = _random.Next(0,100);

            //broadcast location
             
            Mediator.Instance.OnLocationChanged(this, 
                new LocationChangedEventArgs{ RegNo = this.RegNo, Location = this.CurrentLocation});
        }
    }
}