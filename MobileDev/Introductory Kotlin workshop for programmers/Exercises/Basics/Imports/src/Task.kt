import domain.internal.Customer
import domain.external.Customer as ExternalCustomer

open class CustomerMapper {

    fun mapToInternalCustomer(externalCustomer: ExternalCustomer) =
        Customer(externalCustomer.name, externalCustomer.id)


}

fun main(){}