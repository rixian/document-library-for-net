// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary.DependencyInjection
{
    using System;
    using Rixian.Extensions.Tokens;

    /// <summary>
    /// Options for configuring an instance of IDocumentLibraryClientOptions.
    /// </summary>
    public class DocumentLibraryClientOptions
    {
        /// <summary>
        /// Logical name for the HttpClient configured to call the VendorHub Document Library Api.
        /// </summary>
        public const string DocumentLibraryHttpClientName = "vh_doclib";

        /// <summary>
        /// Logical name for the ITokenClient that provides access tokens for calling the VendorHub Document Library Api.
        /// </summary>
        public const string DocumentLibraryTokenClientName = "vh_doclib_token";

        /// <summary>
        /// Logical name for the HttpClient configured for use by the VendorHub Document Library ITokenClient.
        /// </summary>
        public const string DocumentLibraryTokenClientBackChannelHttpClientName = "vh_oidc";

        /// <summary>
        /// Gets or sets the options for the ITokenClient.
        /// </summary>
        public ClientCredentialsTokenClientOptions? TokenClientOptions { get; set; }

        /// <summary>
        /// Gets or sets the uri of the Document Library api endpoint.
        /// </summary>
        public Uri? DocumentLibraryApiUri { get; set; }

        /// <summary>
        /// Gets or sets the api key used for the IAM api.
        /// </summary>
        public string? ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the header name used for passing the api key. Defaults to 'Subscription-Key'.
        /// </summary>
        public string ApiKeyHeaderName { get; set; } = "Subscription-Key";

        /// <summary>
        /// Gets or sets the version of the Document Library api. Defaults to '2019-09-01'.
        /// </summary>
        public string ApiVersion { get; set; } = "2019-09-01";
    }
}
