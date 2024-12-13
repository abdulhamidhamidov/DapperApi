
CREATE TABLE Cars
(
    CarId SERIAL PRIMARY KEY,
    Model VARCHAR(100) NOT NULL,
    Manufacturer VARCHAR(100) NOT NULL,
    Year INT NOT NULL,
    PricePerDay DECIMAL(10, 2) NOT NULL
);


CREATE TABLE Customers
(
    CustomerId SERIAL PRIMARY KEY,
    FullName VARCHAR(150) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Email VARCHAR(150) NOT NULL
);

CREATE TABLE Rentals
(
    RentalId SERIAL PRIMARY KEY,
    CarId INT NOT NULL REFERENCES Cars(CarId),
    CustomerId INT NOT NULL REFERENCES Customers(CustomerId),
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalCost DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Locations
(
    LocationId SERIAL PRIMARY KEY,
    City VARCHAR(100) NOT NULL,
    Address VARCHAR(200) NOT NULL
);

CREATE TABLE CarLocations
(
    Id serial primary key,
    CarId INT NOT NULL REFERENCES Cars(CarId),
    LocationId INT NOT NULL REFERENCES Locations(LocationId)
);

INSERT INTO Cars (Model, Manufacturer, Year, PricePerDay)
VALUES
    ('Model S', 'Tesla', 2023, 120.00),
    ('Civic', 'Honda', 2022, 45.00),
    ('Mustang', 'Ford', 2021, 80.00),
    ('Corolla', 'Toyota', 2020, 50.00),
    ('X5', 'BMW', 2022, 100.00);
INSERT INTO Customers (FullName, Phone, Email)
VALUES
    ('John Doe', '123-456-7890', 'john.doe@example.com'),
    ('Jane Smith', '987-654-3210', 'jane.smith@example.com'),
    ('Alice Johnson', '555-123-4567', 'alice.johnson@example.com'),
    ('Bob Brown', '555-987-6543', 'bob.brown@example.com'),
    ('Charlie Davis', '555-321-9876', 'charlie.davis@example.com');
INSERT INTO Rentals (CarId, CustomerId, StartDate, EndDate, TotalCost)
VALUES
    (1, 1, '2024-01-10', '2024-01-15', 600.00),
    (2, 2, '2024-01-12', '2024-01-14', 135.00),
    (3, 3, '2024-01-05', '2024-01-10', 400.00),
    (4, 4, '2024-01-08', '2024-01-12', 200.00),
    (5, 5, '2024-01-15', '2024-01-18', 300.00);
INSERT INTO Locations (City, Address)
VALUES
    ('New York', '123 5th Ave, New York, NY'),
    ('Los Angeles', '456 Sunset Blvd, Los Angeles, CA'),
    ('Chicago', '789 Michigan Ave, Chicago, IL'),
    ('San Francisco', '101 Market St, San Francisco, CA'),
    ('Miami', '202 Ocean Dr, Miami, FL');
INSERT INTO CarLocations (CarId, LocationId)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 4),
    (5, 5);
