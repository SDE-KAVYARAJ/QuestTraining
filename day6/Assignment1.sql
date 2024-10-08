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



