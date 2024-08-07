using System.Data.SQLite;

namespace HabitLoggerAPP {
    public class HabitDatabase {
        private readonly string connectionString;

        public HabitDatabase(string connectionString) {
            this.connectionString = connectionString;
            CreateDatabase();
        }

        private void CreateDatabase() {
            using (var connection = new SQLiteConnection(this.connectionString)) {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS habit_logger(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Habit TEXT,
                    Count INTEGER
                    )";
                try {
                    tableCmd.ExecuteNonQuery();
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    connection.Dispose();
                    tableCmd.Dispose();
                }
            }
        }

        public void AddHabit(string habit, int count) {
            habit = habit.ToLower();
            using(var connection = new SQLiteConnection(this.connectionString)) {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"INSERT INTO habit_logger (Habit, Count) VALUES(\"{habit}\", {count})";

                try {
                    tableCmd.ExecuteNonQuery();
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    connection.Dispose();
                    tableCmd.Dispose();
                }
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
            habit = habit.ToLower();
            using(var connection = new SQLiteConnection(connectionString)) {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"UPDATE habit_logger SET Count = {count} WHERE Habit = \"{habit}\"";

                try {
                    int rowsAffected = tableCmd.ExecuteNonQuery();

                    if (rowsAffected > 0) {
                        Console.WriteLine($"Habit {habit} successfully updated to {count}");
                    }
                    else {
                        Console.WriteLine($"No habit matching {habit} found");
                    }
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    connection.Dispose();
                    tableCmd.Dispose();
                }
            }
        }

        public void DeleteHabit (string habit) {
            habit = habit.ToLower();
            using(var connection = new SQLiteConnection(connectionString)) {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"DELETE FROM habit_logger WHERE Habit = \"{habit}\"";
                int rowsAffected = tableCmd.ExecuteNonQuery();

                if (rowsAffected > 0) {
                    Console.WriteLine($"Habit {habit} successfully deleted");
                }
                else {
                    Console.WriteLine($"No habit matching {habit} found");
                }
            }
        }
    }
}