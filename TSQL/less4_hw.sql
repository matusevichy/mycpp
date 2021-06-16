use Northwind

select e.FirstName+' '+e.LastName as FIO, c.CompanyName, sum(o.Freight) from orders o
join Employees e
on o.EmployeeID=e.EmployeeID
join Customers c on
o.CustomerID=c.CustomerID
group by rollup(e.FirstName+' '+e.LastName, c.CompanyName)

select e.FirstName+' '+e.LastName as FIO, c.CompanyName, sum(o.Freight) from orders o
join Employees e
on o.EmployeeID=e.EmployeeID
join Customers c on
o.CustomerID=c.CustomerID
group by cube(e.FirstName+' '+e.LastName, c.CompanyName)

select e.FirstName+' '+e.LastName as FIO, c.CompanyName, sum(o.Freight) from orders o
join Employees e
on o.EmployeeID=e.EmployeeID
join Customers c on
o.CustomerID=c.CustomerID
group by grouping sets ((e.FirstName+' '+e.LastName, c.CompanyName), e.FirstName+' '+e.LastName)

select 'SumBy', [Alfreds Futterkiste], [Ana Trujillo Emparedados y helados], [Ernst Handel] 
from (select  c.CompanyName, o.Freight from orders o
join Customers c on
o.CustomerID=c.CustomerID) as CompanyOrders
pivot
(sum(Freight) for CompanyName in ([Alfreds Futterkiste], [Ana Trujillo Emparedados y helados], [Ernst Handel])) as SumTable

