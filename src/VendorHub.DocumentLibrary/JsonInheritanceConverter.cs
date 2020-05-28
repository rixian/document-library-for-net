// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;
    using Newtonsoft.Json;

#pragma warning disable CA1812 // Avoid uninstantiated internal classes
    /// <summary>
    /// JsonConverter used for inheritance.
    /// </summary>
    internal class JsonInheritanceConverter : JsonConverter
    {
        /// <summary>
        /// The default discriminator name.
        /// </summary>
        internal const string DefaultDiscriminatorName = "discriminator";

        [ThreadStatic]
        private static bool isReading;

        [ThreadStatic]
        private static bool isWriting;

        private readonly string discriminator;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonInheritanceConverter"/> class.
        /// </summary>
        public JsonInheritanceConverter()
        {
            this.discriminator = DefaultDiscriminatorName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonInheritanceConverter"/> class.
        /// </summary>
        /// <param name="discriminator">The name of the property to use for discrimination.</param>
        public JsonInheritanceConverter(string discriminator)
        {
            this.discriminator = discriminator;
        }

        /// <inheritdoc/>
        public override bool CanWrite
        {
            get
            {
                if (isWriting)
                {
                    isWriting = false;
                    return false;
                }

                return true;
            }
        }

        /// <inheritdoc/>
        public override bool CanRead
        {
            get
            {
                if (isReading)
                {
                    isReading = false;
                    return false;
                }

                return true;
            }
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                isWriting = true;

                var jObject = Newtonsoft.Json.Linq.JObject.FromObject(value, serializer);
                jObject.AddFirst(new Newtonsoft.Json.Linq.JProperty(this.discriminator, GetSubtypeDiscriminator(value.GetType())));
                writer.WriteToken(jObject.CreateReader());
            }
            finally
            {
                isWriting = false;
            }
        }

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        /// <inheritdoc/>
        public override object? ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jObject = serializer.Deserialize<Newtonsoft.Json.Linq.JObject>(reader);
            if (jObject == null)
            {
                return null;
            }

            var discriminator = Newtonsoft.Json.Linq.Extensions.Value<string>(jObject.GetValue(this.discriminator, StringComparison.OrdinalIgnoreCase));
            Type subtype = GetObjectSubtype(objectType, discriminator);

            var objectContract = serializer.ContractResolver.ResolveContract(subtype) as Newtonsoft.Json.Serialization.JsonObjectContract;
            if (objectContract == null || System.Linq.Enumerable.All(objectContract.Properties, p => p.PropertyName != this.discriminator))
            {
                jObject.Remove(this.discriminator);
            }

            try
            {
                isReading = true;
                return serializer.Deserialize(jObject.CreateReader(), subtype);
            }
            finally
            {
                isReading = false;
            }
        }

        private static Type GetObjectSubtype(Type objectType, string discriminator)
        {
            foreach (JsonInheritanceAttribute attribute in System.Reflection.CustomAttributeExtensions.GetCustomAttributes<JsonInheritanceAttribute>(System.Reflection.IntrospectionExtensions.GetTypeInfo(objectType), true))
            {
                if (attribute.Key == discriminator)
                {
                    return attribute.Type;
                }
            }

            return objectType;
        }

        private static string GetSubtypeDiscriminator(Type objectType)
        {
            foreach (JsonInheritanceAttribute attribute in System.Reflection.CustomAttributeExtensions.GetCustomAttributes<JsonInheritanceAttribute>(System.Reflection.IntrospectionExtensions.GetTypeInfo(objectType), true))
            {
                if (attribute.Type == objectType)
                {
                    return attribute.Key;
                }
            }

            return objectType.Name;
        }
    }
#pragma warning restore CA1812 // Avoid uninstantiated internal classes
}
