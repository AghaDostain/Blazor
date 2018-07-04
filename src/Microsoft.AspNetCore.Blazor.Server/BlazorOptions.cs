// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Provides configuration options to the <see cref="BlazorAppBuilderExtensions.UseBlazor(IApplicationBuilder, System.Action{BlazorOptions})"/>
    /// middleware.
    /// </summary>
    public class BlazorOptions
    {
        /// <summary>
        /// Full path to the client assembly.
        /// </summary>
        public string ClientAssemblyPath { get; set; }

        /// <summary>
        /// Gets or sets a flag to indicate whether to enable debugging. If enabled,
        /// the server will listen for websocket connections from the debugger and
        /// will serve .pdb files.
        /// </summary>
        public bool EnableDebugging { get; set; }
    }
}
