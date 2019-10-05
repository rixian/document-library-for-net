// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using Rixian.Drive.Common;

    /// <summary>
    /// Represents a search result.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Gets or sets the entity ID found from the search.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the path to the search result.
        /// </summary>
        [JsonConverter(typeof(CloudPathJsonConverter))]
        [JsonProperty("path", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public CloudPath? Path { get; set; }

        /// <summary>
        /// Gets or sets the name of the library item.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the library item. Can be either 'file' or 'directory'.
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the length in bytes of the library item if the type is 'file'.
        /// </summary>
        [JsonProperty("length", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long Length { get; set; }

        /// <summary>
        /// Gets or sets any additional properties.
        /// </summary>
        [JsonExtensionData]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
#pragma warning restore CA2227 // Collection properties should be read only

    }
}
