using System;
using NetTopologySuite.Geometries;
using System.Text.RegularExpressions;
namespace Rentless

{

    
    public class AppHelper
    {



        public int Id { get; set; }
        public string Name { get; set; }
        public Point Location { get; } = new Point(40.1234, 1.4321) { SRID = 4326 };

        public Point LocationUpsNorth { get { return Wgs84ToWgs84UpsNorth(Location); } }


        public static NetTopologySuite.Geometries.Point Wgs84ToWgs84UpsNorth(Point location)
        {
            if (location.SRID != 4326)
                throw new Exception("Unsupported coordinate system: " + location.SRID);

            OSGeo.OSR.SpatialReference wgs84Src = new OSGeo.OSR.SpatialReference("");
            wgs84Src.ImportFromProj4("+proj=longlat +datum=WGS84 +no_defs");

            OSGeo.OSR.SpatialReference stereoNorthPoleDest = new OSGeo.OSR.SpatialReference("");
            stereoNorthPoleDest.ImportFromProj4("+proj=stere +lat_0=90 +lat_ts=90 +lon_0=0 +k=0.994 +x_0=2000000 +y_0=2000000 +datum=WGS84 +units=m +no_defs");

            OSGeo.OSR.CoordinateTransformation ct = new OSGeo.OSR.CoordinateTransformation(wgs84Src, stereoNorthPoleDest);

            double[] point = new double[3];
            point[0] = location.X;
            point[1] = location.Y;
            point[2] = location.Z;

            ct.TransformPoint(point);

            return new Point(point[0], point[1]);
        }

        public static string CustSequence = "C00000001";
        public static string getNextCustId()
        {
            string newString = Regex.Replace(CustSequence, "\\d+",  m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
            return newString;
        }

        public static double deg2rad(double deg) {
            return (deg * Math.PI / 180.0);
        }
        public static double rad2deg(double rad) {
            return (rad / Math.PI * 180.0);
        }
        public static double distance(double lat1, double lon1, double lat2, double lon2, char unit) {
            if ((lat1 == lat2) && (lon1 == lon2)) {
                return 0;
            }
            else {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K') {
                    dist = dist * 1.609344;
                } else if (unit == 'N') {
                    dist = dist * 0.8684;
                }
                return (Math.Round(dist,3));
            }
        }


        
    }


}