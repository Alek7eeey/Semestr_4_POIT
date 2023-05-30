use UNIVER;

-- Ex_1 --

--DROP TABLE TR_AUDIT;

CREATE TABLE TR_AUDIT
(
ID int identity,
STMT varchar(20) check (STMT in ('INS','DEL','UPD')),
TRNAME varchar(50),
CC varchar(800)
)

--DROP TRIGGER TR_TEACHER_INS;

go
CREATE TRIGGER TR_TEACHER_INS on TEACHER after INSERT as
insert into TR_AUDIT values ('INS','TR_TEACHER_INS','�������������:' + rtrim((SELECT TEACHER from INSERTED)) + 
													'. ���:' + rtrim((SELECT TEACHER_NAME from INSERTED)) + 
													'. ���:' + rtrim((SELECT GENDER from INSERTED)) + 
													'. �������: ' + rtrim((SELECT PULPIT from INSERTED)));

INSERT into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT)
VALUES ('���','��������� ������� ����������','�','����')

select * from TR_AUDIT


--Ex_2--

--DROP TRIGGER TR_TEACHER_DEL;

go
CREATE TRIGGER TR_TEACHER_DEL on TEACHER after DELETE as
insert into TR_AUDIT values ('DEL','TR_TEACHER_INS','�������������:' + rtrim((SELECT TEACHER from DELETED)) + 
													'. ���:' + rtrim((SELECT TEACHER_NAME from DELETED)) + 
													'. ���:' + rtrim((SELECT GENDER from DELETED)) + 
													'. �������: ' + rtrim((SELECT PULPIT from DELETED)));
DELETE FROM TEACHER where TEACHER = '���';
select * from TR_AUDIT

--Ex_3--

--DROP TRIGGER TR_TEACHER_UPD;

go
CREATE TRIGGER TR_TEACHER_UPD on TEACHER after UPDATE as
insert into TR_AUDIT values ('UPD','TR_TEACHER_INS','�������������:' + rtrim((SELECT TEACHER from INSERTED)) + 
													'. ���:' + rtrim((SELECT TEACHER_NAME from INSERTED)) + 
													'. ���:' + rtrim((SELECT GENDER from INSERTED)) + 
													'. �������: ' + rtrim((SELECT PULPIT from INSERTED)));

UPDATE TEACHER SET PULPIT = '������' where TEACHER = '���';
select * from TR_AUDIT

--Ex_4--

--DROP TRIGGER TR_TEACHER;

go
create trigger TR_TEACHER  on TEACHER after INSERT, DELETE, UPDATE  
as 
declare @ins int = (select count(*) from inserted),
         @del int = (select count(*) from deleted); 
if  @ins > 0 and  @del = 0  
begin 
     print '�������: INSERT';
     insert into TR_AUDIT values ('INS','TR_TEACHER_INS','�������������:' + rtrim((SELECT TEACHER from INSERTED)) + 
													'. ���:' + rtrim((SELECT TEACHER_NAME from INSERTED)) + 
													'. ���:' + rtrim((SELECT GENDER from INSERTED)) + 
													'. �������: ' + rtrim((SELECT PULPIT from INSERTED)));
end; 
else		  	 
if @ins = 0 and  @del > 0  
begin 
    print '�������: DELETE';
   insert into TR_AUDIT values ('DEL','TR_TEACHER_INS','�������������:' + rtrim((SELECT TEACHER from DELETED)) + 
													'. ���:' + rtrim((SELECT TEACHER_NAME from DELETED)) + 
													'. ���:' + rtrim((SELECT GENDER from DELETED)) + 
													'. �������: ' + rtrim((SELECT PULPIT from DELETED)));
end; 
else	  
if @ins > 0 and  @del > 0  
begin 
    print '�������: UPDATE'; 
   insert into TR_AUDIT values ('UPD','TR_TEACHER_INS','�������������:' + rtrim((SELECT TEACHER from INSERTED)) + 
													'. ���:' + rtrim((SELECT TEACHER_NAME from INSERTED)) + 
													'. ���:' + rtrim((SELECT GENDER from INSERTED)) + 
													'. �������: ' + rtrim((SELECT PULPIT from INSERTED)));
end;  
return;  

DELETE FROM TEACHER where TEACHER = '���';
INSERT into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT) VALUES ('���','��������� ������� ����������','�','������')
UPDATE TEACHER SET PULPIT = '����' where TEACHER = '���';

select * from TR_AUDIT

--Ex_5--
alter table TEACHER  add constraint 
PULPIT_LEN  check(len(PULPIT) <=8)

go UPDATE TEACHER SET PULPIT = '����������������' where TEACHER = '���';

alter table TEACHER  drop constraint PULPIT_LEN;

-- Ex_6 --

--DROP TRIGGER TR_TEACHER_DEL1;
--DROP TRIGGER TR_TEACHER_DEL2;
--DROP TRIGGER TR_TEACHER_DEL3;

go
CREATE TRIGGER TR_TEACHER_DEL1 on TEACHER after DELETE as
insert into TR_AUDIT values ('DEL','TR_TEACHER_INS','�������������:' + rtrim((SELECT TEACHER from DELETED)) + 
													'. ���:' + rtrim((SELECT TEACHER_NAME from DELETED)) + 
													'. ���:' + rtrim((SELECT GENDER from DELETED)) + 
													'. �������: ' + rtrim((SELECT PULPIT from DELETED)));
print('������ TR_TEACHER_DEL1');
go
CREATE TRIGGER TR_TEACHER_DEL2 on TEACHER after DELETE as
insert into TR_AUDIT values ('DEL','TR_TEACHER_INS','�������������:' + rtrim((SELECT TEACHER from DELETED)) + 
													'. ���:' + rtrim((SELECT TEACHER_NAME from DELETED)) + 
													'. ���:' + rtrim((SELECT GENDER from DELETED)) + 
													'. �������: ' + rtrim((SELECT PULPIT from DELETED)));
print('������ TR_TEACHER_DEL2');
go
CREATE TRIGGER TR_TEACHER_DEL3 on TEACHER after DELETE as
insert into TR_AUDIT values ('DEL','TR_TEACHER_INS','�������������:' + rtrim((SELECT TEACHER from DELETED)) + 
													'. ���:' + rtrim((SELECT TEACHER_NAME from DELETED)) + 
													'. ���:' + rtrim((SELECT GENDER from DELETED)) + 
													'. �������: ' + rtrim((SELECT PULPIT from DELETED)));
print('������ TR_TEACHER_DEL3');

go    
select t.name, e.type_desc 
         from sys.triggers  t join  sys.trigger_events e  
                  on t.object_id = e.object_id  
                            where OBJECT_NAME(t.parent_id) = 'TEACHER' and 
	                                                                        e.type_desc = 'DELETE' ;  

exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', 
	                        @order = 'First', @stmttype = 'DELETE';

exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', 
	                        @order = 'Last', @stmttype = 'DELETE';

--DELETE FROM TEACHER where TEACHER = '���';
--INSERT into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT) VALUES ('���','��������� ������� ����������','�','����')

-- Ex_7 --

--DROP TRIGGER TEACHER_TRAN;

go
create trigger TEACHER_TRAN on TEACHER after INSERT, DELETE, UPDATE  
as 
declare @count int = (select  count(*) from TEACHER);
if (@count >= 9)
	begin
		raiserror('���������� �������������� �� ������ 9!',10,1);
		rollback;
	end;
return;

INSERT into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT) VALUES ('���','��������� ������� ����������','�','����')

-- Ex_8 --

--DROP TRIGGER FACULTY_INSTEAD_OF;

go 
create trigger FACULTY_INSTEAD_OF on FACULTY instead of DELETE as raiserror('�������� ���������',10,1);
return;

delete from FACULTY where FACULTY ='��';
select * from FACULTY

--DROP TRIGGER TR_TEACHER_INS;
--DROP TRIGGER TR_TEACHER_DEL;
--DROP TRIGGER TR_TEACHER_UPD;
--DROP TRIGGER TR_TEACHER;
--DROP TRIGGER TR_TEACHER_DEL1;
--DROP TRIGGER TR_TEACHER_DEL2;
--DROP TRIGGER TR_TEACHER_DEL3;
--DROP TRIGGER FACULTY_INSTEAD_OF;

-- Ex_9 --
go	
create  trigger DDL_UNIVER on database for DDL_DATABASE_LEVEL_EVENTS  
as   
declare @t varchar(50) =  EVENTDATA().value('(/EVENT_INS-TANCE/EventType)[1]', 'varchar(50)');
declare @t1 varchar(50) = EVENTDATA().value('(/EVENT_INS-TANCE/ObjectName)[1]', 'varchar(50)');
declare @t2 varchar(50) = EVENTDATA().value('(/EVENT_INS-TANCE/ObjectType)[1]', 'varchar(50)'); 
       print '��� �������: '+@t;
       print '��� �������: '+@t1;
       print '��� �������: '+@t2;
       raiserror( N'�������� � ��������� ��������� ', 16, 1);  
       rollback;    

--DROP TRIGGER DDL_UNIVER;

CREATE TABLE BUBUB
(
ID int identity(1,1)
)