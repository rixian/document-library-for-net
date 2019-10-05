// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.DocumentLibrary
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class JsonInheritanceAttribute : Attribute
    {
        public JsonInheritanceAttribute(string key, Type type)
        {
            Key = key;
            Type = type;
        }

        public string Key { get; }

        public Type Type { get; }
    }
}
