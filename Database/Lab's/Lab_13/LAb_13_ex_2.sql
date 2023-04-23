use KAD_MyBase;

/* ************************** */
go
create PROCEDURE Pr1
as
begin
	set nocount on;
	select * from Выдача_кредитов;
	declare @q int = (select count(*) from Выдача_кредитов);
	return @q;
end;

go
--DROP PROCEDURE Pr1;

declare @result int = 0;
EXEC @result = Pr1;
print 'Количество строк: ' + cast(@result as varchar(10));

/* ************************** */
create table #table
(
	s1 int not null,
	s2 nvarchar(40) not null,
);

go
create PROCEDURE Pr2 @name nvarchar(40)
as
begin
set nocount on;
	select Клиент.Номер_выдачи, Клиент.Название_фирмы_клиента from Клиент where Клиент.Название_фирмы_клиента = @name;
	declare @q int = (select count(*) from Клиент);
	return @q;
end;

insert #table exec Pr2 @name = 'Фирма 1';

select * from #table;

drop procedure Pr2;
drop table #table;

/* ************************** */
go
create PROCEDURE Pr3
			     @a int, @n nvarchar(30), @c nvarchar(10), @t int, @k date, @k2 date
as 
declare @res int = 1;
begin try
	insert into Выдача_кредитов(Номер_выдачи, Название_вида_кредита, Ставка,Сумма, Дата_выдачи, Дата_возврата)
	VALUES (@a, @n, @c, @t, @k, @k2);
return @res;
end try
begin catch
	print 'Ошибка: ' + cast(error_number() as varchar(6));
	print 'Сообщение: ' + error_message();
	return -1;
end catch

declare @rc int;
exec @rc = Pr3 @a = 15, @n = 'Кредит 25', @c = '16%', @t = 553, @k = '2023-10-10', @k2 = '2029-11-10';
print @rc;

--drop procedure Pr3;
--delete Выдача_кредитов where Выдача_кредитов.Название_вида_кредита = 'Кредит 25';