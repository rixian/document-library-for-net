// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Rixian.Drive.Common;

    /// <summary>
    /// Represents a document library.
    /// </summary>
    public class Library
    {
        /// <summary>
        /// Gets or sets the library ID.
        /// </summary>
        [JsonProperty("libraryId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid LibraryId { get; set; }

        /// <summary>
        /// Gets or sets the tenantID.
        /// </summary>
        [JsonProperty("tenantId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the library name.
        /// </summary>
        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the library storage location.
        /// </summary>
        [JsonConverter(typeof(CloudPathJsonConverter))]
        [JsonProperty("location", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public CloudPath? Location { get; set; }

        /// <summary>
        /// Gets or sets the library creation timestamp.
        /// </summary>
        [JsonProperty("createdOn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets any additional properties.
        /// </summary>
        [JsonExtensionData]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
#pragma warning restore CA2227 // Collection properties should be read only

    }
}
