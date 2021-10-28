// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using RichardSzalay.MockHttp;
using Rixian.Extensions.Tokens;
using VendorHub.DocumentLibrary;
using VendorHub.DocumentLibrary.DependencyInjection;
using Xunit;
using Xunit.Abstractions;
using static Rixian.Extensions.Errors.Prelude;

public class DocumentLibraryClientTests
{
    private readonly ITestOutputHelper logger;

    public DocumentLibraryClientTests(ITestOutputHelper logger)
    {
        this.logger = logger;
    }

    [Fact]
    public async Task ValidateRequest_Default_Success()
    {
        string location = Guid.NewGuid().ToString();
        string name = Guid.NewGuid().ToString();
        string libraryId = Guid.NewGuid().ToString();
        string tenantId = Guid.NewGuid().ToString();

        var mockHttp = new MockHttpMessageHandler();
        MockedRequest request = mockHttp
            .When(HttpMethod.Get, "*/libraries")
            .Respond("application/json", $"[{{\"libraryId\": \"{libraryId}\", \"tenantId\": \"{tenantId}\", \"name\": \"{name}\", \"location\": \"{location}\"}}]");

        IServiceProvider services = ConfigureServices(mockHttp);
        IDocumentLibraryClient docLibClient = services.GetRequiredService<IDocumentLibraryClient>();

        ICollection<Library> libraries = await docLibClient.ListLibrariesAsync().ConfigureAwait(false);

        mockHttp.GetMatchCount(request).Should().Be(1);

        libraries.Should().NotBeNullOrEmpty();
        libraries.Should().HaveCount(1);

        Library library = libraries.Single();
        library.Should().NotBeNull();
        library.TenantId.Should().Be(tenantId);
        library.Name.Should().Be(name);
    }

    private static IServiceProvider ConfigureServices(MockHttpMessageHandler mockHttp)
    {
        (string accessToken, ITokenClientFactory tokenClientFactory) = MockTokenClientFactory();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton(tokenClientFactory);

        serviceCollection.AddHttpClient(DocumentLibraryClientOptions.DocumentLibraryHttpClientName)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        serviceCollection.AddDocumentLibraryClient(new DocumentLibraryClientOptions
        {
            TokenClientOptions = new ClientCredentialsTokenClientOptions
            {
                Authority = string.Empty,
                ClientId = string.Empty,
                ClientSecret = string.Empty,
            },
            DocumentLibraryApiUri = new Uri("http://localhost"),
        });

        return serviceCollection.BuildServiceProvider();
    }

    private static (string AccessToken, ITokenClientFactory TokenClientFactory) MockTokenClientFactory()
    {
        var accessToken = Guid.NewGuid().ToString();
        ITokenInfo tokenInfo = Substitute.For<ITokenInfo>();
        tokenInfo.AccessToken.Returns(accessToken);
        ITokenClient tokenClient = Substitute.For<ITokenClient>();
        tokenClient.GetTokenAsync(Arg.Any<bool>()).Returns(Result(tokenInfo));
        ITokenClientFactory tokenClientFactory = Substitute.For<ITokenClientFactory>();
        tokenClientFactory.GetTokenClient(DocumentLibraryClientOptions.DocumentLibraryTokenClientName).Returns(Result(tokenClient));
        return (accessToken, tokenClientFactory);
    }
}
