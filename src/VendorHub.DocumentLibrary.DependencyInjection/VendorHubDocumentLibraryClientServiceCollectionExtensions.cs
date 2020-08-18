// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Net.Http;
    using System.Security.Authentication;
    using Microsoft.Extensions.DependencyInjection;
    using Rixian.Extensions.Tokens;
    using VendorHub.DocumentLibrary;
    using VendorHub.DocumentLibrary.DependencyInjection;

    /// <summary>
    /// Extensions for adding IDocumentLibraryClient to the DI container.
    /// </summary>
    public static class VendorHubDocumentLibraryClientServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the IDocumentLibraryClient with the DI container.
        /// </summary>
        /// <param name="serviceCollection">The IServiceCollection.</param>
        /// <param name="options">Configuration options for this client.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddDocumentLibraryClient(this IServiceCollection serviceCollection, DocumentLibraryClientOptions options)
        {
            return serviceCollection.AddDocumentLibraryClient<DocumentLibraryClient>(options);
        }

        /// <summary>
        /// Registers the IDocumentLibraryClient with the DI container.
        /// </summary>
        /// <typeparam name="TClient">The type of the IDocumentLibraryClient.</typeparam>
        /// <param name="serviceCollection">The IServiceCollection.</param>
        /// <param name="options">Configuration options for this client.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddDocumentLibraryClient<TClient>(this IServiceCollection serviceCollection, DocumentLibraryClientOptions options)
            where TClient : class, IDocumentLibraryClient
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.TokenClientOptions is null)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            // Configure the HttpClient for use by the ITokenClient.
            serviceCollection.AddHttpClient(DocumentLibraryClientOptions.DocumentLibraryTokenClientBackChannelHttpClientName)
                .UseSslProtocols(SslProtocols.Tls12);

            if (string.IsNullOrWhiteSpace(options.TokenClientOptions.Authority))
            {
                options.TokenClientOptions.Authority = "https://identity.vendorhub.io";
            };

            // Configure the ITokenClient to use the previous HttpClient.
            serviceCollection
                .AddClientCredentialsTokenClient(DocumentLibraryClientOptions.DocumentLibraryTokenClientName, options.TokenClientOptions)
                .UseHttpClientForBackchannel(DocumentLibraryClientOptions.DocumentLibraryTokenClientBackChannelHttpClientName);

            // Configure the HttpClient with the ITokenClient for inserting tokens into the header.
            IHttpClientBuilder httpClientBuilder = serviceCollection
                .AddHttpClient(DocumentLibraryClientOptions.DocumentLibraryHttpClientName, c => c.BaseAddress = options.DocumentLibraryApiUri)
                .UseSslProtocols(SslProtocols.Tls12)
                .UseApiVersion(options.ApiVersion ?? "2019-09-01", null!)
                .UseTokenClient(DocumentLibraryClientOptions.DocumentLibraryTokenClientName)
                .AddTypedClient<IDocumentLibraryClient, TClient>();

            if (!string.IsNullOrWhiteSpace(options.ApiKey))
            {
                httpClientBuilder.UseHeader(options.ApiKeyHeaderName ?? "Subscription-Key", options.ApiKey!);
            }

            return serviceCollection;
        }

        /// <summary>
        /// Registers the IDocumentLibraryClient with the DI container.
        /// </summary>
        /// <param name="serviceCollection">The IServiceCollection.</param>
        /// <param name="options">Configuration options for this client.</param>
        /// <param name="factory">Factory used to construct instances of an IDocumentLibraryClient.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddDocumentLibraryClient(this IServiceCollection serviceCollection, DocumentLibraryClientOptions options, Func<HttpClient, IServiceProvider, IDocumentLibraryClient> factory)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.TokenClientOptions is null)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            // Configure the HttpClient for use by the ITokenClient.
            serviceCollection.AddHttpClient(DocumentLibraryClientOptions.DocumentLibraryTokenClientBackChannelHttpClientName)
                .UseSslProtocols(SslProtocols.Tls12);

            // Configure the ITokenClient to use the previous HttpClient.
            serviceCollection
                .AddClientCredentialsTokenClient(DocumentLibraryClientOptions.DocumentLibraryTokenClientName, options.TokenClientOptions)
                .UseHttpClientForBackchannel(DocumentLibraryClientOptions.DocumentLibraryTokenClientBackChannelHttpClientName);

            // Configure the HttpClient with the ITokenClient for inserting tokens into the header.
            IHttpClientBuilder httpClientBuilder = serviceCollection
                .AddHttpClient(DocumentLibraryClientOptions.DocumentLibraryHttpClientName, c => c.BaseAddress = options.DocumentLibraryApiUri)
                .UseSslProtocols(SslProtocols.Tls12)
                .UseApiVersion(options.ApiVersion ?? "2019-09-01", null!)
                .UseTokenClient(DocumentLibraryClientOptions.DocumentLibraryTokenClientName)
                .AddTypedClient(factory);

            if (!string.IsNullOrWhiteSpace(options.ApiKey))
            {
                httpClientBuilder.UseHeader(options.ApiKeyHeaderName ?? "Subscription-Key", options.ApiKey!);
            }

            return serviceCollection;
        }
    }
}
