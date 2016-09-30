package main

import (
	"fmt"
	"sync"
)

func main() {
	q := make(chan interface{})
	m := merge(counter("odds", q), counter("ends", q))

	// Signal the quit channel after keypress
	go func() {
		fmt.Scanln()
		close(q)
	}()

	// Display messages until the merged channel is closed
	for v := range m {
		fmt.Println(v)
	}
}

func counter(s string, q <-chan interface{}) <-chan string {
	c := make(chan string)
	go func() {
		for i := 1; ; i++ {
			select {
			case c <- fmt.Sprintf("%s %d", s, i):
			case <-q:
				close(c)
				return
			}
		}
	}()
	return c
}

func merge(chans ...<-chan string) <-chan string {
	var wg sync.WaitGroup
	out := make(chan string)

	// Read all messages from the channel
	mergeReceiver := func(c <-chan string) {
		for v := range c {
			out <- v
		}
		wg.Done()
	}

	// Kick-off one merge receiver for each channel
	wg.Add(len(chans))
	for _, c := range chans {
		go mergeReceiver(c)
	}

	// Close this channel when all other channels are closed
	go func() {
		wg.Wait()
		close(out)
	}()

	return out
}
