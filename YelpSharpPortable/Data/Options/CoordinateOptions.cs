using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Data.Options
{
    /// <summary>
    /// The geographic coordinate format is defined as:
    /// ll=latitude,longitude,accuracy,altitude,altitude_accuracy
    /// </summary>
    public class CoordinateOptions : LocationOptionBase
    {
        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// Latitude of geo-point to search near (required)
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Longitude of geo-point to search near (required)
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// Accuracy of latitude, longitude (optional)
        /// </summary>
        public double? Accuracy { get; set; }

        /// <summary>
        /// Altitude (optional)
        /// </summary>
        public double? Altitude { get; set; }

        /// <summary>
        /// Accuracy of altitude (optional)
        /// </summary>
        public double? AltitudeAccuracy { get; set; }

        //--------------------------------------------------------------------------
        //
        //	Methods
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// format the properties for the querystring - bounds is a single querystring parameter
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetParameters()
        {
            // coordinate requires at least a latitude and longitude - others are option
            if (!Latitude.HasValue || !Longitude.HasValue)
            {
                throw new InvalidOperationException("latitude and longitude are required fields for a coordinate based search");
            }

            var ll = Latitude + "," + Longitude;
            if (Accuracy.HasValue) ll += "," + Accuracy.Value;
            if (Altitude.HasValue) ll += "," + Altitude.Value;
            if (AltitudeAccuracy.HasValue) ll += "," + AltitudeAccuracy.Value;

            return new Dictionary<string, string> {
                { 
                    "ll", ll
                }
            };

        }
    }
}
