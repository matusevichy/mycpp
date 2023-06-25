fun Array<Int>.oneMinus(): Array<Int> {
    return map { 1 - it }.toTypedArray()
}

/**
 * Usage example
 */
fun main() {
    val myArray = arrayOf(3, 4, 5)
    val minusArray: Array<Int> = myArray.oneMinus()

    minusArray.forEach { println("* $it") }
}
