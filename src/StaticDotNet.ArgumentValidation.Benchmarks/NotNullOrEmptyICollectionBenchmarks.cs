﻿using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;
using System.Collections.ObjectModel;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrEmptyICollectionBenchmarks {

	public Collection<string> value = new Collection<string>() { "Value" };

	[Benchmark( Baseline = true )]
	public ICollection<string> Baseline()
		=> this.value == null
			? throw new ArgumentNullException( nameof( this.value ) )
			: this.value.Count == 0 ? throw new ArgumentException( "Message", nameof( this.value ) ) : this.value;

	//[Benchmark]
	//public Collection<string> Arg_Is() => Arg.Is.NotNullOrEmpty( this.value );

	[Benchmark]
	public Collection<string> Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotEmpty().Value;

	[Benchmark]
	public Collection<string> Ardalis_Guard() => ( Collection<string> )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( this.value );

	[Benchmark]
	public Collection<string> Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNull();
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).HasItems();

		return this.value;
	}
}