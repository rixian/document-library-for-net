// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class LibraryFileInfo : LibraryItemInfo
    {
        [JsonProperty("parentDirectoryId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public Guid ParentDirectoryId { get; set; }

        [JsonProperty("length", Required = Required.Always)]
        public long Length { get; set; }

        [JsonProperty("contentType", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string ContentType { get; set; }

        [JsonProperty("isShortcut", Required = Required.Always)]
        public bool IsShortcut { get; set; }

        [JsonProperty("alternateId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string AlternateId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();

    }
}
