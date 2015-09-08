using System.Collections.Generic;

namespace YelpSharpPortable.Data
{
    /// <summary>
    /// general search results data after calling the search api
    /// </summary>
    public class SearchResults
    {
        /// <summary>
        /// The list of business entries (see http://www.yelp.com/developers/documentation/v2/search_api#business)
        /// </summary>
        public IList<Business> Businesses { get; set; }

        /// <summary>
        /// Suggested bounds in a map to display results in
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Total number of business results
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Error returned by Yelp Api, null if none
        /// </summary>
        public SearchError Error { get; set; }
    }
}
