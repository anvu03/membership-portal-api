using MongoDB.Bson;
using MongoDB.Driver;

public interface IMemberCollection
{
    Task<Member> Create(Member member);
    Task<IEnumerable<Member>> Find(MemberSearchQuery? query);
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

    public async Task<IEnumerable<Member>> Find(MemberSearchQuery? query)
    {
        if (query is null)
        {
            return await this.members.Find(_ => true).ToListAsync();
        }
        var builder = Builders<Member>.Filter;
        var filters = new List<FilterDefinition<Member>>();
        if (query.LastName is not null)
        {
            filters.Add(builder.Eq(_ => _.LastName, query.LastName));
        }
        if (query.Active is not null)
        {
            filters.Add(builder.Eq(_ => _.IsActive, query.Active));
        }
        return await this.members.Find(builder.And(filters)).ToListAsync();
    }

    public async Task<Member> GetById(ObjectId id)
    {
        return await this.members.Find(_ => _.Id == id).SingleAsync();
    }
}
