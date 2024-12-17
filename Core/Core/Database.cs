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

        public void createTable(string tableName, List<Schema> columns)
        {
            // for each column, we also need the size  

            if (_tables.ContainsKey(tableName))
            {
                throw new InvalidOperationException("Table already exists");
            }

            _tables[tableName] = new Table(tableName, columns); 
        }

	public void updateTable(string tableName, List<Schema> updatedColumns) 
	{
		if (!_tables.ContainsKey(tableName)) 
		{
			throw new KeyNotFoundException("Table does not exist"); 
		}
	}

	public void deleteTable(string tableName) 
	{
		if (!_tables.ContainsKey(tableName)) 
		{
			throw new KeyNotFoundException("Table does not exist"); 
		}

		_tables.Remove(tableName); 
	}

	public void clearDatabase() {
		_tables.Clear(); 
	}

        public void outputTableFormat(string tableName)
        {
            if (!_tables.ContainsKey(tableName))
            {
                throw new KeyNotFoundException("Table does not exist");
            }

        }

        public void outputTableData(string tableName)
        {
            if (!_tables.ContainsKey(tableName))
            {
                throw new KeyNotFoundException("Table does not exist");
            }
        }

    }

  
    
    public class Schema
    {
        public required string ColumnName; 
        public required long byteSize;
    }

    public class Parameters 
    {
    }

    public class Config 
    {
    }
}
