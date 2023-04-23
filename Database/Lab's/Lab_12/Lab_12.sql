use master;

/* ex_1 */
set nocount on; --������������ ��� ���������� ��������� � ���������� ������������ �����, ������� ������������ ��� ���������� �������.

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
VALUES('���'), ('���'), ('���'), ('��');
set @c = (select count(*) from NewTable);
print '���������� ����� � �������: ' + cast(@c as varchar(5));
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
		print '������� ����!'
end;

else
begin
		print '������� ����!('
end;

/* ex_2 */
use UNIVER;
begin try
	begin tran
		delete AUDITORIUM where AUDITORIUM_NAME = '301-1';
		insert into AUDITORIUM values('991-1','��-�','5','204-1');
		update AUDITORIUM set AUDITORIUM_CAPACITY = '30' where AUDITORIUM_NAME='301-1';
	commit tran;
end try

begin catch
	print '������: ' + cast(error_number() as varchar(5)) + ' ' + error_message()
	if @@TRANCOUNT > 0 rollback tran;
end catch;

/* ex_3 */
use UNIVER;

DECLARE @savepoint varchar(30);
begin try
	begin tran
		delete AUDITORIUM where AUDITORIUM_NAME = '301-1';									
		set @savepoint = 'save1'; save transaction @savepoint;

		insert into AUDITORIUM values('301-1','��-�','15','301-1');							
		set @savepoint = 'save2'; save transaction @savepoint;

		update AUDITORIUM set AUDITORIUM_CAPACITY = '30' where AUDITORIUM_NAME='301-1';		
		set @savepoint = 'save3'; save transaction @savepoint;
	commit tran;
end try

begin catch
	print '������: ' + cast(error_number() as varchar(5)) + ' ' + error_message()
	if @@TRANCOUNT > 0
		begin
			print '����������� �����: ' + @savepoint;
			rollback tran @savepoint;
			commit tran;
		end;
end catch;	

insert into AUDITORIUM values('301-1','��-�','15','301-1');

/* ex_4 */
use UNIVER;

-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
	-------------------------- t1 ------------------
	select @@SPID 'SID', 'insert AUDITORIUM' '���������', * from SUBJECT 
	                                                                where SUBJECT = '����';
																	             
	select @@SPID 'SID', 'update AUDITORIUM'  '���������',  AUDITORIUM_NAME, 
                      AUDITORIUM_TYPE,AUDITORIUM_CAPACITY from AUDITORIUM   where  AUDITORIUM_NAME='301-1';
	commit; 
	-------------------------- t2 -----------------

--- B --	
	begin transaction 
	select @@SPID 'SID';
	INSERT into SUBJECT values('����','����������� ���������� ���������������� �  ���������','����');   
	update AUDITORIUM set AUDITORIUM_CAPACITY = '15' where AUDITORIUM_NAME='301-1';	
	-------------------------- t1 --------------------
	-------------------------- t2 --------------------
	rollback;

	delete SUBJECT where SUBJECT = '����';

/* ex_5 */
use UNIVER;

-- A ---
    set transaction isolation level READ COMMITTED 
	begin transaction 
	select count(*) from AUDITORIUM where AUDITORIUM_CAPACITY = '30';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select @@SPID 'SID', 'update AUDITORIUM'  '���������',  AUDITORIUM_NAME, 
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
	select SUBJECT_NAME from SUBJECT where PULPIT = '��';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  case
          when SUBJECT = '����' then 'insert  SUBJECT'  else ' ' 
end '���������', SUBJECT_NAME from SUBJECT  where PULPIT = '��';
	commit; 

	--- B ---	
	begin transaction 	  
	-------------------------- t1 --------------------
          	INSERT into SUBJECT values('����','����������� ���������� ���������������� �  ���������','����');   
          commit; 
	-------------------------- t2 --------------------

delete SUBJECT where SUBJECT = '����';

/* ex_7 */
-- A ---
set transaction isolation level SERIALIZABLE 
	begin transaction 
		delete SUBJECT where SUBJECT = '����';
		INSERT into SUBJECT values('����', '����������� ���������� ���������������� �  ���������', '����');
        update SUBJECT set SUBJECT_NAME = '����������� ���������� ���������������� �  INTERNET' where  SUBJECT = '����';
	    select SUBJECT_NAME,PULPIT from SUBJECT where PULPIT = '����';
	-------------------------- t1 -----------------
	 select SUBJECT_NAME,PULPIT from SUBJECT where PULPIT = '����';
	-------------------------- t2 ------------------ 
	commit; 	

--- B ---	
	begin transaction 	  
		delete SUBJECT where SUBJECT = '����';
		INSERT into SUBJECT values('����','����������� ���������� ���������������� �  ���������','����');
        update SUBJECT set SUBJECT_NAME = '����������� ���������� ���������������� �  INTERNET' where  SUBJECT = '����';
	    select SUBJECT_NAME from SUBJECT where PULPIT = '����';
     -------------------------- t1 --------------------
     commit; 
     select SUBJECT_NAME,PULPIT from SUBJECT where PULPIT = '����';
     -------------------------- t2 --------------------
	 		
	delete SUBJECT where SUBJECT = '����';

/* ex_8 */
delete SUBJECT where SUBJECT = '����';

begin tran
		INSERT into SUBJECT values('����','����������� ���������� ���������������� �  ���������','����');   ;
		begin tran
		update SUBJECT set SUBJECT_NAME='����' where SUBJECT='����';
		commit
		if @@TRANCOUNT > 0 rollback;

select
		(select count(*) from SUBJECT where SUBJECT='����') '����������',
		(select count(*) from TEACHER inner join SUBJECT on TEACHER.PULPIT = SUBJECT.PULPIT) '�������������'