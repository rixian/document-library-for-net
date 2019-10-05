// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using Rixian.Drive.Common;

    /// <summary>
    /// The request object for creating a new library.
    /// </summary>
    public class CreateLibraryRequest
    {
        /// <summary>
        /// Gets or sets the library name.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the library root storage location.
        /// </summary>
        [JsonProperty("location", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public CloudPath? Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the library has search enabled or not.
        /// </summary>
        [JsonProperty("enableSearch", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool EnableSearch { get; set; }

        /// <summary>
        /// Gets or sets any additional properties.
        /// </summary>
        [JsonExtensionData]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
