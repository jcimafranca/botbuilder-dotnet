﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Data.SqlTypes;
using Microsoft.Bot.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Bot.Builder.Dialogs.Adaptive.Converters
{
    /// <summary>
    /// Converter which allows json to be expression to object or static object.
    /// </summary>
    /// <typeparam name="T">The property type to construct which is IExpressionProperty.</typeparam>
    public class StringExpressionConverter : JsonConverter<StringExpression>
    {
        public StringExpressionConverter()
        {
        }

        public override StringExpression ReadJson(JsonReader reader, Type objectType, StringExpression existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(string))
            {
                return new StringExpression((string)reader.Value);
            }
            else
            {
                return new StringExpression(JToken.Load(reader));
            }
        }

        public override void WriteJson(JsonWriter writer, StringExpression value, JsonSerializer serializer)
        {
            if (value.Expression != null)
            {
                serializer.Serialize(writer, value.ToString());
            }
            else
            {
                serializer.Serialize(writer, value.Value);
            }
        }
    }
}
