use master;

/* ex_1 */
set nocount on; --используется для отключения сообщений о количестве обработанных строк, которые возвращаются при выполнении запроса.

if exists (select * from SYS.OBJECTS where OBJECT_ID = object_id(N'DBO.NewTable'))
begin
		drop table NewTable;	
end;

declare @c int, @flag char = 'c';

SET IMPLICIT_TRANSACTIONS ON;
create table NewTable
(
	i int identity(1,1),
	word varchar(50) not null
);

insert newTable(word) 
VALUES('ПвИ'), ('ООП'), ('ПСП'), ('БД');
set @c = (select count(*) from NewTable);
print 'Количество строк в таблице: ' + cast(@c as varchar(5));
	if @flag like 'c'
	begin
		commit;
	end;

	else
	begin
		rollback;
	end;
SET IMPLICIT_TRANSACTIONS OFF;

if exists (select * from SYS.OBJECTS where OBJECT_ID = object_id(N'DBO.NewTable'))
begin
		print 'Таблица есть!'
end;

else
begin
		print 'Таблицы нету!('
end;

/* ex_2 */
use UNIVER;
begin try
	begin tran
		delete AUDITORIUM where AUDITORIUM_NAME = '301-1';
		insert into AUDITORIUM values('991-1','ЛБ-К','5','204-1');
		update AUDITORIUM set AUDITORIUM_CAPACITY = '30' where AUDITORIUM_NAME='301-1';
	commit tran;
end try

begin catch
	print 'Ошибка: ' + cast(error_number() as varchar(5)) + ' ' + error_message()
	if @@TRANCOUNT > 0 rollback tran;
end catch;

/* ex_3 */
use UNIVER;

DECLARE @savepoint varchar(30);
begin try
	begin tran
		delete AUDITORIUM where AUDITORIUM_NAME = '301-1';									
		set @savepoint = 'save1'; save transaction @savepoint;

		insert into AUDITORIUM values('301-1','ЛБ-К','15','301-1');							
		set @savepoint = 'save2'; save transaction @savepoint;

		update AUDITORIUM set AUDITORIUM_CAPACITY = '30' where AUDITORIUM_NAME='301-1';		
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

insert into AUDITORIUM values('301-1','ЛБ-К','15','301-1');

/* ex_4 */
use UNIVER;

-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
	-------------------------- t1 ------------------
	select @@SPID 'SID', 'insert AUDITORIUM' 'результат', * from SUBJECT 
	                                                                where SUBJECT = 'СТПИ';
																	             
	select @@SPID 'SID', 'update AUDITORIUM'  'результат',  AUDITORIUM_NAME, 
                      AUDITORIUM_TYPE,AUDITORIUM_CAPACITY from AUDITORIUM   where  AUDITORIUM_NAME='301-1';
	commit; 
	-------------------------- t2 -----------------

--- B --	
	begin transaction 
	select @@SPID 'SID';
	INSERT into SUBJECT values('СТПИ','Современные технологии программирования в  интернете','ИСиТ');   
	update AUDITORIUM set AUDITORIUM_CAPACITY = '15' where AUDITORIUM_NAME='301-1';	
	-------------------------- t1 --------------------
	-------------------------- t2 --------------------
	rollback;

	delete SUBJECT where SUBJECT = 'СТПИ';

/* ex_5 */
use UNIVER;

-- A ---
    set transaction isolation level READ COMMITTED 
	begin transaction 
	select count(*) from AUDITORIUM where AUDITORIUM_CAPACITY = '30';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select @@SPID 'SID', 'update AUDITORIUM'  'результат',  AUDITORIUM_NAME, 
                      AUDITORIUM_TYPE,AUDITORIUM_CAPACITY from AUDITORIUM   where  AUDITORIUM_NAME='301-1';
	commit; 

	--- B ---	
	begin transaction 	

	-------------------------- t1 --------------------
    select @@SPID 'SID' update AUDITORIUM set AUDITORIUM_CAPACITY = '30' where AUDITORIUM_NAME='301-1';	

      commit; 
	-------------------------- t2 --------------------	

/* ex_6 */
use UNIVER;
-- A ---
    set transaction isolation level  REPEATABLE READ 
	begin transaction 
	select SUBJECT_NAME from SUBJECT where PULPIT = 'ТЛ';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  case
          when SUBJECT = 'СТПИ' then 'insert  SUBJECT'  else ' ' 
end 'результат', SUBJECT_NAME from SUBJECT  where PULPIT = 'ТЛ';
	commit; 

	--- B ---	
	begin transaction 	  
	-------------------------- t1 --------------------
          	INSERT into SUBJECT values('СТПИ','Современные технологии программирования в  интернете','ИСиТ');   
          commit; 
	-------------------------- t2 --------------------

delete SUBJECT where SUBJECT = 'СТПИ';

/* ex_7 */
-- A ---
set transaction isolation level SERIALIZABLE 
	begin transaction 
		delete SUBJECT where SUBJECT = 'СТПИ';
		INSERT into SUBJECT values('СТПИ', 'Современные технологии программирования в  интернете', 'ИСиТ');
        update SUBJECT set SUBJECT_NAME = 'Современные технологии программирования в  INTERNET' where  SUBJECT = 'СТПИ';
	    select SUBJECT_NAME,PULPIT from SUBJECT where PULPIT = 'ИСиТ';
	-------------------------- t1 -----------------
	 select SUBJECT_NAME,PULPIT from SUBJECT where PULPIT = 'ИСиТ';
	-------------------------- t2 ------------------ 
	commit; 	

--- B ---	
	begin transaction 	  
		delete SUBJECT where SUBJECT = 'СТПИ';
		INSERT into SUBJECT values('СТПИ','Современные технологии программирования в  интернете','ИСиТ');
        update SUBJECT set SUBJECT_NAME = 'Современные технологии программирования в  INTERNET' where  SUBJECT = 'СТПИ';
	    select SUBJECT_NAME from SUBJECT where PULPIT = 'ИСиТ';
     -------------------------- t1 --------------------
     commit; 
     select SUBJECT_NAME,PULPIT from SUBJECT where PULPIT = 'ИСиТ';
     -------------------------- t2 --------------------
	 		
	delete SUBJECT where SUBJECT = 'СТПИ';

/* ex_8 */
delete SUBJECT where SUBJECT = 'СТПИ';

begin tran
		INSERT into SUBJECT values('СТПИ','Современные технологии программирования в  интернете','ИСиТ');   ;
		begin tran
		update SUBJECT set SUBJECT_NAME='СТПИ' where SUBJECT='СТПИ';
		commit
		if @@TRANCOUNT > 0 rollback;

select
		(select count(*) from SUBJECT where SUBJECT='СТПИ') 'Дисциплина',
		(select count(*) from TEACHER inner join SUBJECT on TEACHER.PULPIT = SUBJECT.PULPIT) 'Преподаватели'

		