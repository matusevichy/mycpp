class Transport<T:Animal>(var goods: T)

interface Animal
class Dog:Animal
class Cat:Animal

//implement the catTransporter() function
fun catTransporter(): Transport<Cat> = Transport(Cat())

fun main() {
}
