package main

import (
	"fmt"
	"time"
)

func main() {
	c := longTask("hello techbash")

	select {
	case v := <-c:
		fmt.Println(v)
	case <-time.After(1 * time.Second):
		fmt.Println("I'm tired of waiting.")
	}
}

func longTask(s string) <-chan string {
	c := make(chan string)

	go func() {
		time.Sleep(10 * time.Second)
		c <- s
		close(c)
	}()

	return c
}
