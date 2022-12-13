StaticDotNet.ArgumentValiation is a nullability annotation supported guard library with performance and ease of use in mind.

# Installation

Package can install via NuGet and can be found at https://www.nuget.org/packages/StaticDotNet.ArgumentValidation.

# Nullability annotations makes guard clauses pointless

While nullability annontations is a huge step forward in helping us developers write better applications (which we don't need as we get it right 100% of the time), it doesn't replace the need for guard clauses. And most of the guard libraries aren't able to fully support nullability annotations, which means you have to constantly ignore those warnings which really makes nullability annotations less helpful. And without them you have a bigger chance of getting the fun "Object not set to an instance of an object" error. If you haven't had to look at the stack trace, open a method of over 500 lines of code and tried to figure out what could possible be null in some random situation, you haven't lived.

If you are writing libraries that other developers/applications are using, your code has no way of knowing if nullability annontations are turned on.  Or worse case those warnings are just ignored anyway. Not you of course, you are one of the good developers, hence why you are here.

Lastly nullability annotations only help with checking for null. It doesn't help with the other requirements that parameters have.

# This is what validation is for

Validation is focused on the end user, guard clauses are focused on developers. This is a big difference and why guard clauses are still important. The point of a guard clause is to prevent a developer from doing something that will always result in an issue with the application. Validation is focused on helping the end user accomplish a specific work flow based on the business requirements while adhering to the limitations of the application. Both are important, but serve completely different purposes.

# Performance

Since the point of guard clauses are to ensure the developer doesn't write bad code, ideally they should never throw an exception.  This library is built around the idea that it should be just as fast as possible and avoid allocating any memory with the idea that the exception will not happen.

The library also fully supports trimming so you can only include the code that is actually used.

It also uses a readonly ref struct so as much as possible stays on the stack without copying the struct on every call.

All methods have benchmark run against them based on the most common way of writing the guard clause to accomplish the same functionality. The baseline isn't focused on what is fast to execute, but what is generally written. Other guard libraries are included as a comparison if the library supports the same functionality.

All benchmarks were run on the following:
```
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]        : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  .NET 6.0      : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  .NET 7.0      : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  .NET Core 3.1 : .NET Core 3.1.31 (CoreCLR 4.700.22.51102, CoreFX 4.700.22.51303), X64 RyuJIT AVX2
```

# Writing guard clauses are ugly

Yes, writing guard clauses are ugly and they take up a lot of space.  We all agree they are important but they take up too many lines of code and are ugly.  Ok, maybe you don't agree, yet, but drink the Kool-Aid and I promise no space ships are involved.

The library is built using fluent syntax as that allows the developer a lot of flexibility with how they want to combine different argument validation. It is also built to only show the available validation methods for the specific argument type. For example, the NotWhiteSpace validation method is only shown in intellisense for string arguments.

# Documentation

All documentation can be found at [here](./docs/README.md).