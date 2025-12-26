ALTER TABLE Complaint MODIFY COLUMN ID_complaint INT AUTO_INCREMENT PRIMARY KEY;

-- Обмеження для формату контактів (тільки +380 з 9 цифрами)
ALTER TABLE Client
ADD CONSTRAINT chk_contact_format 
CHECK (contact_info REGEXP '^\\+380[0-9]{9}$');

-- Обмеження для дат (check_out_date > check_in_date)
ALTER TABLE Booking
ADD CONSTRAINT chk_booking_dates 
CHECK (check_out_date > check_in_date);