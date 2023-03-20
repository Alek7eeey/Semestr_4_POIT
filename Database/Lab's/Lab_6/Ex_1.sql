use UNIVER;

/* ex_1_ex_2 */
select AUDITORIUM.AUDITORIUM_TYPE, 
MAX(AUDITORIUM_CAPACITY)[������������ �����������],
MIN(AUDITORIUM_CAPACITY)[ ����������� ����������],
AVG(AUDITORIUM_CAPACITY)[������� �����������],
SUM(AUDITORIUM_CAPACITY)[��������� ����������� ���������],
COUNT(AUDITORIUM_CAPACITY)[���������� ���������]
from AUDITORIUM inner join AUDITORIUM_TYPE
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
group by AUDITORIUM.AUDITORIUM_TYPE

/* ex_3 */
select *
from (select case
                 when (PROGRESS.NOTE in (6, 7)) then '6-7'
                 when (PROGRESS.NOTE in (8, 9)) then '8-9'
                 when (PROGRESS.NOTE in (4, 5)) then '4-5'
                 when (PROGRESS.NOTE = 10) then '10'
				 end [NOTE],
				 count(*)[����������]
		from PROGRESS
		group by case
				   when (PROGRESS.NOTE in (6, 7)) then '6-7'
                   when (PROGRESS.NOTE in (8, 9)) then '8-9'
                   when (PROGRESS.NOTE in (4, 5)) then '4-5'
                   when (PROGRESS.NOTE = 10) then '10'
                   end
     ) as a 

order by case a.NOTE
			   when '6-7' then 3
               when '8-9' then 2
               when '4-5' then 4
               when '10' then 1
               end

/* ex_4 */
select a.FACULTY,
       G.PROFESSION,
	   G.IDGROUP,
       round(avg(cast(NOTE AS float(4))), 2) as [������� ������]
from FACULTY a
         join GROUPS G on a.FACULTY = G.FACULTY
         join STUDENT S on G.IDGROUP = S.IDGROUP
         join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST, G.IDGROUP
order by [������� ������] desc

/* ex_5 */
select a.FACULTY,
       G.PROFESSION,
	   G.IDGROUP,
	   P.SUBJECT,
       round(avg(cast(NOTE AS float(4))), 2) as [������� ������]
from FACULTY a
         join GROUPS G on a.FACULTY = G.FACULTY
         join STUDENT S on G.IDGROUP = S.IDGROUP
         join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT
where P.SUBJECT like '����' or P.SUBJECT like '����'
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST, P.SUBJECT, G.IDGROUP
order by [������� ������] desc

/* ex_6 */
SELECT GROUPS.PROFESSION, PROGRESS.SUBJECT,FACULTY.FACULTY, AVG(PROGRESS.NOTE) AS [������� ������]
FROM GROUPS
INNER JOIN FACULTY ON GROUPS.FACULTY = FACULTY.FACULTY
INNER JOIN STUDENT ON GROUPS.IDGROUP = STUDENT.IDGROUP
INNER JOIN PROGRESS ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE FACULTY.FACULTY like '����'
GROUP BY GROUPS.PROFESSION, PROGRESS.SUBJECT, FACULTY.FACULTY

/* ex_7 */
select PROGRESS.[SUBJECT], 
	   count(PROGRESS.NOTE) as [���������� 8, 9]
from
PROGRESS 

group by PROGRESS.[SUBJECT], PROGRESS.NOTE
having PROGRESS.NOTE in (8,9)
