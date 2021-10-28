// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
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
            var doc = System.Text.Json.JsonDocument.ParseValue(ref reader);
            if (doc.RootElement.TryGetProperty("type", out JsonElement type))
            {
                LibraryItemInfo? libraryItemInfo = type.GetString() switch
                {
                    "file" => JsonSerializer.Deserialize<LibraryFileInfo>(doc.RootElement.GetRawText()),
                    "directory" => JsonSerializer.Deserialize<LibraryDirectoryInfo>(doc.RootElement.GetRawText()),
                    _ => throw new JsonException(),
                };
                return libraryItemInfo!;
            }

            throw new JsonException();
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, LibraryItemInfo libraryItemInfo, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            Action? writeExtras = null;

            if (libraryItemInfo is LibraryFileInfo file)
            {
                writer.WriteString("type", "file");

                writeExtras = () =>
                {
                    writer.WriteNumber("length", file.Length);
                    writer.WriteString("contentType", file.ContentType);
                    writer.WriteBoolean("isShortcut", file.IsShortcut);
                    writer.WriteString("alternateId", file.AlternateId);
                };
            }
            else if (libraryItemInfo is LibraryDirectoryInfo dir)
            {
                writer.WriteString("type", "directory");

                writeExtras = () =>
                {
                    writer.WriteBoolean("hasChildren", dir.HasChildren);
                };
            }

            writer.WriteString("id", libraryItemInfo.Id);
            writer.WriteString("tenantId", libraryItemInfo.TenantId);
            writer.WriteString("partitionId", libraryItemInfo.PartitionId);
            writer.WriteString("libraryPath", libraryItemInfo.LibraryPath?.ToString());
            writer.WriteString("fullPath", libraryItemInfo.FullPath?.ToString());
            writer.WriteString("createdOn", libraryItemInfo.CreatedOn);
            writer.WriteString("lastAccessedOn", libraryItemInfo.LastAccessedOn);
            writer.WriteString("lastModifiedOn", libraryItemInfo.LastModifiedOn);
            writer.WriteString("name", libraryItemInfo.Name);

            if (libraryItemInfo.ParentDirectoryId is null)
            {
                writer.WriteNull("parentDirectoryId");
            }
            else
            {
                writer.WriteString("parentDirectoryId", libraryItemInfo.ParentDirectoryId.Value);
            }

            writer.WriteString("attributes", libraryItemInfo.Attributes);

            writeExtras?.Invoke();

            if (libraryItemInfo.AdditionalProperties is object)
            {
                foreach (KeyValuePair<string, object> item in libraryItemInfo.AdditionalProperties)
                {
                    writer.WritePropertyName(item.Key);
                    JsonSerializer.Serialize(writer, item.Value, item.Value.GetType(), options);
                }
            }

            writer.WriteEndObject();
        }
    }
}
