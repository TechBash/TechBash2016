package main

import (
	"bytes"
	"fmt"
)

func main() {
	fmt.Println(StringJoinConcat("a", "b"))
	fmt.Println(StringJoinBuffer("a", "b"))
	fmt.Println(StringJoinAppend("a", "b"))
}

func StringJoinConcat(s ...string) string {
	var joined string
	for _, v := range s {
		joined += v
	}
	return joined
}

func StringJoinBuffer(s ...string) string {
	var joined bytes.Buffer
	for _, v := range s {
		joined.WriteString(v)
	}
	return joined.String()
}

func StringJoinAppend(s ...string) string {
	var joined []byte
	for _, v := range s {
		joined = append(joined, v...)
	}
	return string(joined)
}
