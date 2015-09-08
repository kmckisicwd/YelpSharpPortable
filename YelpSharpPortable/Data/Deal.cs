using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Data
{
    /// <summary>
    /// Deal info for this business (optional: this field is present only if there's a Deal)
    /// </summary>
    public class Deal
    {
        /// <summary>
        /// Deal identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Deal title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Deal url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Deal image url
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Currency code: http://en.wikipedia.org/wiki/ISO_4217
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Deal start time (Unix timestamp) http://unixtimesta.mp/
        /// </summary>
        public double TimeStart { get; set; }

        /// <summary>
        /// Deal end time (optional: this field is present only if the Deal ends)
        /// </summary>
        public double TimeEnd { get; set; }

        /// <summary>
        /// Additional details for the Deal, separated by newlines
        /// </summary>
        public string WhatYouGet { get; set; }

        /// <summary>
        /// Important restrictions for the Deal, separated by newlines
        /// </summary>
        public string ImportantRestrictions { get; set; }

        /// <summary>
        /// Deal additional restrictions
        /// </summary>
        public string AdditionalRestrictions { get; set; }

        /// <summary>
        /// Deal options
        /// </summary>
        public List<DealOptions> Options { get; set; }   
    }
}
