--Brandon Girard Assignment 3 SQL

/*
Use Northwind database. 
All questions are based on assumptions described by the Database Diagram sent to you yesterday. 
When inserting, make up info if necessary. 
Write query for each step. 
Do not use IDE. 
BE CAREFUL WHEN DELETING DATA OR DROPPING TABLE.
*/

--1. Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.
create view view_product_order_girard as
select p.ProductName, sum(od.Quantity) totalOrderedQty
from [Order Details] od
join Products p on od.ProductID = p.ProductID
group by p.ProductName

--2. Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities of order as output parameter.
create proc sp_product_order_quantity_girard
	@productId int,
	@totalOrderQty int out
as
begin
	select @totalOrderQty = sum(od.Quantity)
	from [Order Details] od
	join Products p on od.ProductID = p.ProductID
	where p.ProductID = @productId
end

begin
declare @orderQty int
exec sp_product_order_quantity_girard 1, @orderQty out
print @orderQty
end

/*
3. Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities that ordered most that product combined with 
the total quantity of that product ordered from that city as output.
*/
create proc sp_product_order_city_girard
	@productName varchar(20)
as
begin
	select top 5 topCities.city
	from (
		select o.ShipCity city, sum(od.Quantity) totalOrderedQty
		from [Order Details] od
		join Products p on od.ProductID = p.ProductID
		join Orders o on od.OrderID = o.OrderID
		where p.ProductName = @productName
		group by o.ShipCity
		) as topCities
	order by topCities.totalOrderedQty desc
end

exec sp_product_order_city_girard 'chai'

/*
4. 
Create 2 new tables “people_your_last_name” “city_your_last_name”. 
City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 
Remove city of Seattle. 
If there was anyone from Seattle, put them into a new city “Madison”. 
Create a view “Packers_your_name” lists all people from Green Bay. 
If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.
*/
create table people_girard(Id int, Name varchar(20), CityId int)
create table city_girard(Id int, City varchar(20))

insert into city_girard values(1, 'Seattle')
insert into city_girard values(2, 'Green Bay')

insert into people_girard values(1, 'Aaron Rodgers', 2)
insert into people_girard values(2, 'Russell Wilson', 1)
insert into people_girard values(3, 'Jody Nelson', 2)

delete from city_girard where City = 'Seattle'
insert into city_girard values(1, 'Madison')

create view Packers_brandon as
select p.Name
from people_girard p
join city_girard c on p.CityId = c.Id
where c.City = 'Green Bay'

drop table people_girard
drop table city_girard
drop view Packers_brandon

/*
5. Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb. 
(Make a screen shot) drop the table. Employee table should not be affected.
*/
create proc sp_birthday_employees_girard
as
begin
create table birthday_employees_girard(EmployeeName varchar(30))
insert into birthday_employees_girard
select FirstName + ' ' + LastName
from Employees
where MONTH(BirthDate) = 2
end

exec sp_birthday_employees_girard

drop table birthday_employees_girard
drop proc sp_birthday_employees_girard

--6. How do you make sure two tables have the same data?
-- use union keyword