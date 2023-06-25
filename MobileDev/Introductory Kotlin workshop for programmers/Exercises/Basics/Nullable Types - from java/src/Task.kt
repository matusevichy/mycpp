class MailWrapper(private val mailer:JavaMailer){

    fun receiveMail(): List<Mail> {
        return mailer?.receiveMail() ?: listOf()
    }

}