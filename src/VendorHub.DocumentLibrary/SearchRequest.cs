// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SearchRequest
    {
        public IDictionary<string, string>? RequiredTags { get; set; }
        public string? NameQuery { get; set; }
        public string? PathQuery { get; set; }
        public string? Type { get; set; }

        public string RawQuery { get; set; }
        public string RawFilter { get; set; }
    }
}
