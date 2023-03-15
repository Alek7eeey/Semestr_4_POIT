create database TableOfLesson;

use TableOfLesson;
create table Lessons
(
nameOfLesson text,
timeOfLesson time,
dayOfLesson text,
nameOfAuditory text
);

create table Teacher
(
FIO text,
leadSubject text,
countLessonOfSubject int,
countOfStudents int
);

insert Lessons(nameOfLesson, timeOfLesson, dayOfLesson, nameOfAuditory)
values
('ОАиП', '13:30', 'Понедельник', '106-1'),
('КЯР', '10:30', 'Среда', '233-4'),
('ПСП', '06:50', 'Суббота', '123-1'),
('ООП', '17:50', 'Понедельник', '340-1'),
('ТРПИ', '17:12', 'Вторник', '402-3');

insert Teacher(FIO, leadSubject, countLessonOfSubject, countOfStudents)
values
('Пацей Н.В.', 'ООП', 8, 123),
('Барковский Е.В.', 'КЯР', 3, 55),
('Белодед Н.И.', 'ОАиП', 6, 333),
('Шиман Д.В.', 'ПСП', 3, 333),
('Кудлацкая М.Ф.', 'ТРПИ', 2, 55);
