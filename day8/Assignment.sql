-->bank application
CREATE TABLE customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1), 
    name VARCHAR(100) NOT NULL,                 
    email VARCHAR(100) NOT NULL UNIQUE,         
    address VARCHAR(255) NOT NULL,              
    phone_number VARCHAR(15) NOT NULL        
);

CREATE TABLE accounts (
    account_id INT PRIMARY KEY IDENTITY(1,1),
    account_number INT NOT NULL UNIQUE,
    customer_id INT NOT NULL,                     
    account_type VARCHAR(50) NOT NULL,             
    balance DECIMAL(18, 2) 

    CONSTRAINT FK_accounts_customers FOREIGN KEY (customer_id) 
    REFERENCES customers(customer_id)             
);

CREATE TABLE transactions (
    transaction_id INT PRIMARY KEY IDENTITY(1,1), 
    account_id INT NOT NULL,                      
    transaction_type VARCHAR(50) NOT NULL,         
    amount DECIMAL(18, 2) NOT NULL,
    
    CONSTRAINT FK_transactions_accounts FOREIGN KEY (account_id) 
    REFERENCES accounts(account_id)
);

INSERT INTO customers (name, email, address, phone_number)
VALUES 
('Alice Johnson', 'alice.johnson@example.com', '789 Park Ave, New York, NY, 10022', '987678990'),
('Bob Williams', 'bob.williams@example.com', '321 Elm St, Chicago, IL, 60614', '8989898989'),
('Charlie Brown', 'charlie.brown@example.com', '456 Maple St, San Francisco, CA, 94101', '8987667890'),
('Diana Prince', 'diana.prince@example.com', '555 Justice Lane, Themyscira, NY, 12345', '1234567890'),
('Edward Norton', 'edward.norton@example.com', '666 Bruce St, Los Angeles, CA, 90001', '2345678901');

select * from customers

INSERT INTO accounts (account_number, customer_id, account_type, balance)
VALUES
(1001, 1, 'savings', 2500.00),  
(1002, 1, 'current', 1500.00),  
(1003, 2, 'savings', 3200.00), 
(1004, 3, 'current', 4500.00),  
(1005, 4, 'savings', 1500.00),
(1006, 5, 'current', 2000.00);

select * from accounts

INSERT INTO transactions (account_id, transaction_type, amount)
VALUES
(1, 'deposit', 500.00),      
(1, 'withdraw', 200.00),      
(2, 'deposit', 1000.00),    
(3, 'withdraw', 300.00),      
(1, 'transfer', 150.00),     
(3, 'deposit', 500.00), 
(5, 'deposit', 800.00),     
(4, 'withdraw', 400.00),    
(6, 'transfer', 200.00);

select * from transactions

-->update account type
UPDATE accounts
SET account_type = 'savings'
WHERE account_id = 2; 

-->delete an account
DELETE FROM accounts
WHERE account_id = 3;

-->deposit money
UPDATE accounts
SET balance = balance + 500.00
WHERE account_id = 1; 

-->withdraw money
UPDATE accounts
SET balance = balance - 300.00
WHERE account_id = 1;

-->Transfer Money Between Accounts
UPDATE accounts
SET balance = balance - 200.00
WHERE account_id = 1; 

UPDATE accounts
SET balance = balance + 200.00
WHERE account_id = 2;

-->View All Transactions
SELECT 
    transactions.transaction_id,
    transactions.transaction_type,
    transactions.amount,
    accounts.account_number,
    customers.name AS customer_name,
    accounts.account_type,
    accounts.balance
FROM 
    transactions 
INNER JOIN 
    accounts  ON transactions.account_id = accounts.account_id
INNER JOIN 
    customers ON accounts.customer_id = customers.customer_id;


