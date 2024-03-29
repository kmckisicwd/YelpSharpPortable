﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Data.Options
{
    /// <summary>
    /// Specify Location by Neighborhood, Address, or City
    /// Location is specified by a particular neighborhood, address or city.
    /// The location format is defined: ?location=location
    /// </summary>
    public class LocationOptions : LocationOptionBase
    {

        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        #region Properties

        /// <summary>
        /// Specifies the combination of "address, neighborhood, city, state or zip, optional country" to be used when searching for businesses. (required)
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// An optional latitude, longitude parameter can also be specified as a hint to the geocoder to disambiguate the location text.
        /// The format for this is defined as:   ?cll=latitude,longitude
        /// </summary>
        public CoordinateOptions Coordinates { get; set; }

        #endregion



        //--------------------------------------------------------------------------
        //
        //	Methods
        //
        //--------------------------------------------------------------------------

        #region GetParameters

        /// <summary>
        /// format the properties for the querystring 
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetParameters()
        {
            // location is a required field
            if (String.IsNullOrEmpty(Location))
                throw new InvalidOperationException("To perform a location based search, the location property must contain an area within to search.  For coordinate based searches, use the CoordinateOption class.");

            var ps = new Dictionary<string, string>();
            ps.Add("location", this.Location);

            // if coordinates are specified add those to the parameters hash
            if (Coordinates != null && Coordinates.Longitude.HasValue && Coordinates.Latitude.HasValue)
                ps.Add("cll", string.Format("{0},{1}", Coordinates.Latitude, Coordinates.Longitude));
            
            return ps;
        }

        #endregion
    }
}
