# EqualTo

Ensures the argument equal to the a value, otherwise an ArgumentException is thrown.

## Object

**Example**
``` c#
Arg.Is( argument ).EqualTo( value );
```

## String

For string arguments, an additional overload allows you to specify the [StringComparision](https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparison) type to use.

**Example**
``` c#
Arg.Is( argument ).EqualTo( value, StringComparision.OrdinalIgnoreCase );
```