namespace NetworkPointsWalker.Server.Models
{
    public class CoordinatesModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CoordinatesModel(string coords)
        {
            var elements = coords.Split(", ").Select(x => x.Replace(',', '.')).ToArray();

            Latitude = double.Parse(elements[0]);
            Longitude = double.Parse(elements[1]);
        }
        public CoordinatesModel(double lat, double lng) { Latitude = lat; Longitude = lng; }
    }

    // https://stackoverflow.com/questions/6366408/calculating-distance-between-two-latitude-and-longitude-geocoordinates
    public static class CoordinatesDistanceExtensions
    {
        public static double DistanceTo(this CoordinatesModel baseCoordinates, CoordinatesModel targetCoordinates)
        {
            return DistanceTo(baseCoordinates, targetCoordinates, UnitOfLength.Kilometers);
        }

        public static double DistanceTo(this CoordinatesModel baseCoordinates, CoordinatesModel targetCoordinates, UnitOfLength unitOfLength)
        {
            var baseRad = Math.PI * baseCoordinates.Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            if(baseRad == targetRad)
            {
                return 0;
            }

            var theta = baseCoordinates.Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return unitOfLength.ConvertFromMiles(dist);
        }
    }

    public class UnitOfLength
    {
        public static UnitOfLength Kilometers = new UnitOfLength(1.609344);
        public static UnitOfLength NauticalMiles = new UnitOfLength(0.8684);
        public static UnitOfLength Miles = new UnitOfLength(1);

        private readonly double _fromMilesFactor;

        private UnitOfLength(double fromMilesFactor)
        {
            _fromMilesFactor = fromMilesFactor;
        }

        public double ConvertFromMiles(double input)
        {
            return input * _fromMilesFactor;
        }
    }
}
