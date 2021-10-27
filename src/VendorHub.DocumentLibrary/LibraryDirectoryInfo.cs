// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a library directory item.
    /// </summary>
    public class LibraryDirectoryInfo : LibraryItemInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryDirectoryInfo"/> class.
        /// </summary>
        public LibraryDirectoryInfo()
        {
            this.Type = "directory";
        }

        /// <summary>
        /// Gets or sets a value indicating whether the directory has children.
        /// </summary>
        [JsonPropertyName("hasChildren")]
        [Required]
        public bool HasChildren { get; set; }
    }
}
