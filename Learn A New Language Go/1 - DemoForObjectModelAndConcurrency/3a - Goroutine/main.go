package main

import (
	"fmt"
	"time"
)

func main() {
	lazy()
	fmt.Println("A")
}

func lazy() {
	time.Sleep(1 * time.Second)
	fmt.Println("B")
}
