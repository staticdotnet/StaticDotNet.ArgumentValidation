﻿using System.Globalization;
using System.Linq;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating and converting string <see cref="string"/> arguments.
/// </summary>
public static class StringParsingExtensions {

#if NET7_0_OR_GREATER

	/// <summary>
	/// Ensures an argument is parsable to a <typeparamref name="T"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <returns>A new <typeparamref name="T"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <typeparamref name="T"/>.</exception>
	public static ArgInfo<T> Parse<T>( in ArgInfo<string> argInfo, IFormatProvider? provider = null )
		where T : IParsable<T> {

		if( T.TryParse( argInfo.Value, provider, out T? result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( T ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="bool"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>A new <see cref="bool"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="bool"/>.</exception>
	public static ArgInfo<bool> ParseBoolean( in this ArgInfo<string> argInfo ) {

		if( bool.TryParse( argInfo.Value, out bool result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( bool ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="Guid"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>A new <see cref="Guid"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="Guid"/>.</exception>
	public static ArgInfo<Guid> ParseGuid( in ArgInfo<string> argInfo ) {

		if( Guid.TryParse( argInfo.Value, out Guid result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( Guid ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="Guid"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	///  <param name="format">The guid format.</param>
	/// <returns>A new <see cref="Guid"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="Guid"/>.</exception>
	public static ArgInfo<Guid> ParseGuidExact( in ArgInfo<string> argInfo, string? format ) {

		if( Guid.TryParseExact( argInfo.Value, format, out Guid result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( Guid ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="byte"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="styles">The <see cref="NumberStyles"/> to use.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <returns>A new <see cref="byte"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="byte"/>.</exception>
	public static ArgInfo<byte> ParseByte( in this ArgInfo<string> argInfo, NumberStyles styles = NumberStyles.None, IFormatProvider? provider = null ) {

		if( byte.TryParse( argInfo.Value, styles, provider, out byte result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( byte ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="short"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="styles">The <see cref="NumberStyles"/> to use.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <returns>A new <see cref="short"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="short"/>.</exception>
	public static ArgInfo<short> ParseInt16( in this ArgInfo<string> argInfo, NumberStyles styles = NumberStyles.None, IFormatProvider? provider = null ) {

		if( short.TryParse( argInfo.Value, styles, provider, out short result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( short ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="int"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="styles">The <see cref="NumberStyles"/> to use.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <returns>A new <see cref="int"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="int"/>.</exception>
	public static ArgInfo<int> ParseInt32( in this ArgInfo<string> argInfo, NumberStyles styles = NumberStyles.None, IFormatProvider? provider = null ) {

		if( int.TryParse( argInfo.Value, styles, provider, out int result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( int ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="long"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="styles">The <see cref="NumberStyles"/> to use.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <returns>A new <see cref="long"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="long"/>.</exception>
	public static ArgInfo<long> ParseInt64( in this ArgInfo<string> argInfo, NumberStyles styles = NumberStyles.None, IFormatProvider? provider = null ) {

		if( long.TryParse( argInfo.Value, styles, provider, out long result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( long ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="TimeSpan"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <returns>A new <see cref="TimeSpan"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="TimeSpan"/>.</exception>
	public static ArgInfo<TimeSpan> ParseTimeSpan( in this ArgInfo<string> argInfo, IFormatProvider? provider = null ) {

		if( TimeSpan.TryParse( argInfo.Value, provider, out TimeSpan result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( TimeSpan ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="TimeSpan"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	///  <param name="formats">The time span format.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="TimeSpanStyles"/> to use.</param>
	/// <returns>A new <see cref="TimeSpan"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="TimeSpan"/>.</exception>
	public static ArgInfo<TimeSpan> ParseTimeSpanExact( in this ArgInfo<string> argInfo, string formats, IFormatProvider? provider = null, TimeSpanStyles styles = TimeSpanStyles.None ) {

		if( TimeSpan.TryParseExact( argInfo.Value, formats, provider, styles, out TimeSpan result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( TimeSpan ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="TimeSpan"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	///  <param name="formats">The time span formats.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="TimeSpanStyles"/> to use.</param>
	/// <returns>A new <see cref="TimeSpan"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="TimeSpan"/>.</exception>
	public static ArgInfo<TimeSpan> ParseTimeSpanExact( in this ArgInfo<string> argInfo, string?[]? formats, IFormatProvider? provider = null, TimeSpanStyles styles = TimeSpanStyles.None ) {

		if( TimeSpan.TryParseExact( argInfo.Value, formats, provider, styles, out TimeSpan result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( TimeSpan ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="DateTime"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="DateTime"/>.</exception>
	public static ArgInfo<DateTime> ParseDateTime( in this ArgInfo<string> argInfo, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTime.TryParse( argInfo.Value, provider, styles, out DateTime result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( DateTime ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="DateTime"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="format">The date time format.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="DateTime"/>.</exception>
	public static ArgInfo<DateTime> ParseDateTimeExact( in this ArgInfo<string> argInfo, string? format, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTime.TryParseExact( argInfo.Value, format, provider, styles, out DateTime result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( DateTime ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="DateTime"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="formats">The date time formats.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="DateTime"/>.</exception>
	public static ArgInfo<DateTime> ParseDateTimeExact( in this ArgInfo<string> argInfo, string?[]? formats, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTime.TryParseExact( argInfo.Value, formats, provider, styles, out DateTime result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( DateTime ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="DateTimeOffset"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTimeOffset"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="DateTimeOffset"/>.</exception>
	public static ArgInfo<DateTimeOffset> ParseDateTimeOffset( in this ArgInfo<string> argInfo, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTimeOffset.TryParse( argInfo.Value, provider, styles, out DateTimeOffset result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( DateTimeOffset ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="DateTimeOffset"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="format">The date time offset format.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTimeOffset"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="DateTimeOffset"/>.</exception>
	public static ArgInfo<DateTimeOffset> ParseDateTimeOffsetExact( in this ArgInfo<string> argInfo, string? format, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTimeOffset.TryParseExact( argInfo.Value, format, provider, styles, out DateTimeOffset result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( DateTimeOffset ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="DateTimeOffset"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="formats">The date time offset formats.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTimeOffset"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="DateTimeOffset"/>.</exception>
	public static ArgInfo<DateTimeOffset> ParseDateTimeOffsetExact( in this ArgInfo<string> argInfo, string?[]? formats, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTimeOffset.TryParseExact( argInfo.Value, formats, provider, styles, out DateTimeOffset result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( DateTimeOffset ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

#if NET6_0_OR_GREATER

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="DateOnly"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateOnly"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="DateOnly"/>.</exception>
	public static ArgInfo<DateOnly> ParseDateOnly( in this ArgInfo<string> argInfo, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateOnly.TryParse( argInfo.Value, provider, styles, out DateOnly result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( DateOnly ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="DateOnly"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="format">The date format.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateOnly"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="DateOnly"/>.</exception>
	public static ArgInfo<DateOnly> ParseDateOnlyExact( in this ArgInfo<string> argInfo, string? format, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateOnly.TryParseExact( argInfo.Value, format, provider, styles, out DateOnly result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( DateOnly ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="DateOnly"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="formats">The date formats.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateOnly"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="DateOnly"/>.</exception>
	public static ArgInfo<DateOnly> ParseDateOnlyExact( in this ArgInfo<string> argInfo, string?[]? formats, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateOnly.TryParseExact( argInfo.Value, formats, provider, styles, out DateOnly result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( DateOnly ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="TimeOnly"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="TimeOnly"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="TimeOnly"/>.</exception>
	public static ArgInfo<TimeOnly> ParseTimeOnly( in this ArgInfo<string> argInfo, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( TimeOnly.TryParse( argInfo.Value, provider, styles, out TimeOnly result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( TimeOnly ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="TimeOnly"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="format">The time format.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="TimeOnly"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="TimeOnly"/>.</exception>
	public static ArgInfo<TimeOnly> ParseTimeOnlyExact( in this ArgInfo<string> argInfo, string? format, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( TimeOnly.TryParseExact( argInfo.Value, format, provider, styles, out TimeOnly result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( TimeOnly ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="TimeOnly"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="formats">The time formats.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="TimeOnly"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="TimeOnly"/>.</exception>
	public static ArgInfo<TimeOnly> ParseTimeOnlyExact( in this ArgInfo<string> argInfo, string?[]? formats, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( TimeOnly.TryParseExact( argInfo.Value, formats, provider, styles, out TimeOnly result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( TimeOnly ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="Type"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>A new <see cref="Type"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="Type"/>.</exception>
	[RequiresUnreferencedCode( "The type might be removed." )]
	public static ArgInfo<Type> ParseType( in this ArgInfo<string> argInfo ) {

		Exception? thrownException = null;
		if( argInfo.Value is not null ) {
			Type? type;
#pragma warning disable CA1031 // Intentionally not catching specific exceptions as it is included as an inner exception.
			try {
				type = Type.GetType( argInfo.Value, true );

				// Nullabiliy ignored as per the Type.GetType documentation, throwOnError true will always throw an exception if the type isn't found.
				return new( type!, argInfo.Name, argInfo.Message );
			} catch( Exception exception ) {
				thrownException = exception;
			}
#pragma warning restore CA1031
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( Type ).FullName );

		if( thrownException is not null ) {

			message += $" {Constants.SEE_INNER_EXCEPTION_FOR_DETAILS}";
		}

		throw new ArgumentException( message, argInfo.Name, thrownException );
	}

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="Uri"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="uriKind">The <see cref="UriKind"/>.</param>
	/// <returns>A new <see cref="Uri"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a  <see cref="Uri"/>.</exception>
	public static ArgInfo<Uri> ParseUri( in this ArgInfo<string> argInfo, UriKind uriKind ) {

		if( Uri.TryCreate( argInfo.Value, uriKind, out Uri? result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( Uri ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

#if NET6_0_OR_GREATER

	/// <summary>
	/// Ensures an argument is parsable to a <see cref="Uri"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="creationOptions">The <see cref="UriCreationOptions"/>.</param>
	/// <returns>A new <see cref="Uri"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <see cref="Uri"/>.</exception>
	public static ArgInfo<Uri> ParseUri( in this ArgInfo<string> argInfo, UriCreationOptions creationOptions ) {

		if( Uri.TryCreate( argInfo.Value, creationOptions, out Uri? result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( Uri ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif
}