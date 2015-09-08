using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Data
{
    /// <summary>
    /// customer reviews of the business
    /// </summary>
    public class Review
    {
        
        /// <summary>
        /// Review identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Rating from 1-5
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// URL to star rating image for this business (size = 84x17)
        /// </summary>
        public string RatingImgUrl { get; set; }

        /// <summary>
        /// URL to small version of rating image for this business (size = 50x10)
        /// </summary>
        public string RatingImgUrlSmall { get; set; }

        /// <summary>
        /// url	URL to large version of rating image for this business (size = 166x30)
        /// </summary>
        public string RatingImgUrlLarge { get; set; }

        /// <summary>
        /// Time created (Unix timestamp)
        /// </summary>
        public double TimeCreated { get; set; }

        /// <summary>
        /// User who wrote the review
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Excerpt of the review
        /// </summary>
        public string Excerpt { get; set; }
       
    }
}
