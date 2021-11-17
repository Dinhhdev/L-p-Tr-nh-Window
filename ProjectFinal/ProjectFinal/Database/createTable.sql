create database QL_QuanAn
--on (name = 'QL_QuanAn_data' , filename ='D:\Lập trình trên môi trường Windows\Labs\ProjectFinal\Database\QuanLyQuan.MDF')
--log on (name ='QL_QuanAn_log' ,filename = 'D:\Lập trình trên môi trường Windows\Labs\ProjectFinal\Database\QuanLyQuan.LDF')
on (name = 'QL_QuanAn_data' , filename ='D:\QL_QuanAn.MDF')
log on (name ='QL_QuanAn_log' ,filename = 'D:\QL_QuanAn.LDF')
go
use QL_QuanAn
go
create table tableFood
(
	id INT identity primary key,
	name nvarchar(100) not null default N'Bàn chưa có tên' ,
	status NvarChar(100) not null default N'Trống' -- 
)
go
create table TypeAccount
 (
	id int identity primary key,
	nameType nvarchar(50)
 )
go
create table Account
(
	Username nvarchar (100) primary key,
	displayName nvarchar(100) not null default N'Chưa đặt tên',
	password nvarchar (100) not null,
	type int not null default 0,  --0 : nhân viên , 1: admin

	foreign key (type) references TypeAccount(id)
)
go
create table Employee
(
	id INT identity primary key,
	FullName nvarchar(100) not null default N'Chưa đặt tên',
	numberPhone nvarchar (100) not null default N'Chưa Có số diện thoại',
	Username nvarchar (100)UNIQUE ,

	foreign key (Username) references Account(Username)
)
go
 create table FoodCategory
 (
	id int identity primary key,
	nameCategory nvarchar (100) not null default N'Chưa đặt tên',
 )
 go

create table Food
 (
	id int identity primary key,
	name nvarchar (100) not null default N'Chưa đặt tên',
	idCategory int not null,
	price int not null default 0,
	
	foreign key (idcategory) references FoodCategory(id)
 )
 go

 create table Bill
 (
	id int identity primary key,
	DatecheckIn Date not null default getdate(),
	DatecheckOut date,
	idTable int not null,
	status int not null default 0, --0 Chưa thanh toán
	sumPrice int default 0,
	foreign key (idTable) references tableFood(id)
 )
 go
 go
  create table BillDetail
 (
	id int identity primary key,
	idBill int not null,
	idFood int not null,
	username nvarchar(100) not null,
	quantum int not null default 1,
	foreign key (idBill) references Bill(id),
	foreign key (idFood) references Food(id),
	foreign key (username) references account(username),
 )
 go

create trigger updateBillDetail
on dbo.billDetail for insert, update
as
begin
	declare @idBill int
	select @idBill = idbill from inserted

	declare @idTable int
	select @idTable = idtable from Bill where id = @idBill and status = 0

	update tableFood set status = N'Có Người' where id = @idTable

end
go
create trigger updateBill
on dbo.Bill for update
as
begin
	declare @idBill int
	select @idBill = id from Inserted

	declare @idTable int
	select @idTable = idTable from dbo.Bill where id = @idBill

	declare @quantum int = 0
	select  @quantum = Count(*) from dbo.Bill where idTable = @idTable and status = 0
	
	if(@quantum = 0)
		update dbo.tableFood set status = N'Trống' where id = @idTable
	else
		update dbo.tableFood set status = N'Có Người' where id = @idTable

end
go

create trigger deleteBill
on dbo.Bill for delete
as
begin
	declare @idBill int
	select @idBill = id from deleted

	declare @idTable int
	select @idTable = idTable from dbo.Bill where id = @idBill

	declare @quantum int = 0
	select  @quantum = Count(*) from dbo.Bill where idTable = @idTable and status = 0
	
	if(@quantum = 0)
		update dbo.tableFood set status = N'Trống' where id = @idTable
	else
		update dbo.tableFood set status = N'Có Người' where id = @idTable

end
go
create trigger deleteBillDetail
on dbo.billDetail for delete
as
	begin
		declare @idBillDetail int
		declare @idBill int
		select @idBill = idbill , @idBillDetail = id from deleted

		declare @idTable int
		select @idTable = idTable  from Bill where id = @idBill

		declare @count int = 0

		select @count = count(*) from BillDetail bd , Bill b where b.id = bd.idBill and b.id = @idBill and status = 0
		if(@count = 0)
			update tableFood set status = N'Trống' where id = @idTable
	end

go

create proc Login
@username nvarchar(100) , @password nvarchar(100)
as
begin
	select * from dbo.Account where @username = Username and @password = password
end
go

create proc layDanhSachBanAn
as
begin
	select * from dbo.tableFood 
end
go
create proc ListTableStatusNotNull
as
begin
	select * from dbo.tableFood where status = N'Có Người'
end
go

create proc InsertBill
@idTable int
as
begin
	insert into dbo.Bill(DatecheckIn , DatecheckOut , idTable , status)
	values (getdate() ,null,@idTable , 0)

end
go

create proc InsertBillDetail
@idBill int , @idFood int , @quantum int , @username nvarchar(100)
as
begin
	declare @isExist int
	declare @foodCount int = 1

	select @isExist = id , @foodCount = quantum
	from Billdetail
	where idBill = @idBill and idFood =@idFood

	if(@isExist > 0)
	begin
		declare @newCount int = @foodCount + @quantum
		if(@newCount > 0)
			update BillDetail set quanTum = @newCount where idFood = @idFood and @idBill = idBill
		else
			delete BillDetail where idBill = @idBill and idFood =@idFood
	end
	
	else
		begin
			insert into dbo.BillDetail( idBill, idFood , username ,quanTum  )
			values (@idBill, @idFood, @username,@quantum)
		end
end
go
create proc getListBillByDate
@dateCheckIn date, @dateCheckOut date
as
begin
	select b.id as[Mã Hóa Đơn] , t.name as[Tên Bàn] ,DatecheckIn as[Ngày Nhập] ,  datecheckout as[Ngày Thanh Toán],username as [Tên Tài Khoản] ,b.sumPrice as[Tổng Tiền]
	from bill b, tablefood t , BillDetail bd
	where datecheckin >=@dateCheckIn and datecheckout <= @dateCheckOut and b.status = 1 and t.id = b.idtable and b.id = bd.idBill
end
exec getListBillByDate '2019-12-26' , '2019-12-26' 
go
create proc updateAccount
@usernam nvarchar(100) , @displayName nvarchar(100) , @password nvarchar(100) , @newpassword nvarchar(100) 
as
	begin
		declare @isRightPassword int = 0
		select @isRightPassword = count(*) from Account where Username = @usernam and password =@password

		if(@isRightPassword = 1)
		begin
			if(@newpassword = null or @newpassword = '')
			begin
				update Account set displayName = @displayName where Username = @usernam
			end
			else
				update Account set displayName = @displayName , password = @newpassword where Username = @usernam
		end
	end
go
create proc loadListFood
as
	begin
		select f.id as[Mã] , idCategory as[Loại] , name as [Tên Món] , price as [Giá]
		from Food f , FoodCategory fc
		where idCategory = fc.id
	end
go
create proc getNameCategoryByID
@id int
as
begin
	declare @idCategory int
	select @idCategory = idCategory from food where id = @id
	select top 1 fd.id , fd.nameCategory from Food f, FoodCategory fd
	where f.idCategory = fd.id and fd.id = @idCategory
end

go

create proc loadListFoodByDataTable
as
begin
	select f.id , nameCategory , name  , price 
	from  Food f, FoodCategory fc
	where f.idCategory = fc.id
end
go

create proc GetFoodbyName
@name nvarchar(100)
as
begin
	select f.id , nameCategory , name  , price 
	from  Food f, FoodCategory fc
	where f.idCategory = fc.id and  f.name like '%'+ @name +'%'
end

go

create proc insertAccount
@username nvarchar(100) , @displayname nvarchar(100) , @type int
as
begin
	insert into dbo.Account (Username , displayname , password,type ) values (  @username , @displayname , 1 ,@type )

	insert into dbo.Employee ( username ) values ( @username )
end
go
create proc deleteAccount
@username nvarchar(100)
as
begin
	delete dbo.Employee where Username = @username
	delete dbo.Account where Username = @username

end

go
create proc insertEmployee
@username nvarchar(100), @fullName nvarchar(100) , @phoneNumber nvarchar(100)
as
begin
	insert into dbo.Employee (fullname , numberPhone ,username ) values (  @fullName , @phoneNumber , @username )
end
go
create proc updateEmployee
@username nvarchar(100), @fullName nvarchar(100) , @phoneNumber nvarchar(100)
as
begin
	update  dbo.Employee set   fullname =  @fullName , numberphone =  @phoneNumber where username = @username 
end


go

create proc getNameTypeByUserName
@username nvarchar(100)
as
begin
	declare @type int
	select @type = type from Account where username = @username

	select top 1 * from TypeAccount
	where id = @type
end
go

create proc updateAccountFrmAdmin
@username nvarchar(100),  @displayname nvarchar(100) , @type int
as
begin
	update account set displayName = @displayname, type = @type where Username = @username
end
go
create proc GetAccountByUsername
@username nvarchar(100)
as
begin
	select username , displayName , (case type when 1 then N'Nhân viên' else  N'Admin' end) as type from account where Username like '%'+ @username +'%'
end
go
create proc GetCategorybyName
@nameCategory nvarchar(100)
as
begin
	 select id as [Mã] , nameCategory as [Tên Loại] from Foodcategory where nameCategory like '%'+ @nameCategory +'%'
end

go
create proc getAllInfoEmployee
as
begin
	select e.id as [Mã Nhân Viên] , a.username as [Tên Đăng Nhập], displayName as [Tên Hiển Thị],fullname as [Họ Và Tên] , numberPhone as [Số Điện Thoại] ,nameType as [Loại] 
	from Account as a , employee as e , TypeAccount t
	where a.Username = e.username and t.id = a.type
end
go

create proc getListBillByDateForReport
@dateCheckIn date, @dateCheckOut date
as
begin
	select b.id , t.name,DatecheckIn ,  datecheckout , bd.username  ,b.sumPrice 
	from bill b, tablefood t , BillDetail bd
	where datecheckin >=@dateCheckIn and datecheckout <= @dateCheckOut and b.status = 1 and t.id = b.idtable and b.id = bd.idbill
end
go
insert into typeAccount(nameType) values (N'admin')
go
insert into typeAccount(nameType) values (N'Nhân viên')
go
insert into account(username , displayName , password , type) values (N'admin' , N'admin' ,N'admin' , 1)
go
insert into Employee( FullName,numberPhone,username) values (N'admin' , N'0000' ,N'admin')
go


