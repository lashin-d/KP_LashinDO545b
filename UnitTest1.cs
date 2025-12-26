using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDBClientApp;
using System.Data;
using MySql.Data.MySqlClient;
using System;

namespace HotelDBClientApp.Tests
{
    [TestClass]
    public class HotelDBClientAppTests
    {
        private DatabaseManager dbManager;
        private readonly string connectionString = "Server=localhost;Database=HotelDB;Uid=root;Pwd=qazwsx111;";
        private static int idCounter = 1000;

        [TestInitialize]
        public void Setup()
        {
            try
            {
                dbManager = new DatabaseManager(connectionString);
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    dbManager.ExecuteNonQuery("SET FOREIGN_KEY_CHECKS = 0;");
                    dbManager.ExecuteNonQuery("DELETE FROM Booking WHERE ID_booking >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Complaint WHERE ID_complaint >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Client_Service WHERE ID_client_service >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Client WHERE ID_client >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Room WHERE ID_room >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Hotel_Building WHERE ID_building >= 1000");
                    dbManager.ExecuteNonQuery("SET FOREIGN_KEY_CHECKS = 1;");
                    connection.Close();
                }
                idCounter = 1000;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to initialize DatabaseManager: {ex.Message}");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                if (dbManager != null)
                {
                    dbManager.ExecuteNonQuery("SET FOREIGN_KEY_CHECKS = 0;");
                    dbManager.ExecuteNonQuery("DELETE FROM Booking WHERE ID_booking >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Complaint WHERE ID_complaint >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Client_Service WHERE ID_client_service >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Client WHERE ID_client >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Room WHERE ID_room >= 1000");
                    dbManager.ExecuteNonQuery("DELETE FROM Hotel_Building WHERE ID_building >= 1000");
                    dbManager.ExecuteNonQuery("SET FOREIGN_KEY_CHECKS = 1;");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Cleanup failed: {ex.Message}");
            }
        }

        [TestMethod]
        public void AddClient_ValidData_InsertsRecord()
        {
            int clientId = idCounter++;
            string fullname = "Test Client";
            string contact = "+380991112233";

            dbManager.ExecuteNonQuery($"INSERT INTO Client (ID_client, fullname, contact_info) VALUES ({clientId}, '{fullname}', '{contact}')");

            var dt = dbManager.ExecuteQuery($"SELECT * FROM Client WHERE ID_client={clientId}");
            Assert.AreEqual(1, dt.Rows.Count, "Client should be added.");
            Assert.AreEqual(fullname, dt.Rows[0]["fullname"], "Fullname should match.");
            Assert.AreEqual(contact, dt.Rows[0]["contact_info"], "Contact info should match.");
        }

        [TestMethod]
        public void EditClient_ValidData_UpdatesRecord()
        {
            int clientId = idCounter++;
            string initialFullname = "Initial Client";
            string initialContact = "+380991112233";
            string updatedFullname = "Updated Client";
            string updatedContact = "+380991112244";

            dbManager.ExecuteNonQuery($"INSERT INTO Client (ID_client, fullname, contact_info) VALUES ({clientId}, '{initialFullname}', '{initialContact}')");

            dbManager.ExecuteNonQuery($"UPDATE Client SET fullname = '{updatedFullname}', contact_info = '{updatedContact}' WHERE ID_client = {clientId}");

            var dt = dbManager.ExecuteQuery($"SELECT * FROM Client WHERE ID_client={clientId}");
            Assert.AreEqual(1, dt.Rows.Count, "Client should still exist.");
            Assert.AreEqual(updatedFullname, dt.Rows[0]["fullname"], "Fullname should be updated.");
            Assert.AreEqual(updatedContact, dt.Rows[0]["contact_info"], "Contact info should be updated.");
        }

        [TestMethod]
        public void DeleteClient_ValidData_RemovesRecord()
        {
            int clientId = idCounter++;
            string fullname = "Test Client Delete";
            string contact = "+380991112233";

            dbManager.ExecuteNonQuery($"INSERT INTO Client (ID_client, fullname, contact_info) VALUES ({clientId}, '{fullname}', '{contact}')");

            dbManager.ExecuteNonQuery($"DELETE FROM Client WHERE ID_client = {clientId}");

            var dt = dbManager.ExecuteQuery($"SELECT * FROM Client WHERE ID_client={clientId}");
            Assert.AreEqual(0, dt.Rows.Count, "Client should be deleted.");
        }

        [TestMethod]
        public void AddComplaint_ValidData_InsertsRecord()
        {
            int clientId = idCounter++;
            int complaintId = idCounter++;
            string fullname = "Complaint Client";
            string contact = "+380991112233";
            string description = "Test complaint description";

            dbManager.ExecuteNonQuery($"INSERT INTO Client (ID_client, fullname, contact_info) VALUES ({clientId}, '{fullname}', '{contact}')");

            dbManager.ExecuteNonQuery($"INSERT INTO Complaint (ID_complaint, ID_client, complaint_date, description) VALUES ({complaintId}, {clientId}, NOW(), '{description}')");

            var dt = dbManager.ExecuteQuery($"SELECT * FROM Complaint WHERE ID_complaint={complaintId}");
            Assert.AreEqual(1, dt.Rows.Count, "Complaint should be added.");
            Assert.AreEqual(clientId, dt.Rows[0]["ID_client"], "Client ID should match.");
            Assert.AreEqual(description, dt.Rows[0]["description"], "Description should match.");
        }

        [TestMethod]
        public void AddComplaint_DuplicateComplaintForClientOnSameDate_Fails()
        {
            int clientId = idCounter++;
            int complaintId1 = idCounter++;
            int complaintId2 = idCounter++;
            string fullname = "Duplicate Complaint Client";
            string contact = "+380991112233";
            string description = "Test complaint description";

            dbManager.ExecuteNonQuery($"INSERT INTO Client (ID_client, fullname, contact_info) VALUES ({clientId}, '{fullname}', '{contact}')");
            dbManager.ExecuteNonQuery($"INSERT INTO Complaint (ID_complaint, ID_client, complaint_date, description) VALUES ({complaintId1}, {clientId}, '2025-05-16 10:00:00', '{description}')");

            try
            {
                dbManager.ExecuteNonQuery($"INSERT INTO Complaint (ID_complaint, ID_client, complaint_date, description) VALUES ({complaintId2}, {clientId}, '2025-05-16 10:00:00', '{description}')");
                Assert.Fail("Should throw an exception due to duplicate complaint.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Duplicate entry") || ex.Message.Contains("constraint"), "Should fail due to duplicate complaint on the same date.");
            }
        }

        [TestMethod]
        public void CountComplaintsByClient_ValidData_ReturnsCorrectCount()
        {
            int clientId = idCounter++;
            int complaintId1 = idCounter++;
            int complaintId2 = idCounter++;
            string fullname = "Count Complaint Client";
            string contact = "+380991112233";

            dbManager.ExecuteNonQuery($"INSERT INTO Client (ID_client, fullname, contact_info) VALUES ({clientId}, '{fullname}', '{contact}')");
            dbManager.ExecuteNonQuery($"INSERT INTO Complaint (ID_complaint, ID_client, complaint_date, description) VALUES ({complaintId1}, {clientId}, '2025-05-16 10:00:00', 'Complaint 1')");
            dbManager.ExecuteNonQuery($"INSERT INTO Complaint (ID_complaint, ID_client, complaint_date, description) VALUES ({complaintId2}, {clientId}, '2025-05-17 10:00:00', 'Complaint 2')");

            var dt = dbManager.ExecuteQuery($"SELECT c.ID_client, cl.fullname, COUNT(*) AS ComplaintCount FROM Complaint c LEFT JOIN Client cl ON c.ID_client = cl.ID_client WHERE c.ID_client = {clientId} GROUP BY c.ID_client, cl.fullname");

            Assert.AreEqual(1, dt.Rows.Count, "Should return one row for the client.");
            Assert.AreEqual(2, Convert.ToInt32(dt.Rows[0]["ComplaintCount"]), "Should count 2 complaints for the client.");
        }

        [TestMethod]
        public void AddBooking_ValidData_InsertsRecord()
        {
            int buildingId = idCounter++;
            int roomId = idCounter++;
            int clientId = idCounter++;
            int bookingId = idCounter++;
            int contractId = 1;

            dbManager.ExecuteNonQuery($"INSERT INTO Hotel_Building (ID_building, building_class, number_of_floors, total_rooms, services) VALUES ({buildingId}, 'Трьохзірковий', 5, 40, 'Wi-Fi, Ресторан')");
            dbManager.ExecuteNonQuery($"INSERT INTO Room (ID_room, ID_building, room_type, floor, price) VALUES ({roomId}, {buildingId}, 'Одномісний', 2, 1500.00)");
            dbManager.ExecuteNonQuery($"INSERT INTO Client (ID_client, fullname, contact_info) VALUES ({clientId}, 'Booking Client', '+380991112233')");

            dbManager.ExecuteNonQuery($"INSERT INTO Booking (ID_booking, ID_client, ID_room, ID_contract, check_in_date, check_out_date, number_of_people, total_price) VALUES ({bookingId}, {clientId}, {roomId}, {contractId}, '2025-05-20 14:00:00', '2025-05-25 12:00:00', 1, 7500.00)");

            var dt = dbManager.ExecuteQuery($"SELECT * FROM Booking WHERE ID_booking={bookingId}");
            Assert.AreEqual(1, dt.Rows.Count, "Booking should be added.");
            Assert.AreEqual(clientId, dt.Rows[0]["ID_client"], "Client ID should match.");
            Assert.AreEqual(roomId, dt.Rows[0]["ID_room"], "Room ID should match.");
            Assert.AreEqual(7500.00m, dt.Rows[0]["total_price"], "Total price should match.");
        }

        [TestMethod]
        public void RoomStatistics_PopularityScore_ReturnsCorrectData()
        {
            int roomId = 101;

            var dt = dbManager.ExecuteQuery($"SELECT rs.ID_room, r.room_type, rs.booking_count, rs.popularity_score FROM Room_Statistics rs LEFT JOIN Room r ON rs.ID_room = r.ID_room WHERE rs.ID_room = {roomId}");

            Assert.AreEqual(1, dt.Rows.Count, "Should return one row for the room.");
            Assert.AreEqual(20, dt.Rows[0]["booking_count"], "Booking count should match the inserted data.");
            Assert.AreEqual(8.50m, dt.Rows[0]["popularity_score"], "Popularity score should match the inserted data.");
        }
    }
}