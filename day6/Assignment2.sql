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







