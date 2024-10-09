-->STUDENT - Basic student details
-->SUBJECT - Name, Code
-->MARKS - ExamId, Subject, Mark, StudentId
-->EXAM - MIn Mark, Max Mark

CREATE TABLE STUDENT (
    StudentId BIGINT PRIMARY KEY IDENTITY,
    StudentName VARCHAR(50) NOT NULL,
    Email varchar(20) NOT NULL
);

CREATE TABLE SUBJECT (
    SubjectId BIGINT PRIMARY KEY IDENTITY,
    SubjectName VARCHAR(50) NOT NULL,
    SubjectCode VARCHAR(10) NOT NULL
);

CREATE TABLE EXAM (
    ExamId BIGINT PRIMARY KEY IDENTITY,
    ExamName VARCHAR(20) NOT NULL,
    MinMark INT NOT NULL,
    MaxMark INT NOT NULL
);

CREATE TABLE MARKS (
    MarkId BIGINT PRIMARY KEY IDENTITY,
    ExamId BIGINT,
    SubjectId BIGINT,
    StudentId BIGINT,
    Mark INT NOT NULL,
    CONSTRAINT FK_ExamId FOREIGN KEY (ExamId) REFERENCES EXAM(ExamId),
    CONSTRAINT FK_SubjectId FOREIGN KEY (SubjectId) REFERENCES SUBJECT(SubjectId),
    CONSTRAINT FK_StudentId FOREIGN KEY (StudentId) REFERENCES STUDENT(StudentId)
);

INSERT INTO STUDENT (StudentName, Email)
VALUES 
('John Doe', 'john@example.com'),
('Jane Smith', 'jane@example.com'),
('Mike Johnson', 'mike@example.com');

INSERT INTO SUBJECT (SubjectName, SubjectCode)
VALUES 
('Mathematics', 'MATH101'),
('Physics', 'PHY101'),
('Chemistry', 'CHEM101');

INSERT INTO EXAM (ExamName, MinMark, MaxMark)
VALUES 
('Mid Term', 0, 100),
('Final Exam', 0, 100),
('Quiz', 0, 50);

select * from student; 

SELECT * FROM EXAM;

select * from subject;

select * from marks;

INSERT INTO MARKS (ExamId, SubjectId, StudentId, Mark)
VALUES 
(1, 1, 1, 85),  -- John Doe, Mathematics, Mid Term, scored 85
(1, 2, 2, 70),  -- Jane Smith, Physics, Mid Term, scored 70
(2, 3, 3, 95),  -- Mike Johnson, Chemistry, Final Exam, scored 95
(3, 1, 1, 45),  -- John Doe, Mathematics, Quiz, scored 45
(2, 2, 2, 88);  -- Jane Smith, Physics, Final Exam, scored 88


-->From mark table display the details of students
select student.StudentId,student.StudentName,student.Email
from marks
inner join student on marks.StudentId=student.StudentId

-->subject name is given,fetch all the marks of student
SELECT 
    student.StudentId, 
    student.StudentName, 
    subject.SubjectName, 
    marks.Mark
FROM 
     marks
INNER JOIN 
     student ON marks.StudentId = student.StudentId
INNER JOIN 
     subject ON marks.SubjectId = subject.SubjectId
WHERE 
    subject.SubjectName = 'chemistry';  

-->student id is given fetch all the exams attended by the student along with the student details
SELECT 
    student.StudentId, 
    student.StudentName, 
    student.Email, 
    exam.ExamId, 
    exam.ExamName, 
    marks.Mark
FROM 
     marks
INNER JOIN 
     student ON marks.StudentId = student.StudentId 
INNER JOIN 
     exam ON marks.ExamId = exam.ExamId 
INNER JOIN 
     subject ON marks.SubjectId = subject.SubjectId 
WHERE 
    subject.SubjectId = 1;  