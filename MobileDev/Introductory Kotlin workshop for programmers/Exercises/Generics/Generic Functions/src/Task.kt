
class Cat
class Dog

fun <T> isAPet(subject: T):Boolean{
    when(subject){
        is Cat, is Dog -> return true
        else -> return false
    }
}