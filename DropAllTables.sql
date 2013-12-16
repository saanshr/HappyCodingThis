
declare @tbl_name as varchar(256)
declare @flag as int
declare @name as varchar(256)
set @flag=(select count(*) from sysobjects where type='U')
while(@flag>0)
begin
set @name=(select top 1 name from sysobjects where type='U')
set @tbl_name = 'drop table ' + @name
exec(@tbl_name)
set @flag=@flag-1
end
