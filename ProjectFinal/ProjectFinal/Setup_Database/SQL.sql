USE [master]
GO
/****** Object:  Database [QL_QuanAn]    Script Date: 26/12/2019 7:47:51 PM ******/
CREATE DATABASE [QL_QuanAn]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_QuanAn_data', FILENAME = N'D:\QL_QuanAn.MDF' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_QuanAn_log', FILENAME = N'D:\QL_QuanAn.LDF' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_QuanAn] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_QuanAn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_QuanAn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_QuanAn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_QuanAn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_QuanAn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_QuanAn] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_QuanAn] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_QuanAn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_QuanAn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_QuanAn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_QuanAn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_QuanAn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_QuanAn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_QuanAn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_QuanAn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_QuanAn] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QL_QuanAn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_QuanAn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_QuanAn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_QuanAn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_QuanAn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_QuanAn] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_QuanAn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_QuanAn] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_QuanAn] SET  MULTI_USER 
GO
ALTER DATABASE [QL_QuanAn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_QuanAn] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_QuanAn] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_QuanAn] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QL_QuanAn] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QL_QuanAn', N'ON'
GO
ALTER DATABASE [QL_QuanAn] SET QUERY_STORE = OFF
GO
USE [QL_QuanAn]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Username] [nvarchar](100) NOT NULL,
	[displayName] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DatecheckIn] [date] NOT NULL,
	[DatecheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL,
	[sumPrice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[username] [nvarchar](100) NOT NULL,
	[quantum] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[numberPhone] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameCategory] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tableFood]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeAccount]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameType] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([Username], [displayName], [password], [type]) VALUES (N'admin', N'admin', N'admin', 1)
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([id], [FullName], [numberPhone], [Username]) VALUES (1, N'admin', N'0000', N'admin')
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[TypeAccount] ON 

INSERT [dbo].[TypeAccount] ([id], [nameType]) VALUES (1, N'admin')
INSERT [dbo].[TypeAccount] ([id], [nameType]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[TypeAccount] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Employee__536C85E45D5520F7]    Script Date: 26/12/2019 7:47:51 PM ******/
ALTER TABLE [dbo].[Employee] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'Chưa đặt tên') FOR [displayName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [type]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DatecheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [sumPrice]
GO
ALTER TABLE [dbo].[BillDetail] ADD  DEFAULT ((1)) FOR [quantum]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (N'Chưa đặt tên') FOR [FullName]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (N'Chưa Có số diện thoại') FOR [numberPhone]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'Chưa đặt tên') FOR [nameCategory]
GO
ALTER TABLE [dbo].[tableFood] ADD  DEFAULT (N'Bàn chưa có tên') FOR [name]
GO
ALTER TABLE [dbo].[tableFood] ADD  DEFAULT (N'Trống') FOR [status]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([type])
REFERENCES [dbo].[TypeAccount] ([id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[tableFood] ([id])
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[Account] ([Username])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([Username])
REFERENCES [dbo].[Account] ([Username])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[FoodCategory] ([id])
GO
/****** Object:  StoredProcedure [dbo].[deleteAccount]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteAccount]
@username nvarchar(100)
as
begin
	delete dbo.Employee where Username = @username
	delete dbo.Account where Username = @username

end

GO
/****** Object:  StoredProcedure [dbo].[GetAccountByUsername]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAccountByUsername]
@username nvarchar(100)
as
begin
	select username , displayName , (case type when 1 then N'Nhân viên' else  N'Admin' end) as type from account where Username like '%'+ @username +'%'
end
GO
/****** Object:  StoredProcedure [dbo].[getAllInfoEmployee]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getAllInfoEmployee]
as
begin
	select e.id as [Mã Nhân Viên] , a.username as [Tên Đăng Nhập], displayName as [Tên Hiển Thị],fullname as [Họ Và Tên] , numberPhone as [Số Điện Thoại] ,nameType as [Loại] 
	from Account as a , employee as e , TypeAccount t
	where a.Username = e.username and t.id = a.type
end
GO
/****** Object:  StoredProcedure [dbo].[GetCategorybyName]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetCategorybyName]
@nameCategory nvarchar(100)
as
begin
	 select id as [Mã] , nameCategory as [Tên Loại] from Foodcategory where nameCategory like '%'+ @nameCategory +'%'
end

GO
/****** Object:  StoredProcedure [dbo].[GetFoodbyName]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[GetFoodbyName]
@name nvarchar(100)
as
begin
	select f.id , nameCategory , name  , price 
	from  Food f, FoodCategory fc
	where f.idCategory = fc.id and  f.name like '%'+ @name +'%'
end

GO
/****** Object:  StoredProcedure [dbo].[getListBillByDate]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getListBillByDate]
@dateCheckIn date, @dateCheckOut date
as
begin
	select b.id as[Mã Hóa Đơn] , t.name as[Tên Bàn] ,DatecheckIn as[Ngày Nhập] ,  datecheckout as[Ngày Thanh Toán],username as [Tên Tài Khoản] ,b.sumPrice as[Tổng Tiền]
	from bill b, tablefood t , BillDetail bd
	where datecheckin >=@dateCheckIn and datecheckout <= @dateCheckOut and b.status = 1 and t.id = b.idtable and b.id = bd.idBill
end
exec getListBillByDate '2019-12-26' , '2019-12-26' 
GO
/****** Object:  StoredProcedure [dbo].[getListBillByDateForReport]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[getListBillByDateForReport]
@dateCheckIn date, @dateCheckOut date
as
begin
	select b.id , t.name,DatecheckIn ,  datecheckout , bd.username  ,b.sumPrice 
	from bill b, tablefood t , BillDetail bd
	where datecheckin >=@dateCheckIn and datecheckout <= @dateCheckOut and b.status = 1 and t.id = b.idtable and b.id = bd.idbill
end
GO
/****** Object:  StoredProcedure [dbo].[getNameCategoryByID]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getNameCategoryByID]
@id int
as
begin
	declare @idCategory int
	select @idCategory = idCategory from food where id = @id
	select top 1 fd.id , fd.nameCategory from Food f, FoodCategory fd
	where f.idCategory = fd.id and fd.id = @idCategory
end

GO
/****** Object:  StoredProcedure [dbo].[getNameTypeByUserName]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[getNameTypeByUserName]
@username nvarchar(100)
as
begin
	declare @type int
	select @type = type from Account where username = @username

	select top 1 * from TypeAccount
	where id = @type
end
GO
/****** Object:  StoredProcedure [dbo].[insertAccount]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[insertAccount]
@username nvarchar(100) , @displayname nvarchar(100) , @type int
as
begin
	insert into dbo.Account (Username , displayname , password,type ) values (  @username , @displayname , 1 ,@type )

	insert into dbo.Employee ( username ) values ( @username )
end
GO
/****** Object:  StoredProcedure [dbo].[InsertBill]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[InsertBill]
@idTable int
as
begin
	insert into dbo.Bill(DatecheckIn , DatecheckOut , idTable , status)
	values (getdate() ,null,@idTable , 0)

end
GO
/****** Object:  StoredProcedure [dbo].[InsertBillDetail]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[InsertBillDetail]
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
GO
/****** Object:  StoredProcedure [dbo].[insertEmployee]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertEmployee]
@username nvarchar(100), @fullName nvarchar(100) , @phoneNumber nvarchar(100)
as
begin
	insert into dbo.Employee (fullname , numberPhone ,username ) values (  @fullName , @phoneNumber , @username )
end
GO
/****** Object:  StoredProcedure [dbo].[layDanhSachBanAn]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[layDanhSachBanAn]
as
begin
	select * from dbo.tableFood 
end
GO
/****** Object:  StoredProcedure [dbo].[ListTableStatusNotNull]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListTableStatusNotNull]
as
begin
	select * from dbo.tableFood where status = N'Có Người'
end
GO
/****** Object:  StoredProcedure [dbo].[loadListFood]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[loadListFood]
as
	begin
		select f.id as[Mã] , idCategory as[Loại] , name as [Tên Món] , price as [Giá]
		from Food f , FoodCategory fc
		where idCategory = fc.id
	end
GO
/****** Object:  StoredProcedure [dbo].[loadListFoodByDataTable]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[loadListFoodByDataTable]
as
begin
	select f.id , nameCategory , name  , price 
	from  Food f, FoodCategory fc
	where f.idCategory = fc.id
end
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Login]
@username nvarchar(100) , @password nvarchar(100)
as
begin
	select * from dbo.Account where @username = Username and @password = password
end
GO
/****** Object:  StoredProcedure [dbo].[updateAccount]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateAccount]
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
GO
/****** Object:  StoredProcedure [dbo].[updateAccountFrmAdmin]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[updateAccountFrmAdmin]
@username nvarchar(100),  @displayname nvarchar(100) , @type int
as
begin
	update account set displayName = @displayname, type = @type where Username = @username
end
GO
/****** Object:  StoredProcedure [dbo].[updateEmployee]    Script Date: 26/12/2019 7:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateEmployee]
@username nvarchar(100), @fullName nvarchar(100) , @phoneNumber nvarchar(100)
as
begin
	update  dbo.Employee set   fullname =  @fullName , numberphone =  @phoneNumber where username = @username 
end


GO
USE [master]
GO
ALTER DATABASE [QL_QuanAn] SET  READ_WRITE 
GO
