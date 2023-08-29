
----------------------------------------------
-- Create table Discount
----------------------------------------------
CREATE TABLE Coupon
(
	Id SERIAL PRIMARY KEY NOT NULL,
	ProductName VARCHAR(24) NOT NULL,
	Description TEXT,
	Amount INT
)

----------------------------------------------
-- Insert to Discount
----------------------------------------------

INSERT INTO Coupon (ProductName, Description, Amount)
VALUES ('IPhone X', 'IPhone Disocunt', 150);

INSERT INTO Coupon (ProductName, Description, Amount)
VALUES ('Samsung 10', 'Samsung Disocunt', 100);