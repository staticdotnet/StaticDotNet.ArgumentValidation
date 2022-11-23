﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_LessThan_Struct {

	[Fact]
	public void WithValueLessThanComparisonValueReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 2;

		int result = Argument.Is.LessThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData(2)]
	[InlineData(3)]
	public void WithValueNottLessThanComparisonValueThrowsArgumentOutOfRangeException( int value ) {

		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.LessThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		int value = 1;
		int? comparisonValue = null;

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.LessThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotLessThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int value = 2;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.LessThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotLessThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int value = 2;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Argument.Is.LessThan( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 2;
		IComparer<int> comparer = Comparer<int>.Default;

		int result = Argument.Is.LessThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 2;
		IComparer<int> comparer = null!;

		int result = Argument.Is.LessThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueLessThanComparisonValueReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 2;

		int? result = Argument.Is.LessThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void WithNullableValueNotLessThanComparisonValueThrowsArgumentOutOfRangeException(int? value) {

		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.LessThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int? comparisonValue = null;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.LessThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		int? value = null;
		int comparisonValue = 2;

		int? result = Argument.Is.LessThan( value, comparisonValue );

		Assert.Null( result );
	}


	[Fact]
	public void WithNullableValueNotLessThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int? value = 2;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.LessThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotLessThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int? value = 2;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.LessThan( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
