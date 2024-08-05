using System.Data.SQLite;

string connectionString = @"Data Source=habbit-logger.db";

using (var connection = new SQLiteConnection(connectionString)) {
    connection.Open();
    var tableCmd = connection.CreateCommand();

    tableCmd.CommandText = 
        @"CREATE TABLE IF NOT EXISTS habbit-logger(
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Habbit TEXT,
            Count INTEGER
            )";

    tableCmd.ExecuteNonQuery();

    connection.Close();
}