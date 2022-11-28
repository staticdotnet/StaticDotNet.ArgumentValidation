﻿namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class NullExtensions_NotNull_Class {

	[Fact]
	public void WithNotNullValueReturnsCorrectly() {
		object value = new();

		object result = Arg.Is.NotNull( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		object? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNull( value ) );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException() {
		object? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.Is.NotNull( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {
		object? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ),
			() => Arg.Is.NotNull( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}