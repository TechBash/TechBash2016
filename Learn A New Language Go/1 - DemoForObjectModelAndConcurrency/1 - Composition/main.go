package main

import "fmt"

func main() {
	o := Outer{}
	o.Value = 42
	o.display()
}

type Inner struct {
	Value int
}

type Outer struct {
	Inner
	AnotherValue int
}

func (i Inner) display() {
	fmt.Println(i.Value)
}
