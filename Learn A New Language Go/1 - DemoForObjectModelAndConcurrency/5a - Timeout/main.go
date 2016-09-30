package main

import (
	"fmt"
	"time"
)

func main() {
	c := longTask("hello techbash")
	fmt.Println(<-c)
}

func longTask(s string) <-chan string {
	c := make(chan string)

	go func() {
		time.Sleep(10 * time.Second)
		c <- s
	}()

	return c
}
