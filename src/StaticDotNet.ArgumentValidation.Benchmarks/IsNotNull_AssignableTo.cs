﻿using Ardalis.GuardClauses;
using BenchmarkDotNet.Order;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
[SimpleJob( RuntimeMoniker.NetCoreApp31 )]
public class IsNotNull_AssignableTo {

	public Type? argumentValue = typeof( int[] );
	public Type value = typeof( IList<int> );

	[Benchmark( Baseline = true )]
	public Type Baseline() {

#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull( argumentValue );
#else
		if( argumentValue == null ) {
			throw new ArgumentNullException( nameof( argumentValue ) );
		}
#endif

		return value.IsAssignableFrom( argumentValue ) ? value : throw new ArgumentException( nameof( value ) );
	}

	[Benchmark]
	public Type ArgumentValidation() => Arg.IsNotNull( argumentValue ).AssignableTo( value ).Value;
}