drop table users1

create table users1
(id bigint identity,
first_name varchar(50) not null,
last_name varchar(50) not null,
username varchar(25)not null,
email varchar(100) not null,
phone_number varchar(20),
dob datetime,
password_hash varchar(250),
about text
)


alter table users1
add constraint pk_user_id primary key(id);

alter table users1
add constraint uq_username unique (username);

alter table users1
add constraint uq_email unique (email);

create index ix_phone on users1(phone_number)

alter table users1
add constraint ck_phone check(len(phone_number)between 7 and 20)

alter table uers1 
add constraint ck_dob check(dob<getdate())

