// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text.Json;
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

public class SerializationTests
{
    private readonly ITestOutputHelper logger;

    public SerializationTests(ITestOutputHelper logger)
    {
        this.logger = logger;
    }

    [Fact]
    public void ValidateRequest_Default_Success()
    {
        var file = new LibraryFileInfo
        {
            Id = Guid.NewGuid(),
            TenantId = Guid.NewGuid(),
            AlternateId = Guid.NewGuid().ToString(),
            Attributes = "Hidden",
            ContentType = MediaTypeNames.Application.Octet,
            CreatedOn = DateTimeOffset.UtcNow,
            FullPath = "C:/foo.txt",
            LibraryPath = "/foo.txt",
            Name = "foo.txt",
            LastAccessedOn = DateTimeOffset.UtcNow,
            LastModifiedOn = DateTimeOffset.UtcNow,
            Length = 123,
            ParentDirectoryId = Guid.NewGuid(),
            PartitionId = Guid.NewGuid(),
        };

        var serialized = JsonSerializer.Serialize(file);
        LibraryItemInfo libItem = JsonSerializer.Deserialize<LibraryItemInfo>(serialized);

        libItem.Should().NotBeNull();
        libItem.Should().BeOfType<LibraryFileInfo>();

        LibraryFileInfo? newFile = libItem as LibraryFileInfo;
        newFile.Should().BeEquivalentTo(file);
    }
}
