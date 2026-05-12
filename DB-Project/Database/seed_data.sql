USE VetClinicDB;
GO

-- ============================================================
-- OWNERS
-- ============================================================
INSERT INTO OWNER (ownerID, name, billingAddress, emergencyContact, email)
VALUES
(1, 'Alice Johnson',  '123 Oak St, Springfield',     '555-0101', 'alice@email.com'),
(2, 'Bob Smith',      '456 Maple Ave, Shelbyville',   '555-0102', 'bob@email.com'),
(3, 'Carol Williams',  '789 Pine Rd, Springfield',    '555-0103', 'carol@email.com'),
(4, 'David Brown',    '321 Elm St, Shelbyville',      '555-0104', 'david@email.com'),
(5, 'Eve Davis',      '654 Birch Ln, Springfield',    '555-0105', 'eve@email.com');
GO

-- ============================================================
-- CLINICS
-- ============================================================
INSERT INTO CLINIC (clinicID, location, hasEmergencyFacilities, phone)
VALUES
(1, 'Springfield Central Vet',   1, '555-1001'),
(2, 'Shelbyville Animal Hospital', 1, '555-1002'),
(3, 'Greenfields Pet Clinic',      0, '555-1003');
GO

-- ============================================================
-- VETERINARIANS
-- ============================================================
INSERT INTO VETERINARIAN (vetID, name, specialty, licenseNumber)
VALUES
(1, 'Dr. Sarah Connor',   'General Practice', 'LIC-1001'),
(2, 'Dr. John Hammond',   'Surgery',          'LIC-1002'),
(3, 'Dr. Emily Carter',   'Dermatology',      'LIC-1003');
GO

-- ============================================================
-- PETS
-- ============================================================
INSERT INTO PET (ownerID, petID, name, species, breed, age)
VALUES
-- Alice's pets
(1, 1, 'Buddy',     'Dog',   'Golden Retriever', 4),
(1, 2, 'Whiskers',  'Cat',   'Siamese',          2),
-- Bob's pets
(2, 1, 'Max',       'Dog',   'German Shepherd',  5),
(2, 2, 'Coco',      'Bird',  'Cockatiel',        1),
-- Carol's pets
(3, 1, 'Oreo',      'Cat',   'Persian',          3),
-- David's pet
(4, 1, 'Thumper',   'Rabbit','Holland Lop',      2),
-- Eve's pets
(5, 1, 'Charlie',   'Dog',   'Beagle',           6),
(5, 2, 'Nibbles',   'Hamster','Syrian',          1);
GO

-- ============================================================
-- MEDICAL VISITS
-- Some in April 2026 (last month), some older
-- ============================================================
INSERT INTO MEDICAL_VISIT (visitID, clinicID, vetID, ownerID, petID, visitDate, weight_kg, clinicalNote)
VALUES
-- April 2026 visits (last month)
(1,  1, 1, 1, 1, '2026-04-02', 32.50, 'Annual checkup, healthy'),
(2,  1, 1, 1, 2, '2026-04-02', 4.20,  'Vaccination booster'),
(3,  2, 2, 2, 1, '2026-04-05', 38.00, 'Limping on right front leg'),
(4,  2, 2, 2, 2, '2026-04-05', 0.09,  'Wing clip and nail trim'),
(5,  1, 3, 3, 1, '2026-04-10', 5.10,  'Skin rash treatment'),
(6,  2, 1, 4, 1, '2026-04-12', 2.30,  'Dental checkup'),
(7,  1, 1, 5, 1, '2026-04-15', 14.00, 'Ear infection'),
(8,  1, 1, 5, 2, '2026-04-15', 0.15,  'General checkup'),
(9,  2, 2, 1, 1, '2026-04-20', 32.80, 'Follow-up on allergies'),
(10, 2, 2, 1, 2, '2026-04-20', 4.30,  'Follow-up vaccination'),
-- Older visits (earlier this year and last year)
(11, 1, 1, 1, 1, '2026-01-15', 31.00, 'New patient registration'),
(12, 1, 1, 2, 1, '2026-02-10', 37.00, 'Vaccination'),
(13, 3, 3, 3, 1, '2025-11-20', 5.00,  'Allergy consultation'),
(14, 1, 1, 5, 1, '2025-12-01', 13.50, 'Deworming'),
(15, 2, 2, 4, 1, '2026-03-08', 2.10,  'Checkup');
GO

-- ============================================================
-- VACCINATIONS
-- Linked to medical visits
-- ============================================================
INSERT INTO VACCINATION (vaccinationID, visitID, vaccineType, batchNumber, boosterDueDate)
VALUES
-- Vaccinations given in April 2026 (last month)
(1,  2,  'Rabies',             'RAB-2026-01', '2027-04-02'),
(2,  3,  'Canine Distemper',   'CD-2026-02',  '2026-10-05'),
(3,  5,  'Feline Leukemia',    'FeLV-2026-01','2027-04-10'),
(4,  7,  'Rabies',             'RAB-2026-02', '2027-04-15'),
(5,  8,  'Rabies',             'RAB-2026-01', '2027-04-15'),
(6,  9,  'Canine Parvovirus',  'CPV-2026-01', '2026-10-20'),
(7,  10, 'Feline Calicivirus', 'FCV-2026-01', '2026-10-20'),
-- Older vaccinations
(8,  11, 'Rabies',             'RAB-2025-01', '2026-01-15'),
(9,  12, 'Canine Distemper',   'CD-2025-02',  '2026-02-10'),
(10, 14, 'Rabies',             'RAB-2025-02', '2026-12-01');
GO
