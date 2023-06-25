class Person( val personalInfo: PersonalInfo? )

class PersonalInfo( val data: String? )

interface Mailer {
    fun sendMessage(content: String)
}

fun sendMessageToClient(
        person: Person?, mailer: Mailer
){
    //this is an example of how NOT to do it in Kotlin

	val personalData = person?.personalInfo?.data
	personalData?.let {mailer.sendMessage(personalData)}
}


