package main

import (
	"fmt"
	"math/rand"
	"sync"
	"time"
)

func main() {
	d := ticketDispenser{next: 20}
	x := make(chan *ticketDispenser)
	w := sync.WaitGroup{}

	for i := 0; i < 5; i++ {
		w.Add(1)
		go func() {
			customerWaiting(x)
			w.Done()
		}()
	}

	for i := 0; i < 5; i++ {
		x <- &d
	}

	w.Wait()
}

type ticketDispenser struct {
	next int
}

func (x *ticketDispenser) takeTicket() int {
	t := x.next
	time.Sleep(time.Duration(rand.Intn(3)) * time.Nanosecond)
	x.next++
	return t
}

func customerWaiting(d <-chan *ticketDispenser) {
	t := (<-d).takeTicket()
	fmt.Printf("I have ticket %d\n", t)
}