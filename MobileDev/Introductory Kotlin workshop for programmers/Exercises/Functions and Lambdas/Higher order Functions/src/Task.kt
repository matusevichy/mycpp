import java.sql.Time
import java.time.LocalDateTime
import java.time.ZoneOffset

object Stopwatch {

    /**
     * Measures execution time in ms of a given callback
     *
     *  @param block the function to measure
     *  @return time elapsed = end time - start time
     *
     */
    fun elapse (block: () -> Unit): Long {
        var startTime = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC)
        block()
        var endTime = LocalDateTime.now().toEpochSecond(ZoneOffset.UTC)
        return endTime - startTime
    }
}

fun main() {

    val init: (Int) -> Int = { i -> i * i }
    val numbers = Array(100000, init)

    Stopwatch.elapse { numbers.forEach { i -> println(i) } }
}
