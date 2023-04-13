use Consultation;

create table consultation
(
	id int primary key identity(1,1),
	name varchar(200) not null,
	subject varchar(200) not null,
	time varchar(50) not null,
	date date not null,
);

insert consultation (name, subject, time, date)
VALUES
('����� �.�', '���', '11:30', '2023-09-11'),
('���������� �.�.', '���', '19:00', '2023-05-01'),
('����� �.�.', '���', '13:00', '2023-07-09');