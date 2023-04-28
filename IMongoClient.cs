using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;


public interface IDataService
{
    MongoDB.Driver.IMongoDatabase Db { get; }
}

public class Database : IDataService
{
    public MongoDB.Driver.IMongoDatabase Db { get; set; }

    public Database(string connectionString)
    {
        // mongodb convention pack
        // Set up MongoDB conventions
        // var pack = new ConventionPack
        // {
        // new EnumRepresentationConvention(BsonType.String)
        // };
        // ConventionRegistry.Register("EnumStringConvention", pack, t => true);

        var client = new MongoDB.Driver.MongoClient(connectionString);
        this.Db = client.GetDatabase("membership");
    }
}

