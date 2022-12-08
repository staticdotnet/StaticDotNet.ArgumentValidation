# Why should I use this

StaticDotNet.ArgumentValiation is a guard library with performance, nullability and ease of use in mind. Guard clauses should be clean and focus on performance when exceptions don't happen. In a perfect application, which we all know developers write 100% of the time, guard clauses take up CPU time, which is why they should be focused on being fast.

## This is what validation is for

Validation is focused on the end user, guard clauses are focused on developers. This is a big difference and why guard clauses are still important. The point of a guard clause is to prevent a developer from doing something that will always result in an issue with the application. Validation is focused on helping the end user accomplish a specific work flow based on the business requirements while adhering to the limitations of the application. Both are important, but serve completely different purposes.

## Nullability annotations makes guard clauses pointless

While nullability annontations is a huge step forward in help us developers write better applications, which as I stated earlier we don't need as we get it right 100% of the time, it doesn't replace the need for guard clauses.

- First those only help us address those dreaded "Object reference not set to an instance of an object" exceptions. If you haven't had to look at the stack trace, open a method of over 100 lines of code and tried to figure out what could possible be null in some randome situation, you haven't lived.
- Second, and this is especially important for libraries, they can be turned off.  And even if they aren't turned off, the number of times I have seen developers ignore those warnings just amazes me. Not you of course, you are one of the good developers, hence why you are here.
- And third, nullability annotations only help with checking for null. It doesn't help with the other issues that developers face in ensuring the parameters are valid.

## Writing guard clauses are ugly

Yes, writing guard clauses are ugly and they take up a lot of space.  That is why this library exists. We all agree they are important but they take up too many lines of code and are ugly.  Ok, maybe you don't agree, yet, but drink the Kool-Aid and I promise not space ships are involved.  That is one of the key points of this library is so they aren't so ugly and take up lines of code. One of the things I have learned with coding is that developers want to do the right thing, but if it involves a lot of boiler plate code, they skip it.  This library is built with developers in mind to make it quick and easy to write simple, performant guard clauses.

# Supported Frameworks

The library is also build with trying to support as many versions of the .NET framework that are currently supported by Microsoft.

# NuGet

The library is available through NuGet:
