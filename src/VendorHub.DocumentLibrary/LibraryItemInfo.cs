// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using Rixian.Drive.Common;

    /// <summary>
    /// Represents a library file system item.
    /// </summary>
    [JsonConverter(typeof(JsonInheritanceConverter), "type")]
    [JsonInheritance("file", typeof(LibraryFileInfo))]
    [JsonInheritance("directory", typeof(LibraryDirectoryInfo))]
    public class LibraryItemInfo
    {
        /// <summary>
        /// Gets or sets the ID of the library item.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the tenant ID.
        /// </summary>
        [JsonProperty("tenantId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the partition ID.
        /// </summary>
        [JsonProperty("partitionId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public Guid PartitionId { get; set; }

        /// <summary>
        /// Gets or sets the full path of the item.
        /// </summary>
        [JsonConverter(typeof(CloudPathJsonConverter))]
        [JsonProperty("fullPath", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public CloudPath? FullPath { get; set; }

        /// <summary>
        /// Gets or sets the create on timestamp.
        /// </summary>
        [JsonProperty("createdOn", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the last accessed timestamp.
        /// </summary>
        [JsonProperty("lastAccessedOn", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset LastAccessedOn { get; set; }

        /// <summary>
        /// Gets or sets the last modified on timestamp.
        /// </summary>
        [JsonProperty("lastModifiedOn", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset LastModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the library item name.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the parent directory ID.
        /// </summary>
        [JsonProperty("parentDirectoryId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ParentDirectoryId { get; set; }

        /// <summary>
        /// Gets or sets the item attributes.
        /// </summary>
        [JsonProperty("attributes", Required = Required.Always)]
        [Required]
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<string> Attributes { get; set; } = new List<string>();
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
