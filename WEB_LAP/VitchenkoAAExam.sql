create database VitchenkoAA;
Go
Use VitchenkoAA;
Go
create table Products
(ID int not null primary key,
Code_Product varchar(16) null,
Title varchar(50) null,
Quentity int null,
Additional varchar(200) null,
Coast varchar(50) null,
Image varbinary(MAX) null
);

INSERT INTO Products (ID, Code_Product, Title, Quentity, Additional, Coast) VALUES
(1, '200', 'Washing gel', 350, 'Effective', '1000 rub'),
(2, '300', 'Washing powder', 540, 'Effective', '800 rub');

create table Sales
(ID int not null,
Name varchar(50) null,
Surname varchar(50) null,
Passport varchar(50) null,
Date_of_sale varchar(50) null,
Product_code varchar(20) null,
Quentity_pr varchar(300) null,
constraint primary_key_for_Sales primary key (ID)
);
INSERT INTO Sales (ID, Name, Surname, Passport, Date_of_sale, Product_code, Quentity_pr) VALUES
(1, 'Arsentiy', 'Vitchenko', '123432 5674', '11/23/2023', '25', '5'),
(2, 'Alexander', 'Zelenkov', '123432 5674', '11/23/2023', '99', '2');

create table Returns
(
ID int not null,
Name varchar(50) null,
Surname varchar(50) null,
Passport varchar(50) null,
Return_date varchar(50) null,
Product_code varchar(20) null,
Quentity_pr varchar(300) null,
constraint primary_key_for_Returns primary key (ID)
);

INSERT INTO Returns (ID, Name, Surname, Passport, Return_date, Product_code, Quentity_pr) VALUES
(1, 'Arsentiy', 'Vitchenko', '123432 5674', '11/23/2023', '25', '5'),
(2, 'Nikita', 'Egorov', '548758 5425', '11/23/2024', '12', '4');

create table profiledetail
(
passw varchar(50) not null primary key,
username varchar(50) null,
passport varchar(50) null,
profileimage varbinary(MAX) null,
Status varchar(200) null,
coverimage varbinary(MAX) null
);
