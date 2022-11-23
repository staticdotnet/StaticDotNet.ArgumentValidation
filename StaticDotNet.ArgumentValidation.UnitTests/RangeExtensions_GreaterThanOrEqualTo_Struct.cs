﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_GreaterThanOrEqualTo_Struct {

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void WithValueGreaterThanOrEqualToComparisonValueReturnsCorrectly(int value) {

		int comparisonValue = 2;

		int result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		int value = 1;
		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		int value = 1;
		int? comparisonValue = null;

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int value = 1;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int value = 1;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;
		IComparer<int> comparer = Comparer<int>.Default;

		int result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;
		IComparer<int> comparer = null!;

		int result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void WithNullableValueGreaterThanOrEqualToComparisonValueReturnsCorrectly(int? value) {

		int comparisonValue = 2;

		int? result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int? comparisonValue = null;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		int? value = null;
		int comparisonValue = 2;

		int? result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue );

		Assert.Null( result );
	}


	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
