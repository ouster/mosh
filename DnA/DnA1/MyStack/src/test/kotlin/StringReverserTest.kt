import org.example.StringReverser
import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class StringReverserTest {

    @Test
    fun `test reverse string`() {
        val reversed = StringReverser().reverse("hello")
        assertEquals("olleh", reversed)
    }

    @Test
    fun `test empty string`() {
        val reversed = StringReverser().reverse("")
        assertEquals("", reversed)
    }
}