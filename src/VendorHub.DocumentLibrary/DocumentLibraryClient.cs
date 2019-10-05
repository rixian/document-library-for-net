// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Polly;
    using Rixian.Drive.Common;
    using Rixian.Extensions.Http.Client;

    /// <summary>
    /// Client for the VendorHub Document Library Api.
    /// </summary>
    public class DocumentLibraryClient : IDocumentLibraryClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentLibraryClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HttpClient to use for all requests.</param>
        public DocumentLibraryClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Gets or sets the policy for the CreateLibrary http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? CreateLibraryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ListLibraries http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? ListLibrariesPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the GetLibrary http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? GetLibraryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the SearchLibrary http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? SearchLibraryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the DownloadContent http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? DownloadContentPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the GetItemInfo http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? GetItemInfoPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ListFileTags http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? ListFileTagsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the UpsertFileTags http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? UpsertFileTagsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ClearFileTags http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? ClearFileTagsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the RemoveFileTag http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? RemoveFileTagPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the DeleteItem http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? DeleteItemPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ListChildren http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? ListChildrenPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the Exists http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? ExistsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the Copy http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? CopyPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the Move http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? MovePolicy { get; set; }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> CreateLibraryHttpResponseAsync(CreateLibraryRequest body, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries")
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson()
                .WithContentJson(body);

            requestBuilder = await this.PreviewCreateLibraryAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.CreateLibraryPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ListLibrariesHttpResponseAsync(Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries")
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewListLibrariesAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ListLibrariesPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetLibraryHttpResponseAsync(Guid libraryId, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewGetLibraryAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.GetLibraryPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> SearchLibraryHttpResponseAsync(Guid libraryId, string query, Guid? tenantId = null, string? filter = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/search")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("query", query)
                .SetQueryParam("tenantId", tenantId)
                .SetQueryParam("filter", filter)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewSearchLibraryAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.SearchLibraryPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> DownloadContentHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/download")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Get();

            requestBuilder = await this.PreviewDownloadContentAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.DownloadContentPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetItemInfoHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/info")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewGetItemInfoAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.GetItemInfoPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ListFileTagsHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/list-tags")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewListFileTagsAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ListFileTagsPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> UpsertFileTagsHttpResponseAsync(Guid libraryId, CloudPath path, UpsertFileTagsRequest body, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/upsert-tags")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson()
                .WithContentJson(body);

            requestBuilder = await this.PreviewUpsertFileTagsAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.UpsertFileTagsPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ClearFileTagsHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/clear-tags")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewClearFileTagsAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ClearFileTagsPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> RemoveFileTagHttpResponseAsync(Guid libraryId, CloudPath path, string key, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/remove-tag")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("key", key)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewRemoveFileTagAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.RemoveFileTagPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> DeleteItemHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/delete")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewDeleteItemAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.DeleteItemPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ListChildrenHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/dir")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewListChildrenAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ListChildrenPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ExistsHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/exists")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewExistsAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ExistsPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> CopyHttpResponseAsync(Guid libraryId, CloudPath source, CloudPath target, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/copy")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("source", source)
                .SetQueryParam("target", target)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewCopyAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.CopyPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> MoveHttpResponseAsync(Guid libraryId, CloudPath source, CloudPath target, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/move")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("source", source)
                .SetQueryParam("target", target)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewMoveAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.MovePolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to CreateLibrary.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewCreateLibraryAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to ListLibraries.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewListLibrariesAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to GetLibrary.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewGetLibraryAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to SearchLibrary.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewSearchLibraryAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to DownloadContent.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewDownloadContentAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to GetItemInfo.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewGetItemInfoAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to ListFileTags.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewListFileTagsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to UpsertFileTags.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewUpsertFileTagsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to ClearFileTags.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewClearFileTagsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to RemoveFileTag.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewRemoveFileTagAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to DeleteItem.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewDeleteItemAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to ListChildren.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewListChildrenAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to Exists.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewExistsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to Copy.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewCopyAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to Move.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewMoveAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        private async Task<HttpResponseMessage> SendRequestWithPolicy(IHttpRequestMessageBuilder requestBuilder, IAsyncPolicy<HttpResponseMessage>? policy = null, CancellationToken cancellationToken = default)
        {
            HttpRequestMessage request = requestBuilder.Request;
            using (request)
            {
                Func<Task<HttpResponseMessage>> sendRequest = () => this.httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
                if (policy != null)
                {
                    HttpResponseMessage response = await policy.ExecuteAsync(sendRequest).ConfigureAwait(false);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = await sendRequest().ConfigureAwait(false);
                    return response;
                }
            }
        }
    }
}
