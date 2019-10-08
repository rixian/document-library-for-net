// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Rixian.Drive.Common;
    using Rixian.Extensions.Errors;
    using Rixian.Extensions.Http.Client;

    /// <summary>
    /// Extensions for the VendorHub Document Library api client.
    /// </summary>
    public static partial class DocumentLibraryClientExtensions
    {
        /// <summary>
        /// Creates a new library.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="body">The library creation request.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The created library.</returns>
        public static async Task<Library> CreateLibraryAsync(this IDocumentLibraryClient documentLibraryClient, CreateLibraryRequest body, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<Library> result = await documentLibraryClient.CreateLibraryResultAsync(body, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Lists all libraries.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The library list.</returns>
        public static async Task<ICollection<Library>> ListLibrariesAsync(this IDocumentLibraryClient documentLibraryClient, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<ICollection<Library>> result = await documentLibraryClient.ListLibrariesResultAsync(tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Gets a library.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The library.</returns>
        public static async Task<Library> GetLibraryAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<Library> result = await documentLibraryClient.GetLibraryResultAsync(libraryId, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Searches a library for files according to the query.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="query">The search query.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="filter">Extra filters to aplly to the search.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The search results.</returns>
        public static async Task<ICollection<SearchResult<LibrarySearchResult>>> SearchLibraryAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, string query, Guid? tenantId = null, string? filter = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<ICollection<SearchResult<LibrarySearchResult>>> result = await documentLibraryClient.SearchLibraryResultAsync(libraryId, query, tenantId, filter, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Downloads the file contents.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The http file stream.</returns>
        public static async Task<HttpFileResponse> DownloadContentAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<HttpFileResponse> result = await documentLibraryClient.DownloadContentResultAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Gets metadata information about a file or directory.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The library item info.</returns>
        public static async Task<LibraryItemInfo> GetItemInfoAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<LibraryItemInfo> result = await documentLibraryClient.GetItemInfoResultAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Lists all tags associated with a file.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The file tags.</returns>
        public static async Task<IDictionary<string, string>> ListFileTagsAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<IDictionary<string, string>> result = await documentLibraryClient.ListFileTagsResultAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Updates or inserts specific tags on a file.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="body">The upsert request body.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success if there were no errors.</returns>
        public static async Task UpsertFileTagsAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, UpsertFileTagsRequest body, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result result = await documentLibraryClient.UpsertFileTagsResultAsync(libraryId, path, body, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                return;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Removes all tags associated with a file.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success if there were no errors.</returns>
        public static async Task ClearFileTagsAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result result = await documentLibraryClient.ClearFileTagsResultAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                return;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Removes a single tag associated with a file.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="key">The meatadata key.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success if there were no errors.</returns>
        public static async Task RemoveFileTagAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, string key, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result result = await documentLibraryClient.RemoveFileTagResultAsync(libraryId, path, key, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                return;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Deletes a file or directory and all children.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success if there were no errors.</returns>
        public static async Task DeleteItemAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result result = await documentLibraryClient.DeleteItemResultAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                return;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Lists directory children.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The directory children.</returns>
        public static async Task<ICollection<LibraryItemInfo>> ListChildrenAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<ICollection<LibraryItemInfo>> result = await documentLibraryClient.ListChildrenResultAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Checks if a file or directory exists.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The exists response.</returns>
        public static async Task<ExistsResponse> ExistsAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<ExistsResponse> result = await documentLibraryClient.ExistsResultAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Copies a file or directory from a source location in the library to a target location.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="source">The path to the source file or directory.</param>
        /// <param name="target">The path to the target file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success if there were no errors.</returns>
        public static async Task CopyAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath source, CloudPath target, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result result = await documentLibraryClient.CopyResultAsync(libraryId, source, target, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                return;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Moves a file or directory from a source location in the library to a target location.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="source">The path to the source file or directory.</param>
        /// <param name="target">The path to the target file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success if there were no errors.</returns>
        public static async Task MoveAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath source, CloudPath target, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result result = await documentLibraryClient.MoveResultAsync(libraryId, source, target, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                return;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Creates a directory.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The created directory.</returns>
        public static async Task<LibraryDirectoryInfo> CreateDirectoryAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<LibraryDirectoryInfo> result = await documentLibraryClient.CreateDirectoryResultAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="fileData">The file data to upload.</param>
        /// <param name="contentType">Optional. The content type to assign this file.</param>
        /// <param name="overwrite">A value that indicates whether to overwrite the file if it already exists.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The uploaded file.</returns>
        public static async Task<LibraryFileInfo> UploadFileAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Stream fileData, string? contentType = null, bool overwrite = false, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            Result<LibraryFileInfo> result = await documentLibraryClient.UploadFileResultAsync(libraryId, path, fileData, contentType, overwrite, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }
    }
}
