--You are working on a database for a school’s student management system. The system contains a table named courses that stores information about the courses offered at the school and the students enrolled in them.
--You have been tasked to generate a report that shows the following information for each course:
--The total number of students enrolled.
--The total fees collected for each course.
--The course with the maximum number of enrollments.
--Write SQL queries to accomplish the following tasks:
--
--1)Find the total number of students enrolled in each course: The result should display the course_name and the total count of students enrolled in that course.
--2)Calculate the total fees collected for each course: The result should display the course_name and the sum of the course_fee collected.
--3)Determine the course with the maximum number of enrollments: Display the course_name and the number of students enrolled for the course with the highest enrollment

CREATE TABLE course_enrollments (
    course_id INT,
    course_name VARCHAR(100),
    course_fee DECIMAL(10, 2),
    student_id INT,
    student_name VARCHAR(100),
    PRIMARY KEY (course_id, student_id)
);

INSERT INTO course_enrollments (course_id, course_name, course_fee, student_id, student_name) VALUES
(1, 'Mathematics', 200.00, 1, 'Alice Johnson'),
(1, 'Mathematics', 200.00, 2, 'Bob Smith'),
(2, 'Physics', 250.00, 3, 'Charlie Brown'),
(2, 'Physics', 250.00, 4, 'David Wilson'),
(3, 'Chemistry', 300.00, 5, 'Eva Green'),
(4, 'Biology', 150.00, 1, 'Alice Johnson'), 
(3, 'Chemistry', 300.00, 3, 'Charlie Brown'),  
(4, 'Biology', 150.00, 2, 'Bob Smith');  

SELECT course_name, COUNT(student_id) AS total_students
FROM course_enrollments
GROUP BY course_name;

SELECT course_name, SUM(course_fee) AS total_fees
FROM course_enrollments
GROUP BY course_name;

SELECT top 1 course_name, COUNT(student_id) AS total_students
FROM course_enrollments
GROUP BY course_name
ORDER BY total_students DESC;



