// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Rixian.Drive.Common;

    /// <summary>
    /// Represents a search result.
    /// </summary>
    public class LibrarySearchResult
    {
        /// <summary>
        /// Gets or sets the drive item ID found from the search.
        /// </summary>
        [JsonPropertyName("driveItemId")]
        [Required(AllowEmptyStrings = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the library ID found from the search.
        /// </summary>
        [JsonPropertyName("libraryId")]
        [Required(AllowEmptyStrings = true)]
        public Guid LibraryId { get; set; }

        /// <summary>
        /// Gets or sets the path to the search result.
        /// </summary>
        [JsonConverter(typeof(CloudPathJsonConverter))]
        [JsonPropertyName("path")]
        [Required(AllowEmptyStrings = true)]
        public CloudPath? Path { get; set; }

        /// <summary>
        /// Gets or sets the name of the library item.
        /// </summary>
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the library item. Can be either 'file' or 'directory'.
        /// </summary>
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the length in bytes of the library item if the type is 'file'.
        /// </summary>
        [JsonPropertyName("length")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
