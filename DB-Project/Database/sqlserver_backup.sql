-- ============================================================
-- SQL SERVER BACKUP SCRIPT
-- Database: VetClinicDB
-- Date: 2026-05-11
-- Compatible with: SQL Server 2016+
-- To restore: Execute this script in SSMS or sqlcmd
-- ============================================================

USE master;
GO

-- Drop and recreate database
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'VetClinicDB')
BEGIN
    ALTER DATABASE VetClinicDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE VetClinicDB;
END
GO

CREATE DATABASE VetClinicDB;
GO

USE VetClinicDB;
GO

-- ============================================================
-- TABLE: OWNER
-- ============================================================
CREATE TABLE OWNER (
    ownerID          INT            NOT NULL PRIMARY KEY,
    name             NVARCHAR(255)  NOT NULL,
    billingAddress   NVARCHAR(500)  NOT NULL,
    emergencyContact NVARCHAR(255)  NOT NULL,
    email            NVARCHAR(255)  NOT NULL
);
GO

-- ============================================================
-- TABLE: PET
-- ============================================================
CREATE TABLE PET (
    ownerID  INT           NOT NULL REFERENCES OWNER(ownerID),
    petID    INT           NOT NULL,
    name     NVARCHAR(255) NOT NULL,
    species  NVARCHAR(100) NOT NULL,
    breed    NVARCHAR(100) NOT NULL,
    age      INT           NOT NULL,
    PRIMARY KEY (ownerID, petID)
);
GO

-- ============================================================
-- TABLE: CLINIC
-- ============================================================
CREATE TABLE CLINIC (
    clinicID               INT           NOT NULL PRIMARY KEY,
    location               NVARCHAR(500) NOT NULL,
    hasEmergencyFacilities BIT           NOT NULL,
    phone                  NVARCHAR(50)  NOT NULL
);
GO

-- ============================================================
-- TABLE: MEDICAL_VISIT
-- ============================================================
CREATE TABLE MEDICAL_VISIT (
    visitID      INT            NOT NULL PRIMARY KEY,
    clinicID     INT            NOT NULL REFERENCES CLINIC(clinicID),
    weight_kg    DECIMAL(6, 2)  NOT NULL,
    clinicalNote NVARCHAR(MAX)  NOT NULL,
    visitDate    DATE           NOT NULL
);
GO

-- ============================================================
-- TABLE: PET_VISIT
-- ============================================================
CREATE TABLE PET_VISIT (
    ownerID INT NOT NULL,
    petID   INT NOT NULL,
    visitID INT NOT NULL REFERENCES MEDICAL_VISIT(visitID),
    PRIMARY KEY (ownerID, petID, visitID),
    FOREIGN KEY (ownerID, petID) REFERENCES PET(ownerID, petID)
);
GO

-- ============================================================
-- TABLE: VACCINATION
-- ============================================================
CREATE TABLE VACCINATION (
    vaccinationID  INT           NOT NULL PRIMARY KEY,
    visitID        INT           NOT NULL REFERENCES MEDICAL_VISIT(visitID),
    vaccineType    NVARCHAR(255) NOT NULL,
    batchNumber    NVARCHAR(100) NOT NULL,
    boosterDueDate DATE          NOT NULL
);
GO

-- ============================================================
-- TABLE: VETERINARIAN
-- ============================================================
CREATE TABLE VETERINARIAN (
    vetID         INT           NOT NULL PRIMARY KEY,
    visitID       INT           NOT NULL REFERENCES MEDICAL_VISIT(visitID),
    name          NVARCHAR(255) NOT NULL,
    specialty     NVARCHAR(255) NOT NULL,
    licenseNumber NVARCHAR(100) NOT NULL
);
GO

-- ============================================================
-- END OF BACKUP SCRIPT
-- ============================================================
