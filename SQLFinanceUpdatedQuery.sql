create database Finance
use Finance

------ ************						Droping data					*********************
--drop table [Admin]
--drop table Customer
--drop table Product
--drop table Purchase
--drop table EmiCard
--drop table TransactionHistory
--drop table CardStatus
--drop table LoginDetails


-- ************						creating tables					*********************
-- Admin table
create table [Admin](Aid int primary key identity, name nvarchar(30), username nvarchar(30), email nvarchar(30), [password] nvarchar(30), mobNo numeric(10))

-- Customer table
create table Customer(CusNO int primary key identity,[Name] nvarchar(30) not null, PhnNO numeric(10) unique  not null, email nvarchar(40) unique  not null, username varchar(20)  not null, [Password] nvarchar(20)  not null,CPassword nvarchar(20)  not null, bank varchar(10)  not null, AccNo varchar(20)  not null, ifscCode varchar(11)  not null, Dob Date constraint dob_chk check (dob<=cast('2002-01-01' as date))  not null,Cardtype varchar(10) not null, ResetPasswordCode nvarchar(100) )
-- emiCardNo int foreign key (emiCardNo) references CardStatus(CardNo)

-- Product table
create table Product(ProductId int primary key, ProductName nvarchar(max), Image varchar(max), Qty int, Description varchar(max), ProductCost decimal(10,2), StrikedCost decimal(10,2))

-- Purchase table
create table Purchase(BookingId int identity, ProdID int, CusNo int, EmiScheme int, PurchasedDate date, DueAmount decimal(10,2),MonthlyAmount decimal(10,2), primary key(BookingId,ProdID), foreign key (ProdId) references Product(ProductId), Foreign key(CusNo) references Customer(CusNO))


-- EmiCard table
create table EmiCard(Cardtype varchar(1) primary key, CardLimit decimal(10,2), ProcessingFee int)

-- TransactionHistory table
create table TransactionHistory(TrnId int primary key identity,[Date] date,amount decimal(10,2), CusNO int, PrdId int, foreign key (CusNO) references Customer(CusNO), foreign key (PrdId) references Product(ProductId))

-- CardStatus table
create table CardStatus(CardNo int primary key identity,adminid int , CusNo int, [Status] int constraint status_chk check ([status]=1 or [status]=0), validity date, CardBalance decimal(10,2), foreign key (adminid) references [Admin](Aid), foreign key (CusNo) references Customer(CusNo),  cardtype varchar(1) constraint cardtype_chk check (cardtype='G' OR cardtype='T')) 


-- login table
create table LoginDetails(loginid int  primary key identity, username varchar(20), [Password] nvarchar(20))


-- ************						inserting data					*********************
-- insert into Admin
insert into [Admin] values('Swathi HP','Swathi','swathi.hp@zensar.com','Swathi090',8310152090)

-- insert into in Customer
insert into Customer values('Narsimha varma',8886211822,'srnarasimhavarma.v@zensar.com','srvarma','SRNVarma822','SRNVarma822','icici','7898800996545327','icici0987',cast('1999-10-11' as date),'G',null)
insert into Customer values('Shamshuddin Nalaband',9581704870,'shamshuddin.nalband@zensar.com','ShamN','ShamNal870','ShamNal870','hdfc','6386338720897878','hdfc002',cast('1998-07-19' as date),'G',null)
insert into Customer values('Sahir',7006812967,'sahir.bhat@zensar.com','SMBhat','SahirMB967','SahirMB967', 'idfc','086108193267','idfc2255',cast('1999-08-23' as date),'T',null)

-- insert into  product
insert into Product values(51,'Samsung Microwave Oven','https://rukminim2.flixcart.com/image/416/416/k02qnww0/microwave-new/v/f/q/ms23f301tak-tl-samsung-original-imafjyadcvmqw2hp.jpeg?q=70',3,'28L, Black Color',43200.00,98200.00)
insert into Product values(101,'iphone 12','https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRLouV3XpqfKaDer8WTZBftzLyWdonirK4npXBGLyn88ltGh-LOnXOUIiqZnmvhvaEgibAdnb4o9aaVYUPsqhQrcm43DtSUbQ',9,'128gb 6.1inch 12mpcamera ',70990.00,120700.00)
insert into Product values(102,'Oneplus 9 pro 5g','https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQ9ARLO2oWo6Ldm9XFZadzFxxWYZS_Oqv1dXmnPqSvXrjgbDB8Z51OxmuP939vOE5eS8Bd5AerGEoEY-sGq0En162TPxGc_IQ',15,'Black Color 64gb 7200mah ',29890.00,65200.00)
insert into Product values(201,'Mi Led tv 2c','https://www.reliancedigital.in/medias/Xiaomi-ELA4668IN-Televisions-492571700-i-1-1200Wx1200H?context=bWFzdGVyfGltYWdlc3wzMjEzMzB8aW1hZ2UvanBlZ3xpbWFnZXMvaGQ5L2g3ZC85NjkxNjYyMjIxMzQyLmpwZ3w2NDFhN2JiMmQxY2QwY2M2MGZiYTY4NjdmNWI5YTY4OTE2MWI0ZTQ0MDA0MWZhMGNkMDBkYWEzNDY3YzU3MDM3',5,'led smart 52inches',31250.00,45078.00)

insert into Product values(301,'Refrigerator','https://d2d22nphq0yz8t.cloudfront.net/88e6cc4b-eaa1-4053-af65-563d88ba8b26/https://media.croma.com/image/upload/v1605336559/Croma%20Assets/Large%20Appliances/Refrigerator/Images/8951140679710.png/mxw_1440,f_auto',8,'Whirlpool 245Ltr 4* double door ',26490.00,56120.00)
insert into Product values(401,'Washing Machine','https://d2d22nphq0yz8t.cloudfront.net/88e6cc4b-eaa1-4053-af65-563d88ba8b26/https://media.croma.com/image/upload/v1629866927/Croma%20Assets/Large%20Appliances/Washers%20and%20Dryers/Images/235331_w6eund.png/mxw_1440,f_auto',6,'LG Front Load with Diamond Drum & Ceramic Heater 6.0Kg',23490.00,27550.00)

--insert into Purchase
insert into Purchase values(201,3,6,cast(GETDATE() as date),31250.00,6250)
insert into Purchase values(51,1,3,cast(GETDATE() as date),28800.00,14400)


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
select * from EmiCard
select * from TransactionHistory
select * from CardStatus
select * from LoginDetails




-- ************						Stored Procedures					*********************

-- procedure for login
create or alter proc sp_login @usrname nvarchar(50), @pswd nvarchar(50), @isValid bit Out
as
begin
set @isValid=(select count(1) from Customer where username=@usrname and [Password]=@pswd)
end

sp_help sp_login








-- BankDetails table
--create table BankDetails(CusNO int , bank varchar(10), AccNo varchar(20) primary key, ifscCode varchar(11), Dob Date constraint dob_chk check (dob<=cast('2002-01-01' as date)), foreign key (CusNo) references Customer(CusNO))
-- insert into BankDetails
--insert into BankDetails values(1,'HDFC','6547892122326754','hdfc007','1999-10-23')
--insert into BankDetails values(2,'ICICI','2984863173868720','icici209','1998-03-12')
--insert into BankDetails values(3,'idfc','5432109983418637','idfch301','1999-07-30')
