package main

import (
	"fmt"
	"sync"
	"time"
)

func main() {
	w := sync.WaitGroup{}

	w.Add(1)
	go lazy(&w)

	fmt.Println("A")

	w.Wait()
}

func lazy(w *sync.WaitGroup) {
	time.Sleep(1 * time.Second)
	fmt.Println("B")
	w.Done()
}
