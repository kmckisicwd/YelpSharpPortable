using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Data
{
    /// <summary>
    /// Deal options
    /// </summary>
    public class DealOptions
    {
        /// <summary>
        /// Deal option title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Deal option url for purchase
        /// </summary>
        public string PurchaseUrl { get; set; }

        /// <summary>
        /// Deal option price (in cents)
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Deal option price (formatted, e.g. "$6")
        /// </summary>
        public string FormattedPrice { get; set; }

        /// <summary>
        /// Deal option original price (in cents)
        /// </summary>
        public double OriginalPrice { get; set; }

        /// <summary>
        /// Deal option original price (formatted, e.g. "$12")
        /// </summary>
        public string FormattedOriginalPrice { get; set; }

        /// <summary>
        /// Whether the deal option is limited or unlimited
        /// </summary>
        public bool IsQuantityLimited { get; set; }

        /// <summary>
        /// The remaining deal options available for purchase (optional: this field is only present if the deal is limited)
        /// </summary>
        public double RemainingCount { get; set; }
    }
}
