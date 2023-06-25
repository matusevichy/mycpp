fun add(vararg numbers:Int):Int{
 return numbers.filter { it % 2 == 0 }.sum()
}

/**
 * main method to play with
 */
fun main(args: Array<String>) {
    //println( add(1,2,3,4) )
}
