// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Mime;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a library file item.
    /// </summary>
    public class LibraryFileInfo : LibraryItemInfo
    {
        /// <summary>
        /// Gets or sets the length of the file in bytes.
        /// </summary>
        [JsonProperty("length", Required = Required.Always)]
        public long Length { get; set; }

        /// <summary>
        /// Gets or sets the file content type. Defaults to 'application/octet-stream'.
        /// </summary>
        [JsonProperty("contentType", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string ContentType { get; set; } = MediaTypeNames.Application.Octet;

        /// <summary>
        /// Gets or sets a value indicating whether this file is a shortcut or not.
        /// </summary>
        [JsonProperty("isShortcut", Required = Required.Always)]
        public bool IsShortcut { get; set; }

        /// <summary>
        /// Gets or sets the alternate ID of this file.
        /// </summary>
        [JsonProperty("alternateId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string? AlternateId { get; set; }
    }
}
