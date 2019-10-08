// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Rixian.Drive.Common;

    /// <summary>
    /// Client interface for the VendorHub Document Library Api.
    /// </summary>
    public interface IDocumentLibraryClient
    {
        /// <summary>
        /// Removes all tags associated with a file.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ClearFileTagsHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Copies a file or directory from a source location in the library to a target location.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="source">The path to the source file or directory.</param>
        /// <param name="target">The path to the target file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> CopyHttpResponseAsync(Guid libraryId, CloudPath source, CloudPath target, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new library.
        /// </summary>
        /// <param name="body">The library creation request.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> CreateLibraryHttpResponseAsync(CreateLibraryRequest body, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a directory.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> CreateDirectoryHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="fileData">The file data to upload.</param>
        /// <param name="contentType">Optional. The content type to assign this file.</param>
        /// <param name="overwrite">A value that indicates whether to overwrite the file if it already exists.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> UploadFileHttpResponseAsync(Guid libraryId, CloudPath path, Stream fileData, string? contentType = null, bool overwrite = false, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a file or directory and all children.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> DeleteItemHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Downloads the file contents.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> DownloadContentHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a file or directory exists.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ExistsHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets metadata information about a file or directory.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> GetItemInfoHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a library.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> GetLibraryHttpResponseAsync(Guid libraryId, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists directory children.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ListChildrenHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all tags associated with a file.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ListFileTagsHttpResponseAsync(Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all libraries.
        /// </summary>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ListLibrariesHttpResponseAsync(Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Moves a file or directory from a source location in the library to a target location.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="source">The path to the source file or directory.</param>
        /// <param name="target">The path to the target file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> MoveHttpResponseAsync(Guid libraryId, CloudPath source, CloudPath target, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes a single tag associated with a file.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="key">The meatadata key.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> RemoveFileTagHttpResponseAsync(Guid libraryId, CloudPath path, string key, Guid? tenantId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches a library for files according to the query.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="query">The search query.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="filter">Extra filters to aplly to the search.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> SearchLibraryHttpResponseAsync(Guid libraryId, string query, Guid? tenantId = null, string? filter = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates or inserts specific tags on a file.
        /// </summary>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="body">The upsert request body.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> UpsertFileTagsHttpResponseAsync(Guid libraryId, CloudPath path, UpsertFileTagsRequest body, Guid? tenantId = null, CancellationToken cancellationToken = default);
    }
}
