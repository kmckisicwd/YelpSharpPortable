using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Data
{
	public class Span
	{
        /// <summary>
        /// Latitude width of map bounds
        /// </summary>
		public double LatitudeDelta { get; set; }

        /// <summary>
        /// Longitude height of map bounds
        /// </summary>
		public double LongitudeDelta { get; set; }
	}
}
