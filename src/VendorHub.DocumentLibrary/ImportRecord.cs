// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Mime;
    using Newtonsoft.Json;

    /// <summary>
    /// A record to be imported into a library.
    /// </summary>
    public class ImportRecord
    {
        /// <summary>
        /// Gets or sets the file name of the imported record.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the alternate ID of the record. E.g. the path of an esiting blob in Azure Blob Storage.
        /// </summary>
        [JsonProperty("alternateId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string AlternateId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the length of the file data.
        /// </summary>
        [JsonProperty("length", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Length { get; set; }

        /// <summary>
        /// Gets or sets the content type of the file.
        /// </summary>
        [JsonProperty("contentType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ContentType { get; set; } = MediaTypeNames.Application.Octet;

        /// <summary>
        /// Gets or sets the specific location to store the file. Optional.
        /// </summary>
        [JsonProperty("importPath", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? ImportPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not an
        /// existing record by the same name should be overwritten.
        /// </summary>
        [JsonProperty("overwrite", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Overwrite { get; set; } = false;

        /// <summary>
        /// Gets or sets any additional properties.
        /// </summary>
        [JsonExtensionData]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
