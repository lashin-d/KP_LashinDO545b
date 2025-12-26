-- Індекси
CREATE INDEX idx_booking_dates ON Booking(check_in_date, check_out_date);
CREATE INDEX idx_client_name ON Client(fullname);
CREATE INDEX idx_room_price ON Room(price);
ALTER TABLE Complaint
ADD UNIQUE INDEX idx_client_complaint_date (ID_client, complaint_date);