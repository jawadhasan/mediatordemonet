using System;


namespace MediatorDemo.App
{
    public class Mediator{

        //make it singleton
        private static readonly Mediator _instance = new Mediator();

        //hide constructor
        private Mediator(){}

        //provide a way to get instance
        public static Mediator Instance => _instance;

        //Instance Functionality
        public event EventHandler<LocationChangedEventArgs> LocationChanged;

        public void OnLocationChanged(object sender, LocationChangedEventArgs locationInfo){
            LocationChanged?.Invoke(sender, locationInfo );
        }

        
    }

}
