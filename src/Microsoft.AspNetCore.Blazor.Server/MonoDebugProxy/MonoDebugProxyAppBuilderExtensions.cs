// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using WsProxy;

namespace Microsoft.AspNetCore.Builder
{
    internal static class MonoDebugProxyAppBuilderExtensions
    {
        public static void UseMonoDebugProxy(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseWebSockets();

            applicationBuilder.Map("/_framework/debug/ws-proxy", childBuilder =>
            {
                childBuilder.Use(async (context, next) =>
                {
                    if (!context.WebSockets.IsWebSocketRequest)
                    {
                        context.Response.StatusCode = 400;
                        return;
                    }

                    var browserUri = new Uri(context.Request.Query["browser"]);
                    await new MonoProxy().Run(context, browserUri);
                });
            });
        }
    }
}
