﻿#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="ReadOnlySpan{T}"/> arguments.
/// </summary>
public static class SpanExtensions {

	/// <summary>
	/// Ensures an argument is not white space, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is white space.</exception>
	public static ref readonly SpanArgInfo<char> NotWhiteSpace( in this SpanArgInfo<char> argInfo ) {

		for( int i = 0; i < argInfo.Value.Length; i++ ) {
			if( !char.IsWhiteSpace( argInfo.Value[ i ] ) ) {
				return ref argInfo;
			}
		}

		throw new ArgumentException( argInfo.Message ?? Constants.VALUE_CANNOT_BE_WHITE_SPACE, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is not empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
	public static ref readonly SpanArgInfo<char> NotEmpty( in this SpanArgInfo<char> argInfo ) {

		if( argInfo.Value.Length > 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_CANNOT_BE_EMPTY;
		throw new ArgumentException( message, argInfo.Name );
	}
}

#endif