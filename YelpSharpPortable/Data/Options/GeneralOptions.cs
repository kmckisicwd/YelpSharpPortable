using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Data.Options
{
    /// <summary>
    /// Standard general search parameters
    /// </summary>
    public class GeneralOptions : BaseOptions
    {
        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// Search term (e.g. "food", "restaurants"). If term isn't included we search everything.
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// Number of business results to return
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Offset the list of returned business results by this amount
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Sort mode: 0=Best matched (default), 1=Distance, 2=Highest Rated. If the mode is 1 or 2 a search may retrieve an additional 20 businesses past the initial limit of the first 20 results. This is done by specifying an offset and limit of 20. Sort by distance is only supported for a location or geographic search. The rating sort is not strictly sorted by the rating value, but by an adjusted rating value that takes into account the number of ratings, similar to a bayesian average. This is so a business with 1 rating of 5 stars doesn't immediately jump to the top.
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// Category to filter search results with. See the list of supported categories. The category filter can be a list of comma delimited categories. For example, 'bars,french' will filter by Bars and French. The category identifier should be used (for example 'discgolf', not 'Disc Golf').
        /// </summary>
        public string CategoryFilter { get; set; }

        /// <summary>
        /// Search radius in meters. If the value is too large, a AREA_TOO_LARGE error may be returned. The max value is 25 miles.
        /// </summary>
        public double? RadiusFilter { get; set; }

        /// <summary>
        /// Whether to exclusively search for businesses with deals
        /// </summary>
        public bool? DealsFilter { get; set; }

        //--------------------------------------------------------------------------
        //
        //	Methods
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// format the properties for the querystring 
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetParameters()
        {
            var ps = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(Term)) ps.Add("term", this.Term);
            if (Limit.HasValue) ps.Add("limit", this.Limit.Value.ToString());
            if (Offset.HasValue) ps.Add("offset", this.Offset.Value.ToString());
            if (Sort.HasValue) ps.Add("sort", this.Sort.Value.ToString());
            if (!String.IsNullOrEmpty(CategoryFilter)) ps.Add("category_filter", this.CategoryFilter);
            if (RadiusFilter.HasValue) ps.Add("radius_filter", this.RadiusFilter.Value.ToString());
            if (DealsFilter.HasValue) ps.Add("deals_filter", this.DealsFilter.Value.ToString());            
            return ps;
        }
    }
}
