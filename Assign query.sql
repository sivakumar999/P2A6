create database ProductInventoryDb
on primary
(name = ProductDb_data,
filename = 'M:\Simplilearn\mphasis\Phase-2\day-6\Assign6\ProductDb_data.mdf')

use ProductInventoryDb
----------------------------------------

create table Products
(ProductId int primary key,
ProductName nvarchar(50),
Price float,
Quantity int,
MfDate date,
ExpDate date
)


insert into Products values(101, 'Poco', 26000.90, 5, '05-2-2017', '2-02-2024')
insert into Products values(102, 'Kecha', 30000.90, 4, '05-2-2017', '2-12-2024')

--drop table Products
select * from Products