// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a library directory item.
    /// </summary>
    public class LibraryDirectoryInfo : LibraryItemInfo
    {
        /// <summary>
        /// Gets or sets a value indicating whether the directory has children.
        /// </summary>
        [JsonProperty("hasChildren", Required = Required.Always)]
        public bool HasChildren { get; set; }
    }
}
