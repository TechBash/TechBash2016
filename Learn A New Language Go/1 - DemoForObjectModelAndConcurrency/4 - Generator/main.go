package main

import "fmt"

func main() {
	c := counter("hello techbash")
	for i := 0; i < 5; i++ {
		fmt.Println(<-c)
	}
}

func counter(s string) <-chan string {
	c := make(chan string)
	go func() {
		for i := 1; ; i++ {
			c <- fmt.Sprintf("%s %d", s, i)
		}
	}()
	return c
}
