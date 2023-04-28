using MongoDB.Bson;
using MongoDB.Driver;

public interface IMemberCollection
{
    Task<Member> Create(Member member);
    Task<IEnumerable<Member>> Find();
    Task<Member> GetById(ObjectId objectId);
}

public class MemberCollection : IMemberCollection
{
    private readonly IMongoCollection<Member> members;

    public MemberCollection(IDataService dataservice)
    {
        this.members = dataservice.Db.GetCollection<Member>("members");
    }

    public async Task<Member> Create(Member member)
    {
        await this.members.InsertOneAsync(member);
        return member;
    }

    public async Task<IEnumerable<Member>> Find()
    {
        return await this.members.Find(_ => true).ToListAsync();
    }

    public async Task<Member> GetById(ObjectId id)
    {
        return await this.members.Find(_ => _.Id == id).SingleAsync();
    }
}
