// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Library
    {
        [JsonProperty("libraryId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid LibraryId { get; set; }

        [JsonProperty("tenantId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid TenantId { get; set; }

        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("location", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty("createdOn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();

    }
}
