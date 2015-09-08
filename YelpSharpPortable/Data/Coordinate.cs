using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Data
{
    /// <summary>
    /// Center position of map bounds
    /// </summary>
	public class Coordinate
	{
        /// <summary>
        /// Latitude position of map bounds center
        /// </summary>
		public double Latitude { get; set; }

        /// <summary>
        /// Longitude position of map bounds center
        /// </summary>
		public double Longitude { get; set; }
	}
}
