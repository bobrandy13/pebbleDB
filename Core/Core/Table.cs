using System;
using Core;

public class Table
{
	protected Schema schema; 
    private readonly B_Tree = new B_Tree();

	public Table(string tableName, Schema columnNames) 
	{
		this.schema = columnNames; 

		// TODO: Create 2 files
		// 1. Table Index file. 
		// 2. Data file. Binary data only
	}

	// TODO: 
	// This should do two things.
	// 1. Insert into primary and secondary Index
	// 2 .This should also append to the binary data file. 
	public int Insert(Schema Item) 
	{

		return 0; 
	}

	// TODO: 
	// This can just be an abstraction upon the Insert Function(); 
	//
	// Returns 0 if there are no issues; 
	public int InsertMany(List<Schema> items) 
	{

		// TODO: Make this more efficient; 
		foreach (var item in items) {
			try {
				this.Insert(item); 
			} catch (Exception e) {
				throw new Exception("Insert failed", e); 
			}
		}
		return 0; 
	}

	public int Update(string id, Schema updatedSchema)  
	{
		// figure out the index, and then change the binary data. 

		return 0; 
	}

	public int Delete() 
	{
		// should find the index, and then delete it from the file 

		return 0; 
	}

	public Schema GetSchema() 
	{
		if (this.schema == null) {
			throw new NullReferenceException("No pre-existing schema defined."); 
		}
		return this.schema;
	}

	public void UpdateSchema(Schema newSchema) {
		this.schema = newSchema;
	}

	// =========================
	// ======== QUERYING =======
	// =========================

	// Summary: The id is going to be the hashed unique field of the database 
	public Schema Select(string id) 
	{
		var data = new byte[256]; 

		using (var reader = new BinaryReader(new FileStream("hello world", FileMode.Open))) {
			reader.BaseStream.Seek(50, SeekOrigin.Begin); 
		}


        // TODO: Find the ID within the index hashtable and then find the corresponding bytes 
        return new Schema("", []); 
	}

	public List<Schema> SelectMany(List<string> id) 
	{
		return []; 
	}



}
