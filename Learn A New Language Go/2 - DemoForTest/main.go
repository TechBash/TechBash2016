package main

import (
	"fmt"
)

func main() {
	fmt.Println(StringJoin("a", "b"))
}

func StringJoin(s ...string) string {
	var joined string
	for _, v := range s {
		joined += v
	}
	return joined
}
