package main

import "fmt"

func main() {
	o := counter("odds")
	e := counter("ends")

	for i := 0; i < 5; i++ {
		fmt.Println(<-o)
		fmt.Println(<-e)
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
