using System;

namespace JsonPolymorph
{
    /// <summary>
    /// <para>Identifies a type as the base for a JSON hierarchy, enabling polymorphic deserialization.</para>
    /// <para>The target of this attribute must be a <c>partial record</c> or <c>partial abstract record</c>.
    /// Applying the <see cref="JsonHierarchyBaseAttribute"/> to a type will cause the following attributes to be added at compile time:
    /// <list type="bullet">
    /// <item>
    /// An instance of <c>JsonConverterAttribute</c> with a hardcoded JSON discriminator property name, i.e.:
    /// <code>[Newtonsoft.Json.JsonConverter(typeof(NJsonSchema.Converters.JsonInheritanceConverter), "discriminator")]</code>
    /// </item>
    /// <item>
    /// For every type in the assembly that is derived from the target, an instance of <c>KnownTypeAttribute</c>, i.e.:
    /// <code>[System.Runtime.Serialization.KnownType(typeof(DerivedRecordType))]</code>
    /// </item>
    /// </list>
    /// Applying this attribute is only supported at the base level of the hierarchy, i.e. a <c>record</c> directly derived from <c>object</c>.</para>
    /// </summary>
    /// <example>
    /// [JsonHierarchyBase]
    /// public abstract partial record VehicleCommand();
    /// public sealed record TurnLeft() : VehicleCommand;
    /// public sealed record TurnRight() : VehicleCommand;
    /// </example>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class JsonHierarchyBaseAttribute : Attribute
    { }
}
