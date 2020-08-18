// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Net.Mime;
    using System.Text;
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

        /// <summary>
        /// Gets or sets the policy for the CreateDirectory http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? CreateDirectoryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the UploadFile http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? UploadFilePolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ImportFiles http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? ImportFilesPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the AntiVirusScanFile http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage>? AntiVirusScanFilePolicy { get; set; }

#nullable disable

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

#nullable enable
        /// <inheritdoc/>
        public async Task<HttpResponseMessage> SearchLibraryHttpResponseAsync(Guid libraryId, string query, Guid? tenantId = null, string? filter = null, CancellationToken cancellationToken = default)
        {
#nullable disable
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

#nullable enable
        /// <inheritdoc/>
        public async Task<HttpResponseMessage> SearchLibraryHttpResponseAsync(Guid libraryId, SearchRequest request, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
#nullable disable

            var queryComponents = new List<string>();

            if (!string.IsNullOrWhiteSpace(request.NameQuery))
            {
                queryComponents.Add($"name:('{request.NameQuery}')");
            }

            if (!string.IsNullOrWhiteSpace(request.PathQuery))
            {
                queryComponents.Add($"path:('{request.PathQuery}')");
            }

            if (!string.IsNullOrWhiteSpace(request.RawQuery))
            {
                queryComponents.Add(request.RawQuery);
            }

            var query = string.Join(" AND ", queryComponents.ToArray());

            var filterComponents = new List<string>();

            if (!string.IsNullOrWhiteSpace(request.Type))
            {
                filterComponents.Add($"type eq '{request.Type}'");
            }

            if (request.RequiredTags != null)
            {
                foreach (KeyValuePair<string, string> tag in request.RequiredTags)
                {
                    filterComponents.Add($"tags/any(tag: tag/key eq '{tag.Key}' and tag/value eq '{tag.Value}')");
                }
            }

            if (!string.IsNullOrWhiteSpace(request.RawFilter))
            {
                filterComponents.Add(request.RawFilter);
            }

            var filter = string.Join(" and ", filterComponents.ToArray());
            return await this.SearchLibraryHttpResponseAsync(libraryId, query, tenantId, filter, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> DownloadContentHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

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
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

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
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

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
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

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
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

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
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

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
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

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
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

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
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

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
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

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

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> CreateDirectoryHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/create")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewCreateDirectoryAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.CreateDirectoryPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

#nullable enable
        /// <inheritdoc/>
        public async Task<HttpResponseMessage> UploadFileHttpResponseAsync(Guid libraryId, CloudPath path, Stream fileData, string? contentType = null, bool overwrite = false, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
#nullable disable

            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/create")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .SetQueryParam("overwrite", overwrite)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson()
                .WithMultipartFormContent().WithFile("data", fileData, path.GetFileName(), contentType ?? MediaTypeNames.Application.Octet).RequestBuilder;

            requestBuilder = await this.PreviewUploadFileAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.UploadFilePolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

#nullable enable
        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ImportFilesHttpResponseAsync(Guid libraryId, IEnumerable<ImportRecord> importRecords, CloudPath? path = null, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
#nullable disable
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/import")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson()
                .WithContentJson(new
                {
                    files = importRecords,
                });

            requestBuilder = await this.PreviewImportFilesAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ImportFilesPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> AntiVirusScanFileHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("libraries/{libraryId}/cmd/avscan")
                .ReplaceToken("{libraryId}", libraryId)
                .SetQueryParam("path", path)
                .SetQueryParam("tenantId", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewAntiVirusScanFileAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.AntiVirusScanFilePolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

#nullable enable

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

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to CreateDirectory.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewCreateDirectoryAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to UploadFile.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewUploadFileAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to ImportFiles.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewImportFilesAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to AntiVirusScanFile.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewAntiVirusScanFileAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
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
