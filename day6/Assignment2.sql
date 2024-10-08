--Question: You are tasked with creating a system to track patients and the appointments they make with doctors. Each patient has basic information like their name, age, gender, and contact details, while appointments include the appointment date, time, reason for the visit, and the doctor they will meet.
--Tasks: Create a patients table with the following details:
--id: A unique identifier for each patient (make it an auto-incrementing IDENTITY column).
--first_name: The first name of the patient (cannot be NULL).
--last_name: The last name of the patient (cannot be NULL). gender: The gender of the patient (only 'M', 'F', or 'Other' allowed).
--age: The age of the patient (must be a positive integer and less than 120).
--phone_number: The patient's phone number.
--email: The patient's email address (must be unique).
--created_at: The date and time the patient was registered (default to the current date and time)


CREATE TABLE patients (
    id INT IDENTITY(1,1) PRIMARY KEY,                 
    first_name VARCHAR(100) NOT NULL,                  
    last_name VARCHAR(100) NOT NULL,                   
    gender CHAR(6) CHECK (gender IN ('M', 'F', 'Other')), 
    age INT CHECK (age > 0 AND age < 120),             
    phone_number VARCHAR(15),                      
    email VARCHAR(100) UNIQUE,                         
    created_at DATETIME DEFAULT GETDATE()               
);


--Create an appointments table with the following details:
--id: A unique identifier for each appointment (make it an auto-incrementing IDENTITY column).
--patient_id: The ID of the patient who booked the appointment.
--appointment_date: The date of the appointment (cannot be in the past).
--appointment_time: The time of the appointment.
--reason_for_visit: A description of why the patient is visiting (cannot be NULL).
--doctor_name: The name of the doctor (cannot be NULL).
--created_at: The date and time the appointment was created (default to the current date and time).

CREATE TABLE appointments (
    id INT IDENTITY(1,1) PRIMARY KEY,                    
    patient_id INT NOT NULL,                              
    appointment_date DATE CHECK (appointment_date >= CAST(GETDATE() AS DATE)), 
    appointment_time TIME,                              
    reason_for_visit VARCHAR(255) NOT NULL,              
    doctor_name VARCHAR(100) NOT NULL,                    
    created_at DATETIME DEFAULT GETDATE(),                 
    FOREIGN KEY (patient_id) REFERENCES patients(id)      
);


--Insert data:
--Insert at least 5 patients and 5 appointments into the respective tables. Make sure to follow the constraints for age, appointment_date, reason_for_visit, and doctor_name.

INSERT INTO patients (first_name, last_name, gender, age, phone_number, email)
VALUES 
('John', 'Doe', 'M', 30, '123-456-7890', 'john.doe@example.com'),
('Jane', 'Smith', 'F', 25, '234-567-8901', 'jane.smith@example.com'),
('Emily', 'Johnson', 'F', 40, '345-678-9012', 'emily.johnson@example.com'),
('Michael', 'Brown', 'M', 50, '456-789-0123', 'michael.brown@example.com'),
('Chris', 'Davis', 'Other', 35, '567-890-1234', 'chris.davis@example.com');


INSERT INTO appointments (patient_id, appointment_date, appointment_time, reason_for_visit, doctor_name)
VALUES 
(1, '2024-10-10', '09:00', 'Regular check-up', 'Dr. Wilson'),
(2, '2024-10-12', '11:30', 'Flu symptoms', 'Dr. Smith'),
(3, '2024-10-15', '14:00', 'Follow-up appointment', 'Dr. Brown'),
(4, '2024-10-18', '10:30', 'Blood test', 'Dr. Johnson'),
(5, '2024-10-20', '13:15', 'Consultation', 'Dr. Taylor');

SELECT * FROM patients;

SELECT * FROM appointments;







