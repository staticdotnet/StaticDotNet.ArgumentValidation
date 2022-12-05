﻿using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IComparable"/> arguments.
/// </summary>
public static class EquatableExtensions {

	/// <summary>
	/// Ensures an argument is equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparer">The comparer. Null will use <see cref="EqualityComparer{T}.Default"/></param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not equal <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T> EqualTo<T>( in this ArgInfo<T> argInfo, T comparisonValue, IEqualityComparer<T>? comparer = null) {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( comparisonValue is not null && ( comparer ?? EqualityComparer<T>.Default ).Equals( argInfo.Value, comparisonValue ) ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_EQUAL_TO, comparisonValue?.ToString() ?? Constants.NULL ), argInfo.Name );
	}
}
