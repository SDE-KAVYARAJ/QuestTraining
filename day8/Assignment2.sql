/*
You are tasked with creating a Medical Store Management System for a local pharmacy. The system needs to track various aspects such as medications, suppliers, sales, inventory, and customers. The system should also provide functionalities to manage inventory, process customer purchases, and generate reports. Your database should be well-structured, containing several tables such as medications, suppliers, sales, inventory, and customers.
Here are the requirements and some common query operations that the medical store owner needs:
Entities and Tables:
Medications:
Stores details about the drugs or medical products available in the store.
Fields: id, name, category, price, expiry_date, supplier_id, stock_quantity.
Suppliers:
Stores information about the suppliers who supply medications.
Fields: id, name, contact_person, phone, email, address.
Customers:
Stores details about the customers who purchase medications.
Fields: id, name, phone, email, address.
Sales:
Stores information about the sales transactions that take place.
Fields: id, customer_id, medication_id, quantity, sale_date, total_price.
Inventory:
Tracks the medications and their stock levels.
Fields: id, medication_id, supplier_id, stock_in, stock_out, date_added.
Application-Level Questions:
1. Insert Operation (Basic Data Entry):
Insert details about new medications into the medications table.
Insert information about new suppliers into the suppliers table.
Insert a new customer record into the customers table.
*/

CREATE TABLE Medications (
    id INT PRIMARY KEY,
    name VARCHAR(100),
    category VARCHAR(50),
    price DECIMAL(5,2),
    expiry_date DATE,
    supplier_id INT,
    stock_quantity INT,
    FOREIGN KEY (supplier_id) REFERENCES Suppliers(id)
);

CREATE TABLE Suppliers (
    id INT PRIMARY KEY,
    name VARCHAR(100),
    contact_person VARCHAR(100),
    phone VARCHAR(15),
    email VARCHAR(100),
    address TEXT
);

CREATE TABLE Customers (
    id INT PRIMARY KEY,
    name VARCHAR(100),
    phone VARCHAR(15),
    email VARCHAR(100),
    address TEXT
);

CREATE TABLE Sales (
    id INT PRIMARY KEY,
    customer_id INT,
    medication_id INT,
    quantity INT,
    sale_date DATE,
    total_price DECIMAL(10,2),
    FOREIGN KEY (customer_id) REFERENCES Customers(id),
    FOREIGN KEY (medication_id) REFERENCES Medications(id)
);

CREATE TABLE Inventory (
    id INT PRIMARY KEY,
    medication_id INT,
    supplier_id INT,
    stock_in INT,
    stock_out INT,
    date_added DATE,
    FOREIGN KEY (medication_id) REFERENCES Medications(id),
    FOREIGN KEY (supplier_id) REFERENCES Suppliers(id)
);

--Write an INSERT query to add a new medication, "Paracetamol", to the medications table with a price of 2.50 per unit and a stock quantity of 100.

CREATE PROCEDURE InsertMedication
    @med_name NVARCHAR(100),
    @med_category NVARCHAR(50),
    @med_price DECIMAL(5,2),
    @med_expiry DATE,
    @med_supplier_id INT,
    @med_stock_quantity INT
AS
BEGIN
    INSERT INTO Medications (name, category, price, expiry_date, supplier_id, stock_quantity)
    VALUES (@med_name, @med_category, @med_price, @med_expiry, @med_supplier_id, @med_stock_quantity);
END;

EXEC InsertMedication 'Paracetamol', 'Pain Relief', 2.50, '2024-12-31', 1, 100;


--Write an INSERT query to add a new supplier "HealthCorp" into the suppliers table.
CREATE PROCEDURE InsertSupplier
    @supp_name NVARCHAR(100),
    @supp_contact_person NVARCHAR(100),
    @supp_phone NVARCHAR(15),
    @supp_email NVARCHAR(100),
    @supp_address NVARCHAR(255)
AS
BEGIN
    INSERT INTO Suppliers (name, contact_person, phone, email, address)
    VALUES (@supp_name, @supp_contact_person, @supp_phone, @supp_email, @supp_address);
END;

EXEC InsertSupplier 'HealthCorp', 'Dr. Smith', '1234567890', 'dr.smith@healthcorp.com', '1234 Health St.';

--Write an INSERT query to register a new customer with the name "John Doe" and contact details in the customers table.
CREATE PROCEDURE InsertCustomer
    @cust_name NVARCHAR(100),
    @cust_phone NVARCHAR(15),
    @cust_email NVARCHAR(100),
    @cust_address NVARCHAR(255)
AS
BEGIN
    INSERT INTO Customers (name, phone, email, address)
    VALUES (@cust_name, @cust_phone, @cust_email, @cust_address);
END;

EXEC InsertCustomer 'John Doe', '9876543210', 'johndoe@example.com', '4567 Customer Ave.';

--Update Operation (Stock Management):
--Update the stock level of medications as new shipments come in or after a sale.
CREATE PROCEDURE UpdateMedicationStock
    @med_id INT,
    @quantity INT
AS
BEGIN
    UPDATE Medications
    SET stock_quantity = stock_quantity + @quantity
    WHERE id = @med_id;
END;

EXEC UpdateMedicationStock 1, 50;  

-->Sales Transaction (Insert Sale and Update Stock):
CREATE PROCEDURE RecordSale
    @customer_id INT,
    @medication_id INT,
    @quantity INT,
    @sale_date DATE
AS
BEGIN
    DECLARE @price DECIMAL(5,2);
    
    
    SELECT @price = price FROM Medications WHERE id = @medication_id;

    
    INSERT INTO Sales (customer_id, medication_id, quantity, sale_date, total_price)
    VALUES (@customer_id, @medication_id, @quantity, @sale_date, @price * @quantity);

    
    UPDATE Medications
    SET stock_quantity = stock_quantity - @quantity
    WHERE id = @medication_id;
END;

EXEC RecordSale 1, 1, 2, GETDATE();

-->Delete Expired Medications (Procedure for Removing Old Data): This 
CREATE PROCEDURE DeleteExpiredMedications
AS
BEGIN
    DELETE FROM Medications
    WHERE expiry_date < GETDATE();
END;

EXEC DeleteExpiredMedications;

-->join operation
-->List All Medications with Supplier Names:

SELECT m.name AS MedicationName, s.name AS SupplierName
FROM Medications m
JOIN Suppliers s ON m.supplier_id = s.id;

-->Display Sales Data with Medication Name and Customer Name:

SELECT s.sale_date, c.name AS CustomerName, m.name AS MedicationName, s.total_price
FROM Sales s
JOIN Customers c ON s.customer_id = c.id
JOIN Medications m ON s.medication_id = m.id;

-->Select and Filter Operations (Sales Tracking)
-->Retrieve all sales made in the last 30 days
SELECT *
FROM Sales
WHERE sale_date >= DATEADD(DAY, -30, GETDATE());


--Retrieve sales details for a customer named "Alice Smith"
SELECT s.*, m.name AS MedicationName, c.name AS CustomerName
FROM Sales s
JOIN Customers c ON s.customer_id = c.id
JOIN Medications m ON s.medication_id = m.id
WHERE c.name = 'Alice Smith';


-->Retrieve all medications that will expire within the next 60 days
SELECT *
FROM Medications
WHERE expiry_date BETWEEN GETDATE() AND DATEADD(DAY, 60, GETDATE());


-->Aggregate Operations (Reports and Summaries)
-->Calculate the total revenue generated by sales in the month of September
SELECT SUM(total_price) AS TotalRevenue
FROM Sales
WHERE MONTH(sale_date) = 9 AND YEAR(sale_date) = YEAR(GETDATE());

-->Get the total quantity of each medication sold (group by medication)
SELECT m.name AS MedicationName, SUM(s.quantity) AS TotalQuantitySold
FROM Sales s
JOIN Medications m ON s.medication_id = m.id
GROUP BY m.name;


-->Count the total number of customers who have made purchases
SELECT COUNT(DISTINCT customer_id) AS TotalCustomers
FROM Sales;

-->Delete Operations (Removing Old Data)
-->Remove all medications that have expired as of today
DELETE FROM Medications
WHERE expiry_date < GETDATE();


-->Delete a customer who has requested to be removed from the database
DELETE FROM Customers
WHERE id = @customer_id; 

-->Transaction Management (Sales and Stock Update)

CREATE PROCEDURE ProcessSale
    @customer_id INT,
    @medication_id INT,
    @quantity INT,
    @sale_date DATE
AS
BEGIN
    BEGIN TRANSACTION;

    DECLARE @price DECIMAL(5,2);
    DECLARE @current_stock INT;

    SELECT @price = price, @current_stock = stock_quantity
    FROM Medications
    WHERE id = @medication_id;

    
    IF @current_stock >= @quantity
    BEGIN
        
        INSERT INTO Sales (customer_id, medication_id, quantity, sale_date, total_price)
        VALUES (@customer_id, @medication_id, @quantity, @sale_date, @price * @quantity);

        
        UPDATE Medications
        SET stock_quantity = stock_quantity - @quantity
        WHERE id = @medication_id;

        COMMIT TRANSACTION;
    END
END;
