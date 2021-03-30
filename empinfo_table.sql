use Employee;
create table EmpInfo(
uname varchar(200) ,
id varchar(50) primary key,
email varchar(50),
pass varchar(50),
dob date,
number varchar(10),
gender varchar(10)
);

create table EmpLeave(
id varchar(50) ,
from_date date unique,
to_date date unique,
descrip varchar(200),
type_of_leave  varchar(20),
stat varchar(30),

);
drop table EmpLeave;


select count(*) from EmpLeave where from_date between '2021-03-31' and '2021-03-31' and to_date between '2021-03-31' and '2021-03-31' and id='e0c1ce8516a5470393f847ed1ea8d610';

select * from EmpLeave;
select * from EmpInfo;

select id,cast(from_date as date) as DOB,cast(to_date as date) as DOB2 from EmpLeave;