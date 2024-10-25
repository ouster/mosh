package org.example

class StringReverser {

    fun reverse(input: String): String {
        val stack = ArrayDeque<Char>(input.length)

        input.forEach { stack.addFirst(it) }

        return stack.joinToString("")
    }

}