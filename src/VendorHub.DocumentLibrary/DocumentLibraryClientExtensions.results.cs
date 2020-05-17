// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
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
        /// <returns>Either the created library or an error.</returns>
        public static async Task<Result<Library>> CreateLibraryResultAsync(this IDocumentLibraryClient documentLibraryClient, CreateLibraryRequest body, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.CreateLibraryHttpResponseAsync(body, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<Library>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<Library>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(CreateLibraryResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<Library>();
                        }
                }
            }
        }

        /// <summary>
        /// Lists all libraries.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the library list or an error.</returns>
        public static async Task<Result<ICollection<Library>>> ListLibrariesResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.ListLibrariesHttpResponseAsync(tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<ICollection<Library>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<ICollection<Library>>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(ListLibrariesResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<ICollection<Library>>();
                        }
                }
            }
        }

        /// <summary>
        /// Gets a library.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the library or an error.</returns>
        public static async Task<Result<Library>> GetLibraryResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.GetLibraryHttpResponseAsync(libraryId, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<Library>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<Library>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(GetLibraryResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<Library>();
                        }
                }
            }
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
        /// <returns>Either the search results or an error.</returns>
        public static async Task<Result<ICollection<SearchResult<LibrarySearchResult>>>> SearchLibraryResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, string query, Guid? tenantId = null, string? filter = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.SearchLibraryHttpResponseAsync(libraryId, query, tenantId, filter, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<ICollection<SearchResult<LibrarySearchResult>>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<ICollection<SearchResult<LibrarySearchResult>>>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(SearchLibraryResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<ICollection<SearchResult<LibrarySearchResult>>>();
                        }
                }
            }
        }

        /// <summary>
        /// Downloads the file contents.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the http file stream or an error.</returns>
        public static async Task<Result<HttpFileResponse>> DownloadContentResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.DownloadContentHttpResponseAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    {
                        Result<HttpFileResponse> fileResponse = await HttpFileResponse.CreateAsync(response).ConfigureAwait(false);
                        return fileResponse;
                    }

                case HttpStatusCode.NoContent:
                    response.Dispose();
                    return default;
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.InternalServerError:
                    {
                        try
                        {
                            if (response.IsContentProblem())
                            {
                                HttpProblem problem = await response.DeserializeJsonContentAsync<HttpProblem>().ConfigureAwait(false);
                                return new HttpProblemError(problem).ToResult<HttpFileResponse>();
                            }
                            else
                            {
                                ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                                return errorResponse.Error.ToResult<HttpFileResponse>();
                            }
                        }
                        finally
                        {
                            response.Dispose();
                        }
                    }

                default:
                    {
                        UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(DownloadContentResultAsync)}").ConfigureAwait(false);
                        response.Dispose();
                        return error.ToResult<HttpFileResponse>();
                    }
            }
        }

        /// <summary>
        /// Gets metadata information about a file or directory.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the library item info or an error.</returns>
        public static async Task<Result<LibraryItemInfo>> GetItemInfoResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.GetItemInfoHttpResponseAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<LibraryItemInfo>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<LibraryItemInfo>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(GetItemInfoResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<LibraryItemInfo>();
                        }
                }
            }
        }

        /// <summary>
        /// Lists all tags associated with a file.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the file tags or an error.</returns>
        public static async Task<Result<IDictionary<string, string>>> ListFileTagsResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.ListFileTagsHttpResponseAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<IDictionary<string, string>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<IDictionary<string, string>>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(ListFileTagsResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<IDictionary<string, string>>();
                        }
                }
            }
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
        /// <returns>Either a succesful result or an error.</returns>
        public static async Task<Result> UpsertFileTagsResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, UpsertFileTagsRequest body, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.UpsertFileTagsHttpResponseAsync(libraryId, path, body, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Default;
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(UpsertFileTagsResultAsync)}").ConfigureAwait(false);
                            return error.ToResult();
                        }
                }
            }
        }

        /// <summary>
        /// Removes all tags associated with a file.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either a succesful result or an error.</returns>
        public static async Task<Result> ClearFileTagsResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.ClearFileTagsHttpResponseAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Default;
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(ClearFileTagsResultAsync)}").ConfigureAwait(false);
                            return error.ToResult();
                        }
                }
            }
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
        /// <returns>Either a succesful result or an error.</returns>
        public static async Task<Result> RemoveFileTagResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, string key, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.RemoveFileTagHttpResponseAsync(libraryId, path, key, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Default;
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(RemoveFileTagResultAsync)}").ConfigureAwait(false);
                            return error.ToResult();
                        }
                }
            }
        }

        /// <summary>
        /// Deletes a file or directory and all children.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either a succesful result or an error.</returns>
        public static async Task<Result> DeleteItemResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.DeleteItemHttpResponseAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Default;
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(DeleteItemResultAsync)}").ConfigureAwait(false);
                            return error.ToResult();
                        }
                }
            }
        }

        /// <summary>
        /// Lists directory children.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the directory children or an error.</returns>
        public static async Task<Result<ICollection<LibraryItemInfo>>> ListChildrenResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.ListChildrenHttpResponseAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<ICollection<LibraryItemInfo>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<ICollection<LibraryItemInfo>>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(ListChildrenResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<ICollection<LibraryItemInfo>>();
                        }
                }
            }
        }

        /// <summary>
        /// Checks if a file or directory exists.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the exists response or an error.</returns>
        public static async Task<Result<ExistsResponse>> ExistsResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.ExistsHttpResponseAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<ExistsResponse>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<ExistsResponse>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(ExistsResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<ExistsResponse>();
                        }
                }
            }
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
        /// <returns>Either a succesful result or an error.</returns>
        public static async Task<Result> CopyResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath source, CloudPath target, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.CopyHttpResponseAsync(libraryId, source, target, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Default;
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(CopyResultAsync)}").ConfigureAwait(false);
                            return error.ToResult();
                        }
                }
            }
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
        /// <returns>Either a succesful result or an error.</returns>
        public static async Task<Result> MoveResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath source, CloudPath target, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.MoveHttpResponseAsync(libraryId, source, target, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Default;
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(MoveResultAsync)}").ConfigureAwait(false);
                            return error.ToResult();
                        }
                }
            }
        }

        /// <summary>
        /// Creates a directory.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the directory.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the directory or an error.</returns>
        public static async Task<Result<LibraryDirectoryInfo>> CreateDirectoryResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.CreateDirectoryHttpResponseAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<LibraryDirectoryInfo>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<LibraryDirectoryInfo>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(CreateDirectoryResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<LibraryDirectoryInfo>();
                        }
                }
            }
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
        /// <returns>Either the file or an error.</returns>
        public static async Task<Result<LibraryFileInfo>> UploadFileResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Stream fileData, string? contentType = null, bool overwrite = false, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.UploadFileHttpResponseAsync(libraryId, path, fileData, contentType, overwrite, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<LibraryFileInfo>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<LibraryFileInfo>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(MoveResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<LibraryFileInfo>();
                        }
                }
            }
        }

        /// <summary>
        /// Imports files into a library.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="importRecords">The records to import.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the imported files or an error.</returns>
        public static async Task<Result<ICollection<LibraryFileInfo>>> ImportFilesResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, IEnumerable<ImportRecord> importRecords, CloudPath? path = null, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.ImportFilesHttpResponseAsync(libraryId, importRecords, path, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<ICollection<LibraryFileInfo>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<ICollection<LibraryFileInfo>>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(ImportFilesResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<ICollection<LibraryFileInfo>>();
                        }
                }
            }
        }

        /// <summary>
        /// Runs an Anti-Virus scan on a file.
        /// </summary>
        /// <param name="documentLibraryClient">The IDocumentLibraryClient instance.</param>
        /// <param name="libraryId">The library ID.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="tenantId">Optional. Specifies which tenant to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Either the imported files or an error.</returns>
        public static async Task<Result<AntiVirusScanResult>> AntiVirusScanFileResultAsync(this IDocumentLibraryClient documentLibraryClient, Guid libraryId, CloudPath path, Guid? tenantId = null, CancellationToken cancellationToken = default)
        {
            if (documentLibraryClient is null)
            {
                throw new ArgumentNullException(nameof(documentLibraryClient));
            }

            HttpResponseMessage response = await documentLibraryClient.AntiVirusScanFileHttpResponseAsync(libraryId, path, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<AntiVirusScanResult>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error.ToResult<AntiVirusScanResult>();
                        }

                    default:
                        {
                            UnexpectedStatusCodeError error = await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IDocumentLibraryClient)}.{nameof(AntiVirusScanFileResultAsync)}").ConfigureAwait(false);
                            return error.ToResult<AntiVirusScanResult>();
                        }
                }
            }
        }
    }
}
