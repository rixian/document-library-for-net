// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Rixian.Drive.Common;

    /// <summary>
    /// Represents a document library.
    /// </summary>
    public class Library
    {
        /// <summary>
        /// Gets or sets the library ID.
        /// </summary>
        [JsonPropertyName("libraryId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid LibraryId { get; set; }

        /// <summary>
        /// Gets or sets the tenantID.
        /// </summary>
        [JsonPropertyName("tenantId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the library name.
        /// </summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the library storage location.
        /// </summary>
        [JsonConverter(typeof(CloudPathJsonConverter))]
        [JsonPropertyName("location")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CloudPath? Location { get; set; }

        /// <summary>
        /// Gets or sets the library creation timestamp.
        /// </summary>
        [JsonPropertyName("createdOn")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether search is enabled for this library or not.
        /// </summary>
        [JsonPropertyName("isSearchEnabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool IsSearchEnabled { get; set; }

        /// <summary>
        /// Gets or sets any additional properties.
        /// </summary>
        [JsonExtensionData]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
#pragma warning restore CA2227 // Collection properties should be read only

    }
}
