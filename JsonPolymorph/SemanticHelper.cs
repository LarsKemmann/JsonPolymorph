using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace JsonPolymorph
{
    /// <remarks>
    /// The code in this file is derived from:
    /// https://github.com/Grauenwolf/Tortuga-TestMonkey/blob/45d8001c535b7c376af1747c0a894422fa6384a7/Tortuga.TestMonkey/SemanticHelper.cs
    /// </remarks>
    internal static class SemanticHelper
    {
        public static string FullNamespace(this ISymbol symbol)
        {
            var parts = new Stack<string>();
            var iterator = (symbol as INamespaceSymbol) ?? symbol.ContainingNamespace;
            while (iterator != null)
            {
                if (!string.IsNullOrEmpty(iterator.Name))
                    parts.Push(iterator.Name);
                iterator = iterator.ContainingNamespace;
            }
            return string.Join(".", parts);
        }
    }
}
