-- Переключення на схему HotelDB та створюємо схему і таблиці (оскільки ми їх видалили)
CREATE DATABASE HotelDB;
USE HotelDB;

-- Таблиця Hotel_Building
CREATE TABLE Hotel_Building (
    ID_building INT PRIMARY KEY,
    building_class VARCHAR(20) NOT NULL,
    number_of_floors INT NOT NULL,
    total_rooms INT NOT NULL,
    services VARCHAR(200) NOT NULL
);

-- Таблиця Room
CREATE TABLE Room (
    ID_room INT PRIMARY KEY,
    ID_building INT NOT NULL,
    room_type VARCHAR(50) NOT NULL,
    floor INT NOT NULL,
    price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_building) REFERENCES Hotel_Building(ID_building)
);

-- Таблиця Client
CREATE TABLE Client (
    ID_client INT PRIMARY KEY,
    fullname VARCHAR(100) NOT NULL,
    contact_info VARCHAR(100) NOT NULL,
    UNIQUE (fullname)
);

-- Таблиця Organization
CREATE TABLE Organization (
    ID_organization INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    org_type VARCHAR(50) NOT NULL,
    discount DECIMAL(5,2) NOT NULL
);

-- Таблиця Contract
CREATE TABLE Contract (
    ID_contract INT PRIMARY KEY,
    ID_organization INT NOT NULL,
    contract_date DATETIME NOT NULL,
    expiry_date DATETIME NOT NULL,
    discount DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (ID_organization) REFERENCES Organization(ID_organization)
);

-- Таблиця Additional_Service
CREATE TABLE Additional_Service (
    ID_service INT PRIMARY KEY,
    service_type VARCHAR(50) NOT NULL,
    price DECIMAL(10,2) NOT NULL
);

-- Таблиця Booking
CREATE TABLE Booking (
    ID_booking INT PRIMARY KEY,
    ID_client INT NOT NULL,
    ID_room INT NOT NULL,
    ID_contract INT,
    check_in_date DATETIME NOT NULL,
    check_out_date DATETIME NOT NULL,
    number_of_people INT NOT NULL CHECK (number_of_people BETWEEN 1 AND 10),
    total_price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_client) REFERENCES Client(ID_client),
    FOREIGN KEY (ID_room) REFERENCES Room(ID_room),
    FOREIGN KEY (ID_contract) REFERENCES Contract(ID_contract)
);

-- Таблиця Client_Service
CREATE TABLE Client_Service (
    ID_client_service INT PRIMARY KEY,
    ID_client INT NOT NULL,
    ID_service INT NOT NULL,
    service_date DATETIME NOT NULL,
    cost DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_client) REFERENCES Client(ID_client),
    FOREIGN KEY (ID_service) REFERENCES Additional_Service(ID_service)
);

-- Таблиця Complaint
CREATE TABLE Complaint (
    ID_complaint INT PRIMARY KEY,
    ID_client INT NOT NULL,
    complaint_date DATETIME NOT NULL,
    description VARCHAR(500) NOT NULL,
    FOREIGN KEY (ID_client) REFERENCES Client(ID_client)
);

-- Таблиця Room_Statistics
CREATE TABLE Room_Statistics (
    ID_stat INT PRIMARY KEY,
    ID_room INT NOT NULL,
    booking_count INT NOT NULL,
    popularity_score DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (ID_room) REFERENCES Room(ID_room)
);