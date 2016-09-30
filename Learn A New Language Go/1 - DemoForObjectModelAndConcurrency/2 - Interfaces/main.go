package main

import "fmt"

func main() {
	rect := Rectangle{Width: 2, Height: 3}
	display(rect)
}

type Rectangle struct {
	Width  int
	Height int
}

func (r Rectangle) String() string {
	return fmt.Sprintf("%dx%d Rectangle", r.Width, r.Height)
}

func display(s fmt.Stringer) {
	fmt.Println(s.String())
}
