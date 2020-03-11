// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a search result.
    /// </summary>
    /// <typeparam name="T">The document type of the search result.</typeparam>
    public class SearchResult<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets the document found from the search.
        /// </summary>
        [JsonProperty("document", Required = Required.Always)]
        public T? Document { get; set; }

        /// <summary>
        /// Gets or sets the search score.
        /// </summary>
        [JsonProperty("@search.score", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public double? SearchScore { get; set; }

        /// <summary>
        /// Gets or sets any additional properties.
        /// </summary>
        [JsonExtensionData]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
#pragma warning restore CA2227 // Collection properties should be read only

    }
}
