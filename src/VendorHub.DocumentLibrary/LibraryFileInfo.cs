// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System.Net.Mime;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a library file item.
    /// </summary>
    public class LibraryFileInfo : LibraryItemInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryFileInfo"/> class.
        /// </summary>
        public LibraryFileInfo()
        {
            this.Type = "file";
        }

        /// <summary>
        /// Gets or sets the length of the file in bytes.
        /// </summary>
        [JsonPropertyName("length")]
        public long Length { get; set; }

        /// <summary>
        /// Gets or sets the file content type. Defaults to 'application/octet-stream'.
        /// </summary>
        [JsonPropertyName("contentType")]
        public string ContentType { get; set; } = MediaTypeNames.Application.Octet;

        /// <summary>
        /// Gets or sets a value indicating whether this file is a shortcut or not.
        /// </summary>
        [JsonPropertyName("isShortcut")]
        public bool IsShortcut { get; set; }

        /// <summary>
        /// Gets or sets the alternate ID of this file.
        /// </summary>
        [JsonPropertyName("alternateId")]
        public string? AlternateId { get; set; }
    }
}
