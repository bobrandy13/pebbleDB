using System.Runtime.InteropServices;

namespace Core
{
    public class Database
    {
        private readonly Dictionary<string, Table> _tables;
        // constructor
        public Database(Config config)
        {
            _tables = []; 
        }

	// One of the fields of the schema must be unique
        public void CreateTable(string tableName, Schema columns)
        {
            // for each column, we also need the size  

            if (_tables.ContainsKey(tableName))
            {
                throw new InvalidOperationException("Table already exists");
            }

            // TODO: verify that atleast one of the fields is unique; 

            _tables[tableName] = new Table(tableName, columns);

            // create the database file and the relevant data structures 

            // figure out how database operations work. 

            using (var streamWriter = new StreamWriter("database.db", true))
            {
                streamWriter.WriteLine(tableName);
            }


            return; 
        }

	public void UpdateTable(string tableName, Schema updatedColumns) 
	{
		if (!_tables.ContainsKey(tableName)) 
		{
			throw new KeyNotFoundException("Table does not exist"); 
		}

		_tables[tableName].UpdateSchema(updatedColumns); 

	}

	public void DeleteTable(string tableName) 
	{
		if (!_tables.ContainsKey(tableName)) 
		{
			throw new KeyNotFoundException("Table does not exist"); 
		}

		_tables.Remove(tableName);


		return; 
	}

	public void clearDatabase(bool warning = false) {
        if (warning)
        {
            _tables.Clear();
        }

        return; 
	}

        public void OutputTableFormat(string tableName)
        {
            if (!_tables.ContainsKey(tableName))
            {
                throw new KeyNotFoundException("Table does not exist");
            }

            var schema = _tables[tableName].GetSchema();
        }

        public void OutputTableData(string tableName)
        {
            if (!_tables.ContainsKey(tableName))
            {
                throw new KeyNotFoundException("Table does not exist");
            }
        }

    }


    public class IColumnFormat(string columnName, long columnSize, bool isPrimaryKey)
    {
        public string ColumnName { get; set; } = columnName;
        public long ColumnSize { get; set; } = columnSize;

        public bool IsPrimaryKey { get; set; } = isPrimaryKey;
    }

    public class Schema(string name, List<IColumnFormat> rows)
    {
        public string Name { get; set; } = name;
        public List<IColumnFormat> Rows { get; set; } = rows;
    }

    public class Parameters/**/ 
    {
    }

    public class Config 
    {
    }
}
