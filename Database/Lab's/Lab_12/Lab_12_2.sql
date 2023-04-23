use KAD_MyBase;

/* *********************************************** */
begin try
	begin tran
		delete ������_�������� where ��������_����_������� = '������ 6';
		insert into ������_�������� values('8','������ 6','40%',522, '2018-06-01', '2033-09-10');
		update ������_�������� set ����� = '300' where �����_������= 8;
	commit tran;
end try

begin catch
	print '������: ' + cast(error_number() as varchar(5)) + ' ' + error_message()
	if @@TRANCOUNT > 0 rollback tran;
end catch;

/* *********************************************** */
DECLARE @savepoint varchar(30);
begin try
	begin tran
		delete ������_�������� where ��������_����_������� = '������ 6';									
		set @savepoint = 'save1'; save transaction @savepoint;

		insert into ������_�������� values('8','������ 6','40%',522, '2018-06-01', '2033-09-10');						
		set @savepoint = 'save2'; save transaction @savepoint;

		update ������_�������� set ����� = '300' where �����_������= 8;		
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

/* *********************************************** */

-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
	-------------------------- t1 ------------------
	select @@SPID 'SID', 'insert ������_��������' '���������', * from ������_��������
	                                                                where ������ = '40%';
																	             
	select @@SPID 'SID', 'update ������_��������'  '���������',  �����_������, 
                      �����, ������ from ������_��������   where  �����=15000;
	commit; 
	-------------------------- t2 -----------------

--- B --	
	begin transaction 
	select @@SPID 'SID';
	insert into ������_�������� values('9','������ 15','30%',5298, '2015-05-01', '2083-03-12');   
	update ������_�������� set ����� = '300' where �����_������= 9;	
	-------------------------- t1 --------------------
	-------------------------- t2 --------------------
	rollback;

	delete ������_�������� where �����_������ = 9;

/* *********************************************** */

-- A ---
    set transaction isolation level READ COMMITTED 
	begin transaction 
	select count(*) from ������_�������� where ������ = '40%';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select @@SPID 'SID', 'update ������_��������'  '���������',  �����_������, 
                      �����, ������ from ������_��������   where  �����=15000;
	commit; 

	--- B ---	
	begin transaction 	

	-------------------------- t1 --------------------
    select @@SPID 'SID' update ������_�������� set ����� = '300' where ����� = 15000;

      commit; 
	-------------------------- t2 --------------------	
