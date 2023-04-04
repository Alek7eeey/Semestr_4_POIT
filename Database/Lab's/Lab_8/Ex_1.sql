use UNIVER;

/* ex_1 */

Create VIEW[�������������]
as select GENDER[���], PULPIT[�������], TEACHER[���], TEACHER_NAME[���]
	from TEACHER;

drop view[�������������];
select * from �������������;

/* ex_2 */

Create VIEW[����������_������]
as select FACULTY_NAME[���������], COUNT(PULPIT)[���������� ������]
		from FACULTY inner join PULPIT
		on FACULTY.FACULTY = PULPIT.FACULTY 
		group by FACULTY_NAME;

drop view[����������_������];
select * from ����������_������;

/* ex_3 */

create VIEW[���������]
as select AUDITORIUM[�����_���������], AUDITORIUM_TYPE[��������]
from AUDITORIUM 
where AUDITORIUM.AUDITORIUM_TYPE like '��%'

drop view[���������];
select * from ���������;


/* ex_4 */
create VIEW ����������_���������(�����_���������,��������)
as select AUDITORIUM, AUDITORIUM_TYPE
from AUDITORIUM 
where AUDITORIUM.AUDITORIUM_TYPE like '��%' WITH CHECK OPTION

insert ����������_��������� values('934-1', '��');

drop view[����������_���������];
select * from ����������_���������;

/* ex_5 */
create VIEW ����������(���, ������������_����������, ���_�������)
as select TOP 100 SUBJECT, SUBJECT_NAME, PULPIT
from SUBJECT order by SUBJECT.SUBJECT_NAME

drop view[����������];
select * from ����������;

/* ex_6 */

ALTER VIEW [����������_������] with SCHEMABINDING
as select		fclt.FACULTY_NAME		[���������],
				count(plpt.PULPIT)		[����������_������]
				from dbo.FACULTY fclt inner join dbo.PULPIT plpt
				on fclt.FACULTY = plpt.FACULTY 
				group by FACULTY_NAME;


drop view[����������_������];	
select * from ����������_������;