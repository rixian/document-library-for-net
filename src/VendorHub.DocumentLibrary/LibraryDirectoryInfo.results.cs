// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LibraryDirectoryInfo : LibraryItemInfo
    {
        [JsonProperty("parentDirectoryId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid ParentDirectoryId { get; set; }

        [JsonProperty("hasChildren", Required = Required.Always)]
        public bool HasChildren { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();

    }
}
