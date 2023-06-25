fun handleImmutableMap(messages: Map<String,Int>): Map<String,Int> {
    return handleMutableMap(messages.toMutableMap())
}

fun handleMutableMap(messages: MutableMap<String,Int>): Map<String,Int> {
    if(messages.contains("x"))messages["x"] = 345
    messages.remove("z")
    return messages
}

/**
 * A main function to play with
 */
fun main(args: Array<String>) {
    println(handleImmutableMap(mapOf("m" to 123)))
}