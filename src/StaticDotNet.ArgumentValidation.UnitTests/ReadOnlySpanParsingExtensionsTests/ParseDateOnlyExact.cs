﻿#if NET6_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanExtensionsTests;

public sealed class ParseDateOnlyExact {

	[Fact]
	public void ReturnsCorrectly() {

		DateOnly expectedResult = new( 2000, 1, 2 );
		string format = "yyyy-MM-dd";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );

		ArgInfo<DateOnly> result = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, format );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		DateOnly expectedResult = new( 2000, 1, 2 );
		string format = "yyyy-MM-dd";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateOnly> result = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, format, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		DateOnly expectedResult = new( 2000, 1, 2 );
		string format = "yyyy-MM-dd";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );
		DateTimeStyles styles = DateTimeStyles.None;

		ArgInfo<DateOnly> result = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, format, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string format = "yyyy-MM-dd";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, format );
		} );

		string expectedMessage = "Value must be parsable to System.DateOnly.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string format = "yyyy-MM-dd";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, format );
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsReturnsCorrectly() {

		DateOnly expectedResult = new( 2000, 1, 2 );
		string[] formats = new[] {
			"yyyy-MM-dd",
			"MM/dd/yyyy"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[0] ), null, null );

		ArgInfo<DateOnly> result = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, formats );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndProviderReturnsCorrectly() {

		DateOnly expectedResult = new( 2000, 1, 2 );
		string[] formats = new[] {
			"yyyy-MM-dd",
			"MM/dd/yyyy"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[0] ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateOnly> result = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, formats, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndStylesReturnsCorrectly() {

		DateOnly expectedResult = new( 2000, 1, 2 );
		string[] formats = new[] {
			"yyyy-MM-dd",
			"MM/dd/yyyy"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[0] ), null, null );
		DateTimeStyles styles = DateTimeStyles.None;

		ArgInfo<DateOnly> result = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, formats, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string[] formats = new[] {
			"yyyy-MM-dd",
			"MM/dd/yyyy"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, formats );
		} );

		string expectedMessage = "Value must be parsable to System.DateOnly.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string[] formats = new[] {
			"yyyy-MM-dd",
			"MM/dd/yyyy"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseDateOnlyExact( argInfo, formats );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
