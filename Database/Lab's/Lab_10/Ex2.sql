use KAD_MyBase;
--use TEMPDB;

/* ex_1 */
exec sp_helpindex '������_��������'
exec sp_helpindex '������_�������'
exec sp_helpindex '������' 

CREATE CLUSTERED INDEX #index1 on ������_��������(����� asc);
--DROP INDEX #index1 on ������_��������
--
SELECT * FROM ������_�������� where ����� between 150 and 2000 order by �����;
checkpoint;  
DBCC DROPCLEANBUFFERS;  

/* ex_2 */
CREATE INDEX #index2 on ������_��������(�����,�����_������);
--DROP INDEX #index2 on ������_��������
--
SELECT * FROM ������_�������� where ����� between 150 and 2000 order by �����;
checkpoint;  
DBCC DROPCLEANBUFFERS;  

/* ex_3 */
CREATE INDEX #index3 on ������_��������(�����) INCLUDE(�����_������)
--DROP INDEX #index3 on ������_��������
--
SELECT * FROM ������_�������� where ����� between 150 and 2000 order by �����;
checkpoint;  
DBCC DROPCLEANBUFFERS;  

/* ex_4 */
CREATE INDEX #index4 on ������_��������(�����) where(����� >= 150 and ����� <= 2000)
--DROP INDEX #index4 on ������_��������
--
SELECT * FROM ������_�������� where ����� between 150 and 2000 order by �����;
checkpoint;  
DBCC DROPCLEANBUFFERS;  