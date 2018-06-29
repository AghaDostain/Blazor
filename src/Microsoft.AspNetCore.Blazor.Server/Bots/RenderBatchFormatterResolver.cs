// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using MessagePack;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Blazor.Rendering;
using System;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// A MessagePack IFormatterResolver that provides an efficient binary serialization
    /// of <see cref="RenderBatch"/>. The client-side code knows how to walk through this
    /// binary representation directly, without it first being parsed as an object graph.
    /// </summary>
    class RenderBatchFormatterResolver : IFormatterResolver
    {
        public IMessagePackFormatter<T> GetFormatter<T>()
            => typeof(T) == typeof(RenderBatch) ? (IMessagePackFormatter<T>)RenderBatchFormatter.Instance : null;

        class RenderBatchFormatter : IMessagePackFormatter<RenderBatch>
        {
            public static readonly RenderBatchFormatter Instance = new RenderBatchFormatter();

            // No need to accept incoming RenderBatch
            public RenderBatch Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
                => throw new NotImplementedException();

            public int Serialize(ref byte[] bytes, int offset, RenderBatch value, IFormatterResolver formatterResolver)
            {
                // TODO: Actually serialize the data
                // We should also consider the perf tradeoff of writing out to a byte[] in memory
                // versus using the MessagePack stream APIs.
                var renderBatchAsBytes = new byte[] { 0x01, 0x02, 0x03 };
                return MessagePackBinary.WriteBytes(ref bytes, offset, renderBatchAsBytes);
            }
        }
    }
}
