﻿using Ardalis.GuardClauses;
using Dawn;
using JetBrains.Annotations;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class GreaterThanStructBenchmarks {

	public int value = 2;
	public int comparisonValue = 0;

	[Benchmark( Baseline = true )]
	public int Baseline() => this.value > this.comparisonValue ? this.value : throw new ArgumentException( string.Format( CultureInfo.InvariantCulture, "Value must be greater than {0}.", this.comparisonValue ), nameof( this.value ) );

	[Benchmark]
	public int Argument_Is() => Argument.Is.GreaterThan( this.value, this.comparisonValue );

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( this.value ).GreaterThan( this.comparisonValue );

	[Benchmark]
	public int Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.Negative( this.value );
}