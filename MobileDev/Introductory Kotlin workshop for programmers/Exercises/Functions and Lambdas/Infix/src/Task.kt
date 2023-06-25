class MyNum (val classVal: Int){
    infix fun add(prm:Int) = classVal + prm
}


/**
 * Main method to play with
 */
fun main(args: Array<String>) {
     val someNumber = MyNum(4345)
     println( someNumber add 4 )
}