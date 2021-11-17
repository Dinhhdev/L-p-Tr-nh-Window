

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
	select b.id as[Mã Hóa Đơn] , t.name as[Tên Bàn] ,DatecheckIn as[Ngày Nhập] ,  datecheckout as[Ngày Thanh Toán] , bd.username as [Tên Tài Khoản] ,b.sumPrice as[Tổng Tiền]
	from bill b, tablefood t , BillDetail bd
	where datecheckin >=@dateCheckIn and datecheckout <= @dateCheckOut and b.status = 1 and t.id = b.idtable and b.id = bd.idbill
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
