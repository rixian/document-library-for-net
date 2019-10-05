// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class HttpFile : IDisposable
    {
        private IDisposable response;

        public int StatusCode { get; private set; }

        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }

        public Stream Stream { get; private set; }

        public bool IsPartial
        {
            get { return this.StatusCode == 206; }
        }

        public HttpFile(int statusCode, IReadOnlyDictionary<string, IEnumerable<string>> headers, System.IO.Stream stream, IDisposable response)
        {
            this.StatusCode = statusCode;
            this.Headers = headers;
            this.Stream = stream;
            this.response = response;
        }

        public void Dispose()
        {
            if (this.Stream != null)
            {
                this.Stream.Dispose();
            }

            if (this.response != null)
            {
                this.response.Dispose();
            }
        }
    }
}
