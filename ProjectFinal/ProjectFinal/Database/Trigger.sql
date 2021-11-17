

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

