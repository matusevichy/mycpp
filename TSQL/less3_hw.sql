use Hospital;

create index i_Doctors_lastname on Doctors(lastname)
go

create index i_Departments_departmentname on Departments(departmentname)
go

create index i_Patients_phone on Patients(phone)
go

use Airport;

create index i_flights_number on flights(number)
go

create index i_flights_datefrom on flights(datefrom)
go

create index i_tickets_datepay on tickets(datepay)
go