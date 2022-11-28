﻿using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class BooleanExtensions_True {

	[Fact]
	public void WithTrueValueReturnsCorrectly() {

		bool value = true;

		bool result = Arg.Is.True( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithFalseValueThrowsArgumentException() {

		bool value = false;

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.True( value ) );
	}

	[Fact]
	public void WithFalseValueAndNameThrowsArgumentException() {

		bool value = false;
		const string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => Arg.Is.True( value, name ) );

		const string expectedMessage = "Value must be true.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithFalseValueAndMessageThrowsArgumentException() {

		bool value = false;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.True( value, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithNullableTrueValueReturnsCorrectly() {

		bool? value = true;

		bool? result = Arg.Is.True( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		bool? value = null;

		bool? result = Arg.Is.True( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableFalseValueThrowsArgumentException() {

		bool? value = false;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.True( value ) );

		const string expectedMessage = "Value must be true.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableFalseValueAndNameThrowsArgumentException() {

		bool? value = false;
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.True( value, name ) );
	}

	[Fact]
	public void WithNullableFalseValueAndMessageThrowsArgumentException() {

		bool? value = false;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.True( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
