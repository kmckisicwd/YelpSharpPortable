using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Data
{
    /// <summary>
    /// user on yelp
    /// </summary>
    public class User
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User profile image url
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }
    }
}
