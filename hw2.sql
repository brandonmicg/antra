--Brandon Girard - Assignment 2 SQL

/*
1. Write a query that lists the country and province names from Person.CountryRegion and Person.StateProvince tables. Join them and produce a result set similar to the
following.
Country                        Province
*/
select cr.Name Country, sp.Name Province
from Person.CountryRegion cr join Person.StateProvince sp on cr.CountryRegionCode = sp.CountryRegionCode 

/*
2. Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables and list the countries filter them by Germany and Canada.
Join them and produce a result set similar to the following.
Country                        Province
*/
select cr.Name Country, sp.Name Province
from Person.CountryRegion cr join Person.StateProvince sp on cr.CountryRegionCode = sp.CountryRegionCode 
where cr.Name in ('Germany','Canada')

--Using Northwind Database: (Use aliases for all the Joins)
--3. List all Products that has been sold at least once in last 25 years.
select distinct p.ProductName
from Products p join [Order Details] od on p.ProductID = od.ProductID
where od.OrderID in (
select OrderId
from Orders
where year(getdate()) - year(ShippedDate) <= 25
)

--4. List top 5 locations (Zip Code) where the products sold most in last 25 years.
select top 5 ShipPostalCode, count(ShipPostalCode) cnt
from Orders
where year(getdate()) - year(ShippedDate) <= 25
group by ShipPostalCode
order by cnt desc

--5. List all city names and number of customers in that city.     
select City, COUNT(City) CustomerCount
from Customers
group by City


--6. List city names which have more than 2 customers, and number of customers in that city
select City, COUNT(City) CustomerCount
from Customers
group by City
having COUNT(City) > 2



--7. Display the names of all customers  along with the  count of products they bought
select c.ContactName, sum(od.Quantity) [# Products Bought]
from Customers c join Orders o on c.CustomerID = o.CustomerID join [Order Details] od on o.OrderID = od.OrderID
group by c.ContactName

--8. Display the customer ids who bought more than 100 Products with count of products.
select c.ContactName, sum(od.Quantity) [# Products Bought]
from Customers c join Orders o on c.CustomerID = o.CustomerID join [Order Details] od on o.OrderID = od.OrderID
group by c.ContactName
having sum(od.Quantity) > 100


/*
9. List all of the possible ways that suppliers can ship their products. Display the results as below
Supplier Company Name                Shipping Company Name
 ---------------------------------            ----------------------------------
*/
select distinct s.CompanyName [Supplier Company Name], sh.CompanyName [Shipping Company Name]
from Suppliers s
join Products p on s.SupplierID = p.SupplierID
join [Order Details] od on p.ProductID = od.ProductID 
join Orders o on od.OrderID = o.OrderID
join Shippers sh on sh.ShipperID = o.ShipVia
order by [Supplier Company Name]

--10. Display the products order each day. Show Order date and Product Name.
select o.OrderDate, p.ProductName
from Orders o
join [Order Details] od on o.OrderID = od.OrderID
join Products p on p.ProductID = od.ProductID


--11. Displays pairs of employees who have the same job title.
select e1.FirstName + ' ' + e1.LastName [Employee 1], e2.FirstName + ' ' + e2.LastName [Employee 2], e1.Title
from Employees e1
join Employees e2 on e1.Title = e2.Title and e1.EmployeeID != e2.EmployeeID

--12. Display all the Managers who have more than 2 employees reporting to them.
select * 
from Employees 
where Title = 'Sales Manager' and (select count(EmployeeID) from Employees where ReportsTo = 5) > 2

/*
13. Display the customers and suppliers by city. The results should have the following columns
City
Name
Contact Name,
Type (Customer or Supplier)

All scenarios are based on Database NORTHWIND.
*/
select City, ContactName, 'Customer' Type
from Customers
union
select City, ContactName, 'Supplier' Type
from Suppliers

--14. List all cities that have both Employees and Customers.
select distinct City
from Customers
where City in (select City from Employees)

--15. List all cities that have Customers but no Employee.
--a. Use sub-query
select distinct City
from Customers
where City not in (select City from Employees)

--b. Do not use sub-query
select distinct c.City
from Customers c
join Employees e on c.City != e.City

--16. List all products and their total order quantities throughout all orders.
select o.OrderID, p.ProductName, od.Quantity
from Orders o
join [Order Details] od on o.OrderID = od.OrderID
join Products p on p.ProductID = od.ProductID

--17. List all Customer Cities that have at least two customers.
--a. Use union
select sub.City
from (
	select City, Count(CustomerID) over (partition by City) as dup
	from Customers
	union
	select City, 1
	from Customers
	) as sub
where sub.dup >= 2

--b. Use sub-query and no union
select sub.c
from (
select City c, count(City) cnt
from Customers 
group by City 
having count(City) >= 2
) as sub


--18. List all Customer Cities that have ordered at least two different kinds of products.
select sc
from (
select distinct o.ShipCity sc, count(od.ProductID) cnt
from [Order Details] od
join Orders o on o.OrderID = od.OrderID
group by o.ShipCity
having count(od.ProductID) >= 2
) as sub

--19. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

select top 5 topProduct.pname [Product Name], topProduct.avgPrice,
[Most City Quantity] = (
	select top 1 oqty.ShipCity
	from (
		select o.ShipCity, od.ProductID, sum(Quantity) qty
		from [Order Details] od
		join Orders o on od.OrderID = o.OrderID
		group by o.ShipCity, od.ProductID
	) oqty
	where topProduct.pid = oqty.ProductID
	order by oqty.qty desc
)
from (
	select p.ProductName pname, p.ProductID pid, count(od.ProductID) amount, avg(od.UnitPrice) avgPrice
	from [Order Details] od
	join Products p on p.ProductID = od.ProductID
	group by p.ProductName, p.ProductID
) as topProduct
order by topProduct.amount desc


/*
20. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered
from. (tip: join  sub-query)
*/
select empSold.[Employee City] [Most Order Quantity City]
from (
	select top 1 e.City [Employee City], count(o.OrderID) qty
	from Employees e
	join Orders o on e.EmployeeID = o.EmployeeID
	group by e.EmployeeID, e.City
	order by count(o.OrderID) desc
) as empSold
where empSold.[Employee City] in (
	select orderQty.[Order City] [Most Quantity City] 
	from (
		select top 1 o.ShipCity [Order City], sum(od.Quantity) qty
		from Orders o
		join [Order Details] od on od.OrderID = o.OrderID
		group by o.ShipCity
		order by sum(od.Quantity) desc
	) as orderQty
)

--21. How do you remove the duplicates record of a table?
--use distinct keyword