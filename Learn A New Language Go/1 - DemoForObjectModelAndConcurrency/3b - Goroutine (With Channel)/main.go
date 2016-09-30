package main

import (
	"fmt"
	"time"
)

func main() {
	w := make(chan bool)
	go lazy(w)
	fmt.Println("A")
	<-w
}

func lazy(w chan<- bool) {
	time.Sleep(1 * time.Second)
	fmt.Println("B")
	w <- true
}
