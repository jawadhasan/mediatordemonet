using System;

namespace MediatorDemo.App
{
 public class ControlCenter
    {
        public ControlCenter()
        {
           Mediator.Instance.LocationChanged += (s,e) => {
               Console.WriteLine($"Vehicle {e.RegNo} Moved! Location -> [{e.Location.Longitude}, {e.Location.Latitude}]");
               };
        }
    }
}