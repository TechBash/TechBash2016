package main

import "testing"

func Test_StringJoin_OneString(t *testing.T) {
	if !t.Short {
		var r = StringJoin("a")
		if r != "a" {
			t.Error("Expected 'a', got ", r)
		}
	}
}

func Test_StringJoin_TwoStrings(t *testing.T) {
	var r = StringJoin("a", "b")
	if r != "ab" {
		t.Error("Expected 'ab', got ", r)
	}
}

func Test_StringJoin_NoString(t *testing.T) {
	var r = StringJoin()
	if r != "" {
		t.Error("Expected '', got ", r)
	}
}
