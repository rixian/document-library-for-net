// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using Rixian.Drive.Common;

#pragma warning disable CA1812 // Avoid uninstantiated internal classes
    /// <summary>
    /// Newtonsoft JsonConverter for CloudPath.
    /// </summary>
    internal class CloudPathJsonConverter : JsonConverter<CloudPath>
    {
        /// <inheritdoc/>
        public override CloudPath ReadJson(JsonReader reader, Type objectType, CloudPath existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader is null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            var s = reader.Value as string;
            return s;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, CloudPath value, JsonSerializer serializer)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteValue(value?.ToString());
        }
    }
#pragma warning restore CA1812 // Avoid uninstantiated internal classes
}
