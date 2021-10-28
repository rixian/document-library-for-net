// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The request object for upserting file tags.
    /// </summary>
    public class UpsertFileTagsRequest
    {
        /// <summary>
        /// Gets or sets the tags to upsert.
        /// </summary>
        [JsonPropertyName("tags")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Gets or sets any additional properties.
        /// </summary>
        [JsonExtensionData]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
