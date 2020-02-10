﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Bot.Builder.Dialogs.Adaptive.Generators;
using Microsoft.Bot.Builder.Dialogs.Declarative.Converters;
using Microsoft.Bot.Builder.Dialogs.Declarative.Resources;
using Newtonsoft.Json;

namespace Microsoft.Bot.Builder.Dialogs.Adaptive
{
    /// <summary>
    /// JsonConverter which understands how to deal with strings when assigning to ILanguageGenerator.
    /// </summary>
    public class LanguageGeneratorConverter : InterfaceConverter<ILanguageGenerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageGeneratorConverter"/> class.
        /// </summary>
        /// <param name="resourceExplorer">resourcexplorer to use to resolve references.</param>
        /// <param name="paths">path stack to build debugger call graph.</param>
        public LanguageGeneratorConverter(ResourceExplorer resourceExplorer, Stack<string> paths)
            : base(resourceExplorer, paths)
        {
        }

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(string))
            {
                string readerValue = reader.Value.ToString();

                return new ResourceMultiLanguageGenerator(readerValue);
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            base.WriteJson(writer, value, serializer);
        }
    }
}
