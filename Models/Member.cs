using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Member
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public MemberType MemberType { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string State { get; set; }
    public string? ZIP { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string? HomePhoneNumber { get; set; }
    public string? BusinessPhoneNumber { get; set; }
    public string? CellPhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public bool IsActive { get; set; }
    public bool IsHeadHousehold { get; set; }
    public string? Volunteer { get; set; }
    public string? Occupation { get; set; }
    public string? Email { get; set; }
}
