// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Request parameters for a search request.
    /// </summary>
    public class SearchRequest
    {
        /// <summary>
        /// Gets or sets a required set of tags.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, string>? RequiredTags { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Gets or sets the name query field.
        /// </summary>
        public string? NameQuery { get; set; }

        /// <summary>
        /// Gets or sets the path query field.
        /// </summary>
        public string? PathQuery { get; set; }

        /// <summary>
        /// Gets or sets the record type to filter.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the raw Lucene search query.
        /// </summary>
        public string? RawQuery { get; set; }

        /// <summary>
        /// Gets or sets the raw Lucene filter query.
        /// </summary>
        public string? RawFilter { get; set; }
    }
}
