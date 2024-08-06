using System.Data.SQLite;

namespace HabitLoggerAPP{
    public class HabitDatabase {
        private readonly string connectionString;

        public HabitDatabase(string connectionString) {
            this.connectionString = connectionString;
            CreateDatabase();
        }

        private void CreateDatabase() {
            try{
                using (var connection = new SQLiteConnection(this.connectionString)) {
                    connection.Open();
                    var tableCmd = connection.CreateCommand();

                    tableCmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS habit_logger(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Habit TEXT,
                        Count INTEGER
                        )";
                    tableCmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddHabit(string habit, int count) {
            using(var connection = new SQLiteConnection(this.connectionString)) {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"INSERT INTO habit_logger (Habit, Count) VALUES(\"{habit}\", {count})";
                tableCmd.ExecuteNonQuery();
            }
        }

        public void ShowUserHabits () {
            using(var connection = new SQLiteConnection(connectionString)) {
                connection.Open(); 
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"SELECT * FROM habit_logger";
                using(var reader = tableCmd.ExecuteReader()){
                    while(reader.Read()){
                        Console.WriteLine($"ID: {reader["ID"]} \nHabit: {reader["Habit"]} \nCount: {reader["Count"]}");
                    }
                }
            }
        }

        public void UpdateHabit (string habit, int count) {
            using(var connection = new SQLiteConnection(connectionString)) {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"UPDATE habit_logger SET Count = {count} WHERE Habit = {habit}";
                tableCmd.ExecuteNonQuery();
            }
        }

        public void DeleteHabit (string habit) {
            using(var connection = new SQLiteConnection(connectionString)) {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"DELETE FROM habit_logger WHERE Habit = {habit}";
                tableCmd.ExecuteNonQuery();
            }
        }
    }
}