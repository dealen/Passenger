using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class Node
    {
        //private static readonly Regex NameRegex = new Regex();
        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Node(){}

        protected Node(string address, double latitude, double longitude)
        {
            SetAdress(Address);
            SetLatitude(latitude);
            SetLongitude(longitude);
        }

        private void SetAdress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new Exception("Address must be provided.");
            if (Address == address)
                return;
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetLongitude(double longitude)
        {
            if (double.IsNaN(longitude))
                throw new Exception("Provided value is not a number.");
            if (Longitude == longitude)
                return;
            Longitude = longitude;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetLatitude(double latitude)
        {
            if (double.IsNaN(latitude))
                throw new Exception("Provided value is not a number.");
            if (Latitude ==latitude)
                return;
            Latitude = latitude;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}