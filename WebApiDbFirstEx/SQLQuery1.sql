create database StudentDb
use StudentDb
create table Students
(Id int primary key,
Name nvarchar(50) not null,
Age int not null,
Course nvarchar(50) not null,
Email nvarchar(100) not null,
Contact varchar(10) not null)

insert into Students values (1,'Sam',21,'dot net','sam.dicosta.123@yahoo.co.in','9875641253')
insert into Students values (2,'Mohan',19,'Java','mohan@gmail.com','9975645468')
insert into Students values (3,'Anita',23,'Azure','anita.1997@yahoo.co.in','9175684835')
insert into Students values (4,'Deepak',21,'Sql','deepu_sharma@gmail.com','9589474331')

select * from Students