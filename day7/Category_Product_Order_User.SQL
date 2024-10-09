-->USER PRODUCT ORDER CATEGORY 


-- Create users1 table
CREATE TABLE users1 (
    id BIGINT IDENTITY PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    username VARCHAR(25) NOT NULL,
    email VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20),
    dob DATETIME,
    password_hash VARCHAR(250),
    about TEXT
);

-- Add unique constraints and indexes
ALTER TABLE users1
ADD CONSTRAINT uq_username UNIQUE (username);

ALTER TABLE users1
ADD CONSTRAINT uq_email UNIQUE (email);

CREATE INDEX ix_phone ON users1(phone_number);

-- Add phone number check constraint
ALTER TABLE users1
ADD CONSTRAINT ck_phone CHECK (LEN(phone_number) BETWEEN 7 AND 20);

-- Add date of birth check constraint
ALTER TABLE users1
ADD CONSTRAINT ck_dob CHECK (dob < GETDATE());

-- Create products table
CREATE TABLE products (
    id BIGINT IDENTITY PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    price DECIMAL(10, 2) NOT NULL CHECK (price > 0),
    stock_quantity INT NOT NULL DEFAULT 0 CHECK (stock_quantity >= 0),
    category_id INT NOT NULL,
    created_at DATETIME2 DEFAULT GETDATE(),
    updated_at DATETIME2 DEFAULT GETDATE()
);

-- Create orders table
CREATE TABLE orders (
    id BIGINT IDENTITY PRIMARY KEY,
    quantity INT NOT NULL,
    product_id BIGINT NOT NULL,
    user_id BIGINT NOT NULL,
    CONSTRAINT fk_orders_product_id FOREIGN KEY (product_id) REFERENCES products(id),
    CONSTRAINT fk_orders_user_id FOREIGN KEY (user_id) REFERENCES users1(id)
);

CREATE TABLE categories (
    id INT PRIMARY KEY IDENTITY,
    name VARCHAR(25) NOT NULL UNIQUE
);

INSERT INTO categories (name)
VALUES 
    ('uncategorised'),
    ('electronic'),
    ('phone');

CREATE TABLE product_categories (
    id BIGINT PRIMARY KEY IDENTITY,
    category_id INT,
    product_id BIGINT,
    CONSTRAINT fk_ctid FOREIGN KEY (category_id) REFERENCES categories(id),
    CONSTRAINT fk_pid FOREIGN KEY (product_id) REFERENCES products(id)
);


--inner join
select orders.id as order_id,product.id as product_id,products.name
from orders inner join products on orders.product_id = products.id

--LEFT JOIN
select orders.id as order_id,product.id as product_id,orders.quantity,products.name,products.price
from orders left join products on orders.product_id = products.id

--RIGHT JOIN
select orders.id as order_id,product.id as product_id,orders.quantity,products.name,products.price
from orders right join products on orders.product_id = products.id


select orders.id as order_id,product.id as product_id,users1.first_name
from orders right join products on orders.product_id = products.id
inner join users on orders.user_id=users1.id