using MongoDB.Driver;


public interface IDataService
{
    MongoDB.Driver.IMongoDatabase Db { get; }
}

public class Database : IDataService
{
    public MongoDB.Driver.IMongoDatabase Db { get; set; }

    public Database(string connectionString)
    {
        var client = new MongoDB.Driver.MongoClient(connectionString);
        this.Db = client.GetDatabase("membership");
    }
}

