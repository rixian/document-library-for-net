// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mime;

    /// <summary>
    /// Represents a file response from an http call.
    /// </summary>
    public class HttpFileResponse : IDisposable
    {
        private IDisposable response;
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpFileResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The status code of the response.</param>
        /// <param name="headers">The response headers.</param>
        /// <param name="stream">The response data stream.</param>
        /// <param name="response">Handle to the response object.</param>
        public HttpFileResponse(HttpStatusCode statusCode, IReadOnlyDictionary<string, IEnumerable<string>> headers, Stream stream, IDisposable response)
        {
            this.StatusCode = statusCode;
            this.Headers = headers;
            this.Stream = stream;
            this.response = response;

            var cdHeader = headers?["Content-Disposition"]?.FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(cdHeader))
            {
                this.ContentDispositionHeader = new ContentDisposition(cdHeader);
            }

            var ctHeader = headers?["Content-Type"]?.FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(ctHeader))
            {
                this.ContentTypeHeader = new ContentType(ctHeader);
            }
        }

        /// <summary>
        /// Gets the response status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets the response headers.
        /// </summary>
        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }

        /// <summary>
        /// Gets the raw data stream.
        /// </summary>
        public Stream Stream { get; private set; }

        /// <summary>
        /// Gets the Content-Type header.
        /// </summary>
        public ContentType? ContentTypeHeader { get; private set; }

        /// <summary>
        /// Gets the Content-Disposition header.
        /// </summary>
        public ContentDisposition? ContentDispositionHeader { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the response contains the request data range.
        /// </summary>
        public bool IsPartial
        {
            get { return this.StatusCode == HttpStatusCode.PartialContent; }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all class resources.
        /// </summary>
        /// <param name="disposing">Value indicating whether the object is disposing or not.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
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

                this.disposedValue = true;
            }
        }
    }
}
