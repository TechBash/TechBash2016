package main

import "testing"

func BenchmarkConcat(b *testing.B) {
	for n := 0; n < b.N; n++ {
		StringJoinConcat("hello", "world", "this", "is", "a", "test")
	}
}

func BenchmarkBuffer(b *testing.B) {
	for n := 0; n < b.N; n++ {
		StringJoinBuffer("hello", "world", "this", "is", "a", "test")
	}
}

func BenchmarkAppend(b *testing.B) {
	for n := 0; n < b.N; n++ {
		StringJoinAppend("hello", "world", "this", "is", "a", "test")
	}
}
