use KAD_MyBase;

/* *********************************************** */
begin try
	begin tran
		delete Выдача_кредитов where Название_вида_кредита = 'Кредит 6';
		insert into Выдача_кредитов values('8','Кредит 6','40%',522, '2018-06-01', '2033-09-10');
		update Выдача_кредитов set Сумма = '300' where Номер_выдачи= 8;
	commit tran;
end try

begin catch
	print 'Ошибка: ' + cast(error_number() as varchar(5)) + ' ' + error_message()
	if @@TRANCOUNT > 0 rollback tran;
end catch;

/* *********************************************** */
DECLARE @savepoint varchar(30);
begin try
	begin tran
		delete Выдача_кредитов where Название_вида_кредита = 'Кредит 6';									
		set @savepoint = 'save1'; save transaction @savepoint;

		insert into Выдача_кредитов values('8','Кредит 6','40%',522, '2018-06-01', '2033-09-10');						
		set @savepoint = 'save2'; save transaction @savepoint;

		update Выдача_кредитов set Сумма = '300' where Номер_выдачи= 8;		
		set @savepoint = 'save3'; save transaction @savepoint;
	commit tran;
end try

begin catch
	print 'Ошибка: ' + cast(error_number() as varchar(5)) + ' ' + error_message()
	if @@TRANCOUNT > 0
		begin
			print 'Контрольная точка: ' + @savepoint;
			rollback tran @savepoint;
			commit tran;
		end;
end catch;	

/* *********************************************** */

-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
	-------------------------- t1 ------------------
	select @@SPID 'SID', 'insert Выдача_кредитов' 'результат', * from Выдача_кредитов
	                                                                where Ставка = '40%';
																	             
	select @@SPID 'SID', 'update Выдача_кредитов'  'результат',  Номер_выдачи, 
                      Сумма, Ставка from Выдача_кредитов   where  Сумма=15000;
	commit; 
	-------------------------- t2 -----------------

--- B --	
	begin transaction 
	select @@SPID 'SID';
	insert into Выдача_кредитов values('9','Кредит 15','30%',5298, '2015-05-01', '2083-03-12');   
	update Выдача_кредитов set Сумма = '300' where Номер_выдачи= 9;	
	-------------------------- t1 --------------------
	-------------------------- t2 --------------------
	rollback;

	delete Выдача_кредитов where Номер_выдачи = 9;

/* *********************************************** */

-- A ---
    set transaction isolation level READ COMMITTED 
	begin transaction 
	select count(*) from Выдача_кредитов where Ставка = '40%';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select @@SPID 'SID', 'update Выдача_кредитов'  'результат',  Номер_выдачи, 
                      Сумма, Ставка from Выдача_кредитов   where  Сумма=15000;
	commit; 

	--- B ---	
	begin transaction 	

	-------------------------- t1 --------------------
    select @@SPID 'SID' update Выдача_кредитов set Сумма = '300' where Сумма = 15000;

      commit; 
	-------------------------- t2 --------------------	
