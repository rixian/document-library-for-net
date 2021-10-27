// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// JsonConverter used for inheritance.
    /// </summary>
    public class LibraryItemInfoConverterWithTypeDiscriminator : JsonConverter<LibraryItemInfo>
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert) => typeof(LibraryItemInfo).IsAssignableFrom(typeToConvert);

        /// <inheritdoc/>
        public override LibraryItemInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Utf8JsonReader readerClone = reader;

            if (readerClone.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            readerClone.Read();
            if (readerClone.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string? propertyName = readerClone.GetString();
            if (propertyName != "type")
            {
                throw new JsonException();
            }

            readerClone.Read();
            if (readerClone.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            string? typeDiscriminator = reader.GetString();
            LibraryItemInfo? libraryItemInfo = typeDiscriminator switch
            {
                "file" => JsonSerializer.Deserialize<LibraryFileInfo>(ref reader),
                "directory" => JsonSerializer.Deserialize<LibraryDirectoryInfo>(ref reader),
                _ => throw new JsonException()
            };

            return libraryItemInfo;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, LibraryItemInfo libraryItemInfo, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, libraryItemInfo, libraryItemInfo?.GetType() ?? typeof(LibraryItemInfo), options);
        }
    }
}
