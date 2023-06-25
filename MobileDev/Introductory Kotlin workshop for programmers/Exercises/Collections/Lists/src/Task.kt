fun handleImmutableList(messages: List<String>): List<String> {

    return handleMutableList(messages.toMutableList())
}

fun handleMutableList(messages: MutableList<String>): List<String> {
    if (messages.size < 2) return messages
    if (messages.size > 2) messages[2] = "d"
    messages.removeAt(1)
    return messages
}

/**
 * A main function to play with
 */
fun main(args: Array<String>) {
    println(handleImmutableList(listOf("x")))
}