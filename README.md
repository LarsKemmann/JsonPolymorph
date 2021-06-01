# JsonPolymorph
JsonPolymorph is a .NET helper library to simplify generating polymorphic JSON models from C# record hierarchies.
It is intended to be used with [NSwag](https://github.com/RicoSuter/NSwag) to generate OpenAPI v3 schemas and client-side
code for ASP.NET Core web APIs that properly round-trips C# record hierarchies to and from JSON.

## Usage
Installation is via [the `JsonPolymorph` NuGet package](https://www.nuget.org/packages/JsonPolymorph/).

A simple example:
```csharp
[JsonHierarchyBase]
public abstract partial record VehicleCommand();
public sealed record TurnLeft() : VehicleCommand;
public sealed record TurnRight() : VehicleCommand;
```

Applying the `JsonHierarchyBaseAttribute` to a type will cause the following attributes to be added at compile time:
* An instance of `JsonConverterAttribute` with a hardcoded JSON discriminator property name,
i.e. `[Newtonsoft.Json.JsonConverter(typeof(NJsonSchema.Converters.JsonInheritanceConverter), "discriminator")]`
* For every type `DerivedRecordType` in the assembly that is derived from the target, an instance of `KnownTypeAttribute`,
i.e. `[System.Runtime.Serialization.KnownType(typeof(DerivedRecordType))]`

Applying this attribute is only supported at the base level of the hierarchy, i.e. a `record` directly derived from `object`.

## Credits
Many thanks to [Jonathan Allen (@Grauenwolf)](https://github.com/Grauenwolf)
for [the fantastic InfoQ article](https://www.infoq.com/articles/CSharp-Source-Generator/)
and [sample code](https://github.com/Grauenwolf/Tortuga-TestMonkey) that served as the inspiration for this project.
