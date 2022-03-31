create database Finance
use Finance

-- ************						creating tables					*********************
-- Admin table
create table [Admin](Aid int primary key identity, name nvarchar(30), username nvarchar(30), email nvarchar(30), [password] nvarchar(30), mobNo numeric(10))

-- Customer table
create table Customer(CusNO int primary key identity,[Name] nvarchar(30), PhnNO numeric(10) unique, email nvarchar(40) unique, username varchar(20), [Password] nvarchar(20),CPassword nvarchar(20))
-- emiCardNo int foreign key (emiCardNo) references CardStatus(CardNo)

-- Product table
create table Product(ProductId int primary key, ProductName nvarchar(max), Image varchar(max), Qty int, Description varchar(max), ProductCost decimal(10,2), StrikedCost decimal(10,2))

-- Purchase table
create table Purchase(BookingId int identity, ProdID int, CusNo int, EmiScheme int, PurchasedDate date, DueAmount decimal(10,2),MonthlyAmount decimal(10,2), primary key(BookingId,ProdID), foreign key (ProdId) references Product(ProductId), Foreign key(CusNo) references Customer(CusNO))

-- BankDetails table
create table BankDetails(CusNO int , bank varchar(10), AccNo varchar(20) primary key, ifscCode varchar(11), Dob Date constraint dob_chk check (dob<=cast('2002-01-01' as date)), foreign key (CusNo) references Customer(CusNO))

-- EmiCard table
create table EmiCard(Cardtype varchar(1) primary key, CardLimit decimal(10,2), ProcessingFee int)

-- TransactionHistory table
create table TransactionHistory(TrnId int primary key identity,[Date] date,amount decimal(10,2), CusNO int, PrdId int, foreign key (CusNO) references Customer(CusNO), foreign key (PrdId) references Product(ProductId))

-- CardStatus table
create table CardStatus(CardNo int primary key identity,adminid int , CusNo int, [Status] int constraint status_chk check ([status]=1 or [status]=0), validity date, CardBalance decimal(10,2), foreign key (adminid) references [Admin](Aid), foreign key (CusNo) references Customer(CusNo),  cardtype varchar(1) constraint cardtype_chk check (cardtype='G' OR cardtype='T')) 


-- ************						inserting data					*********************
-- insert into Admin
insert into [Admin] values('Swathi HP','Swathi','swathi.hp@zensar.com','Swathi090',8310152090)

-- insert into in Customer
insert into Customer values('Narsimha varma',8886211822,'srnarasimhavarma.v@zensar.com','srvarma','SRNVarma822','SRNVarma822')
insert into Customer values('Shamshuddin Nalaband',9581704870,'shamshuddin.nalband@zensar.com','ShamN','ShamNal870','ShamNal870')
insert into Customer values('Sahir',7006812967,'sahir.bhat@zensar.com','SMBhat','SahirMB967','SahirMB967')

-- insert into  product
insert into Product values(51,'Samsung Microwave Oven','C:\Users\krith\OneDrive\Desktop\Finance\Product Images\Microwave oven',3,'28L, Black Color',43200.00,98200.00)
insert into Product values(101,'iphone 12','C:\Users\krith\OneDrive\Desktop\Finance\Product Images\iphone 12',9,'128gb 6.1inch 12mpcamera ',70990.00,120700.00)
insert into Product values(102,'Oneplus 9 pro 5g','C:\Users\krith\OneDrive\Desktop\Finance\Product Images\oneplus 9pro 5g',15,'Black Color 64gb 7200mah ',29890.00,65200.00)
insert into Product values(201,'Mi Led tv 2c','C:\Users\krith\OneDrive\Desktop\Finance\Product Images\Mi led tv 4c',5,'led smart 52inches',31250.00,45078.00)

--insert into Purchase
insert into Purchase values(201,3,6,cast(GETDATE() as date),31250.00,6250)
insert into Purchase values(51,1,3,cast(GETDATE() as date),28800.00,14400)

-- insert into BankDetails
insert into BankDetails values(1,'HDFC','6547892122326754','hdfc007','1999-10-23')
insert into BankDetails values(2,'ICICI','2984863173868720','icici209','1998-03-12')
insert into BankDetails values(3,'idfc','5432109983418637','idfch301','1999-07-30')

-- insert into EmiCard
insert into EmiCard values('G',100000.00,5000)
insert into EmiCard values('T',200000.00,9000)

-- insert into TransactionHistory
insert into TransactionHistory values(cast(GetDate() as date),6250,3,201)
insert into TransactionHistory values(cast(GetDate() as date),14400,1,51)

-- insert into CardStatus
insert into CardStatus values(1,1,1,DateADD(year,1,cast(GetDate() as date)),100000.00,'G')
insert into CardStatus values(1,2,0,null,00.00,'G')
insert into CardStatus values(1,3,1,DateADD(year,2,cast(GetDate() as date)),200000.00,'T')

-- ************						selecting data					*********************
select * from [Admin]
select * from Customer
select * from Product
select * from Purchase
select * from BankDetails
select * from EmiCard
select * from TransactionHistory
select * from CardStatus


------ ************						Droping data					*********************
--drop table [Admin]
--drop table Customer
--drop table Product
--drop table Purchase
--drop table BankDetails
--drop table EmiCard
--drop table TransactionHistory
