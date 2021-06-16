use Northwind;

--вывести количество инструкторов по каждой секции
select Country, COUNT(companyName) from Suppliers group by Country order by Country

--показать количество людей, которые должны заниматься в определенный момент времени в каждой секции;
select ShipCity, count(EmployeeID) from Orders where year(ShippedDate)=1996 group by ShipCity 

--вывести количество посетителей фитнес клуба, которые пользуются услугами определенного мобильного оператора;
select count(EmployeeID) from Employees where HomePhone LIKE '%(206)%'

--получить количество посетителей, у которых фамилия совпадает с фамилиями из определенного списка;
select count(EmployeeID) from Employees where LastName in ('Buchanan','Davolio','Leverling','King')

--показать количество людей с одинаковыми именами, которых занимаются у определенного инструктора;
select LastName, count(ShipCountry) from Orders o, Employees e where o.EmployeeID=e.EmployeeID and ShipCountry='USA' group by LastName

--получить информацию о людях, которые посетили фитнес зал минимальное количество раз;
select LastName, FirstName, count(ShipCountry) from Orders o, Employees e where o.EmployeeID=e.EmployeeID group by LastName, FirstName having count(ShipCountry)=
(select min(CountCountry) from (select LastName, count(ShipCountry) as CountCountry from Orders o, Employees e where o.EmployeeID=e.EmployeeID group by LastName) tmp) 

--вывести количество посетителей, которые занимались в определенной секции за первую половину текущего года;
select count(*) from Orders where ShippedDate>='1997-01-01' and ShippedDate<'1997-01-07' and ShipName='Ernst Handel'

--определить общее количество людей, посетивших фитнес зал за прошлый год.
select count(*) from Orders where year(ShippedDate)=1996 
