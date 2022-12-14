﻿namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class ToType {

	[Fact]
	public void ReturnsCorrectly() {

		Type expectedType = typeof( string );
		ArgInfo<string> argInfo = new( expectedType.FullName ?? throw new InvalidOperationException( "Fullname not available."), null, null );

		ArgInfo<Type> result = StringExtensions.ToType( argInfo );

		Assert.Same( expectedType, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringExtensions.ToType( argInfo );
		} );

		string expectedMessage = "Value must be a type.";

		Assert.StartsWith( expectedMessage, exception.Message );
		Assert.NotNull( exception.InnerException );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.ToType( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
		Assert.NotNull( exception.InnerException );
	}
}
