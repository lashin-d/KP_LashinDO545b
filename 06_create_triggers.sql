DELIMITER //
CREATE TRIGGER update_room_statistics 
AFTER INSERT ON Booking
FOR EACH ROW
BEGIN
    UPDATE Room_Statistics 
    SET booking_count = booking_count + 1,
        popularity_score = popularity_score + 0.5
    WHERE ID_room = NEW.ID_room;
END//
DELIMITER ;