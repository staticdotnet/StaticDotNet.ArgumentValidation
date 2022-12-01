﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StringExtensions_MinLength {

	[Theory]
	[InlineData(5)]
	[InlineData(4)]
	public void ReturnsCorrectly( int minLength) {

		ArgInfo<string> argInfo = new( "Value", null, null );

		ArgInfo<string> result = StringExtensions.MinLength( argInfo, minLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = StringExtensions.MinLength( argInfo, 0 );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		int minLength = value.Length + 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = StringExtensions.MinLength( argInfo, minLength );
		} );

		string expectedMessage = $"Value cannot have a length less than {minLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string message = "Message";
		int minLength = value.Length + 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = StringExtensions.MinLength( argInfo, minLength );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
