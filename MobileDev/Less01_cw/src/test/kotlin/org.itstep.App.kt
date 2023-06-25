fun main(){
    println(getFactorial(5))
}

fun getFactorial(num:Int): Int {
    if (num < 1) return 1
    return num * getFactorial(num-1)
}