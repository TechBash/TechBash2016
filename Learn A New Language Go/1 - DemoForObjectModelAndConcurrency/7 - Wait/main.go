package main

import "fmt"

func main() {
	s1 := counter("Mark")
	s2 := counter("John")

	var s1Complete, s2Complete bool
	for !s1Complete || !s2Complete {
		select {
		case v := <-s1:
			fmt.Println(v)
			s1Complete = true
		case v := <-s2:
			fmt.Println(v)
			s2Complete = true
		}
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
