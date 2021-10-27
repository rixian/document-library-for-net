// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Mime;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a file stream of a file.
    /// </summary>
    public class LibraryFileStream
    {
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
        /// Gets or sets the file ID.
        /// </summary>
        [JsonPropertyName("fileId")]
        [Required(AllowEmptyStrings = true)]
        public Guid FileId { get; set; }

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
        /// Gets or sets the stream name.
        /// </summary>
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the length of the file stream in bytes.
        /// </summary>
        [JsonPropertyName("length")]
        public long Length { get; set; }

        /// <summary>
        /// Gets or sets the file stream content type. Defaults to 'application/octet-stream'.
        /// </summary>
        [JsonPropertyName("contentType")]
        [Required(AllowEmptyStrings = true)]
        public string ContentType { get; set; } = MediaTypeNames.Application.Octet;

        /// <summary>
        /// Gets or sets any additional properties.
        /// </summary>
        [JsonExtensionData]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
#pragma warning restore CA2227 // Collection properties should be read only

    }
}
