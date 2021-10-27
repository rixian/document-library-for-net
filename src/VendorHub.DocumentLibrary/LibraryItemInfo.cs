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
    /// Represents a library file system item.
    /// </summary>
    [System.Text.Json.Serialization.JsonConverter(typeof(LibraryItemInfoConverterWithTypeDiscriminator))]
    public class LibraryItemInfo
    {
        /// <summary>
        /// Gets or sets the ID of the library item.
        /// </summary>
        [JsonPropertyName("id")]
        [Required(AllowEmptyStrings = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the tenant ID.
        /// </summary>
        [JsonPropertyName("tenantId")]
        [Required(AllowEmptyStrings = true)]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the partition ID.
        /// </summary>
        [JsonPropertyName("partitionId")]
        [Required(AllowEmptyStrings = true)]
        public Guid PartitionId { get; set; }

        /// <summary>
        /// Gets or sets the full path of the item.
        /// </summary>
        [JsonConverter(typeof(CloudPathJsonConverter))]
        [JsonPropertyName("libraryPath")]
        [Required(AllowEmptyStrings = true)]
        public CloudPath? LibraryPath { get; set; }

        /// <summary>
        /// Gets or sets the full path of the item.
        /// </summary>
        [JsonConverter(typeof(CloudPathJsonConverter))]
        [JsonPropertyName("fullPath")]
        [Required(AllowEmptyStrings = true)]
        public CloudPath? FullPath { get; set; }

        /// <summary>
        /// Gets or sets the create on timestamp.
        /// </summary>
        [JsonPropertyName("createdOn")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the last accessed timestamp.
        /// </summary>
        [JsonPropertyName("lastAccessedOn")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset LastAccessedOn { get; set; }

        /// <summary>
        /// Gets or sets the last modified on timestamp.
        /// </summary>
        [JsonPropertyName("lastModifiedOn")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset LastModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the library item name.
        /// </summary>
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the parent directory ID.
        /// </summary>
        [JsonPropertyName("parentDirectoryId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ParentDirectoryId { get; set; }

        /// <summary>
        /// Gets or sets the item attributes.
        /// </summary>
        [JsonPropertyName("attributes")]
        [Required]
#pragma warning disable CA2227 // Collection properties should be read only
        public string? Attributes { get; set; }
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
