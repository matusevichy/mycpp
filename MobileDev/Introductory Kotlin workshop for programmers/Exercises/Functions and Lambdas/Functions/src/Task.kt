fun add(vararg arr: Int): Int {
    return arr.filter { it % 2 == 0 }.sum()
}

/**
 * main method to play with
 */
fun main() {
    println( add(1,2,3,4) )
}
