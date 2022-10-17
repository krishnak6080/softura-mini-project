use BookMyFlight
go

create table UserData
(
	firstname varchar(20) not null,
	lastname varchar(20),
	email varchar(25) not null,
	phonenumber int not null,
	password varchar(25) not null
	constraint PK_email primary key(email)
)
select * from UserData
alter table UserData 
add constraint chk_email check(email like '%_@__%.__%')
alter table UserData
add constraint chk_phonenumber check(phonenumber not like '%[^0-9]%')

insert into UserData(firstname,lastname,email,phonenumber,password)
values('tom','eric','tom@gmail.com','555555555','tomeric')

select * from UserData


create table FlightBooking
(
    passengername varchar(20) not null,
	departure varchar(20) not null,
	arrival varchar(20) not null,
	NoOfPassenger int not null,
	class varchar(20),
	travelDate DATE not null,
	arrivalTime TIME(3) not null
	constraint PK_passengername primary key(passengername)
)
select * from FlightBooking

create table FlightDetail
(
FromWhere varchar(20) not null,
WhereTo varchar(20),
Class varchar(20),
DepartureDate date,
AvailableSeates int,
Price int
constraint PK_FromWhere primary key(FromWhere)
)
insert into FlightDetail(FromWhere,WhereTo,Class,DepartureDate,AvailableSeates,Price)
values('Belgium','London','Economy','2022-11-08','40','40000')

select * from FlightDetail

insert into FlightDetail(FromWhere,WhereTo,Class,DepartureDate,AvailableSeates,Price)
values('Russia','Canada','Business','2022-11-06','20','70000')

insert into FlightDetail(FromWhere,WhereTo,Class,DepartureDate,AvailableSeates,Price)
values('switzerland','NewYork','First','2022-11-09','10','90000')


create table AvailableFlight
(
sno int not null,
FromWhere varchar(20),
WhereTo varchar(20),
Class varchar(20),
DepartureDate date,
AvailableSeates int,
Price int
constraint PK_sno primary key(sno)
)
insert into AvailableFlight(sno,FromWhere,WhereTo,Class,DepartureDate,AvailableSeates,Price)
values('1','Chennai','London','Economy','2022-11-08','40','40000')

insert into AvailableFlight(sno,FromWhere,WhereTo,Class,DepartureDate,AvailableSeates,Price)
values('2','Chennai','Canada','Business','2022-11-06','20','70000')

insert into AvailableFlight(sno,FromWhere,WhereTo,Class,DepartureDate,AvailableSeates,Price)
values('3','Chennai','NewYork','First','2022-11-09','10','90000')

select * from AvailableFlight

create table Payment
(
    Pid int not null,
    CardNumber int not null,
	ExpDate date,
	cvv int not null,
	NameonCard varchar(20) not null
	constraint PK_Pid primary key (Pid),
)
select * from Payment