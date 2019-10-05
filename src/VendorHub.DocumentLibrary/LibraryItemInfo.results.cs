// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    [JsonConverter(typeof(JsonInheritanceConverter), "type")]
    [JsonInheritance("file", typeof(LibraryFileInfo))]
    [JsonInheritance("directory", typeof(LibraryDirectoryInfo))]
    public class LibraryItemInfo
    {
        [JsonProperty("id", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public Guid Id { get; set; }

        [JsonProperty("tenantId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public Guid TenantId { get; set; }

        [JsonProperty("partitionId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public Guid PartitionId { get; set; }

        [JsonProperty("fullPath", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string FullPath { get; set; }

        [JsonProperty("createdOn", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("lastAccessedOn", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset LastAccessedOn { get; set; }

        [JsonProperty("lastModifiedOn", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset LastModifiedOn { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        [JsonProperty("attributes", Required = Required.Always)]
        [Required]
        public ICollection<string> Attributes { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();

    }
}
