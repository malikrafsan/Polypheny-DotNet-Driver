using PolyphenyDotNetDriver;

class DriverDemo
{
    public static async Task Main()
    {
        var message = """
This is demo program for PolyphenyDotNetDriver
There are some examples of how to use the driver

Please input one of the options below:
- ping: Ping the server
- select: Execute a SELECT SQL query
- non-query: Execute a DML & DDL SQL statement
- prepared-sql: Execute a prepared SQL statement
- transaction: Execute a SQL transaction queries
- document: Execute a document-based NoSQL query

Please input your option: 
""";

        Console.WriteLine(message);
        var inp = Console.ReadLine();

        switch (inp)
        {
            case "ping":
                await DriverDemo.PingServer();
                return;
            case "select":
                DriverDemo.ExecuteQuery();
                return;
            case "non-query":
                DriverDemo.ExecuteNonQuery();
                return;
            case "prepared-sql":
                DriverDemo.ExecutePreparedSql();
                return;
            case "transaction":
                DriverDemo.ExecuteTransaction();
                return;
            case "document":
                DriverDemo.ExecuteDocumentQuery();
                return;
        }
    }

    private static async Task PingServer()
    {
        using (var connection = PolyphenyDriver.OpenConnection("localhost:20590,pa:"))
        {
            connection.Open();
            await connection.Ping();
            Console.WriteLine("Ping successful");
            connection.Close();
        }
    }

    private static void ExecuteQuery()
    {
        using (var connection = PolyphenyDriver.OpenConnection("localhost:20590,pa:"))
        {
            connection.Open();
            var query = "SELECT * FROM emps";

            var command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText(query);

            var reader = command.ExecuteReader();
            var columns = reader.Columns;
            Console.WriteLine("Columns: " + string.Join(", ", columns));
            Console.WriteLine("Number of rows: " + reader.ResultSets.RowCount());

            // read the result
            Console.WriteLine("Rows: ");
            Console.WriteLine("-----");
            while (reader.Read())
            {
                foreach (var column in columns)
                {
                    Console.WriteLine($"{column}: {reader[column]}");
                }
                Console.WriteLine("-----");
            }

            connection.Close();
        }
    }

    private static void ExecuteNonQuery()
    {
        using (var connection = PolyphenyDriver.OpenConnection("localhost:20590,pa:"))
        {
            connection.Open();

            // DDL, define a table
            Console.WriteLine("Drop table test if exists");
            var command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("DROP TABLE IF EXISTS test");
            command.ExecuteNonQuery();

            Console.WriteLine("Create table test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("CREATE TABLE test (id INT PRIMARY KEY, name VARCHAR(100))");
            command.ExecuteNonQuery();

            // DML, insert a row
            Console.WriteLine("Insert a row into test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("INSERT INTO test (id, name) VALUES (1, 'inserted')");
            command.ExecuteNonQuery();

            // DML, update a row
            Console.WriteLine("Update a row in test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("UPDATE test SET name = 'updated' WHERE id = 1");
            command.ExecuteNonQuery();
            
            // SELECT to verify the update
            Console.WriteLine("Select from test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("SELECT * FROM test");
            var reader = command.ExecuteReader();
            var columns = reader.Columns;

            Console.WriteLine("Columns: " + string.Join(", ", columns));
            Console.WriteLine("Number of rows: " + reader.ResultSets.RowCount());

            // read the result
            Console.WriteLine("Rows: ");
            Console.WriteLine("-----");
            while (reader.Read())
            {
                foreach (var column in columns)
                {
                    Console.WriteLine($"{column}: {reader[column]}");
                }
                Console.WriteLine("-----");
            }

            // DDL, drop the table
            Console.WriteLine("Drop table test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("DROP TABLE IF EXISTS test");
            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    private static void ExecutePreparedSql()
    {
        using (var connection = PolyphenyDriver.OpenConnection("localhost:20590,pa:"))
        {
            connection.Open();

            // DDL, define a table
            Console.WriteLine("Drop table test if exists");
            var command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("DROP TABLE IF EXISTS test");
            command.ExecuteNonQuery();

            Console.WriteLine("Create table test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("CREATE TABLE test (id INT PRIMARY KEY, name VARCHAR(100))");
            command.ExecuteNonQuery();

            // DML, insert a row
            Console.WriteLine("Insert a row into test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("INSERT INTO test (id, name) VALUES (?, ?)").
                WithParameterValues(new object[] { 1, "inserted" });
            command.Prepare();
            command.ExecuteNonQuery();

            // DML, update a row
            Console.WriteLine("Update a row in test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("UPDATE test SET name = ? WHERE id = ?").
                WithParameterValues(new object[] { "updated", 1 });
            command.Prepare();
            command.ExecuteNonQuery();

            // SELECT to verify the update
            Console.WriteLine("Select from test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("SELECT * FROM test");
            var reader = command.ExecuteReader();
            var columns = reader.Columns;

            Console.WriteLine("Columns: " + string.Join(", ", columns));
            Console.WriteLine("Number of rows: " + reader.ResultSets.RowCount());

            // read the result
            Console.WriteLine("Rows: ");
            Console.WriteLine("-----");
            while (reader.Read())
            {
                foreach (var column in columns)
                {
                    Console.WriteLine($"{column}: {reader[column]}");
                }
                Console.WriteLine("-----");
            }

            // DDL, drop the table
            Console.WriteLine("Drop table test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("DROP TABLE IF EXISTS test");
            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    private static void ExecuteTransaction()
    {
        using (var connection = PolyphenyDriver.OpenConnection("localhost:20590,pa:"))
        {
            connection.Open();

            var transaction1 = connection.BeginTransaction();

            // DDL, define a table
            Console.WriteLine("Drop table test if exists");
            var command = new PolyphenyCommand().
                WithConnection(connection).
                WithTransaction(transaction1).
                WithCommandText("DROP TABLE IF EXISTS test");
            command.ExecuteNonQuery();

            Console.WriteLine("Create table test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithTransaction(transaction1).
                WithCommandText("CREATE TABLE test (id INT PRIMARY KEY, name VARCHAR(100))");
            command.ExecuteNonQuery();

            // DML, insert a row
            Console.WriteLine("Insert a row into test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithTransaction(transaction1).
                WithCommandText("INSERT INTO test (id, name) VALUES (1, 'inserted')");
            command.ExecuteNonQuery();

            transaction1.Commit();

            var transaction2 = connection.BeginTransaction();

            // DML, update a row
            Console.WriteLine("Update a row in test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithTransaction(transaction2).
                WithCommandText("UPDATE test SET name = 'updated' WHERE id = 1");
            command.ExecuteNonQuery();

            transaction2.Rollback();

            // SELECT to verify the update
            Console.WriteLine("Select from test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("SELECT * FROM test");
            var reader = command.ExecuteReader();
            var columns = reader.Columns;

            Console.WriteLine("Columns: " + string.Join(", ", columns));
            Console.WriteLine("Number of rows: " + reader.ResultSets.RowCount());

            // read the result
            Console.WriteLine("Rows: ");
            Console.WriteLine("-----");
            while (reader.Read())
            {
                foreach (var column in columns)
                {
                    Console.WriteLine($"{column}: {reader[column]}");
                }
                Console.WriteLine("-----");
            }

            // DDL, drop the table
            Console.WriteLine("Drop table test");
            command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("DROP TABLE IF EXISTS test");
            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    private static void ExecuteDocumentQuery()
    {
        using (var connection = PolyphenyDriver.OpenConnection("localhost:20590,pa:"))
        {
            connection.Open();

            var command = new PolyphenyCommand().
                WithConnection(connection).
                WithCommandText("db.emps.find()");
            var result = command.ExecuteQueryMongo();

            Console.WriteLine("Number of records: " + result.Length);
            Console.WriteLine("Result: ");
            Console.WriteLine("-----");
            foreach (var dictionary in result)
            {
                foreach (KeyValuePair<object, object> kvp in dictionary)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
                Console.WriteLine("-----");
            }

            connection.Close();
        }
    }
}
