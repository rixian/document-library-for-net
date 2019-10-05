// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;

    /// <summary>
    /// Attribute used for declaring specific type for deserialization based on discrimination value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class JsonInheritanceAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonInheritanceAttribute"/> class.
        /// </summary>
        /// <param name="key">The discriminator key.</param>
        /// <param name="type">The type to instantiate.</param>
        public JsonInheritanceAttribute(string key, Type type)
        {
            this.Key = key;
            this.Type = type;
        }

        /// <summary>
        /// Gets the discriminator key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the specific type to instantiate.
        /// </summary>
        public Type Type { get; }
    }
}
