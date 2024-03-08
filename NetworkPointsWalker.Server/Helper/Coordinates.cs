using Microsoft.EntityFrameworkCore;

namespace NetworkPointsWalker.Server.Helper
{
    public static class Coordinates
    {
        public static Tuple<double, double> Parse(string coords)
        {
            var elements = coords.Split(' ');

            return new Tuple<double, double>(double.Parse(elements[0]), double.Parse(elements[1]));
        }

    }
}
