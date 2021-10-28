// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Rixian.Drive.Common;

#pragma warning disable CA1812 // Avoid uninstantiated internal classes
    /// <summary>
    /// Newtonsoft JsonConverter for CloudPath.
    /// </summary>
    internal class CloudPathJsonConverter : JsonConverter<CloudPath>
    {
        /// <inheritdoc/>
        public override CloudPath? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString();
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, CloudPath value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString());
        }
    }
#pragma warning restore CA1812 // Avoid uninstantiated internal classes
}
