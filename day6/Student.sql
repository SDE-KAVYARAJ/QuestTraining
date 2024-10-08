
CREATE TABLE students (
    id INT PRIMARY KEY,
    name VARCHAR(100),
    class VARCHAR(50),
    email VARCHAR(100)
);

INSERT INTO students (id, name, class, email) VALUES 
(1, 'John Doe', '10th Grade', 'john.doe@example.com'),
(2, 'Jane Smith', '9th Grade', 'jane.smith@example.com'),
(3, 'Mike Johnson', '11th Grade', 'mike.johnson@example.com'),
(4, 'Emily Davis', '10th Grade', 'emily.davis@example.com');

select * from students;

select id,name,email from students;

select id,name from students where id=1;
select id,name from students where email='mike.johnson@example.com';

select id,name,class from students where id>=1 and id<=4;
select id,name,class from students where id between 1 and 3;

select id,name,class from students where id=1 or id=3;
select id,name,class from students where id in (1,3);


select id,name,class from students order by name asc;
select id,name,class from students order by name desc;

select id,name as full_name,class from students;

select class,count(id) from students group by class;
select class,count(id) as count_of_students from students group by class;


select class,count(id) as [count] from students group by class having count(id)<5;

select top 3 id,name,class from students;

select id,name,class from students
order by id
offset 3 rows
fetch next 2 rows only;

select len('Hello');

select name,len(name) as name_length from students;

select count(id) as total_students from students;
select sum(id) as sum_of_id from students;
select avg(id) as avr_of_id from students;
select min(id) as min_of_id from students;
select max(id) as max_of_id from students;