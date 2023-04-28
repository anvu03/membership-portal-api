public class NewMemberInputModel
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public MemberType MemberType { get; internal set; }
  public string Address { get; internal set; }
  public string City { get; internal set; }
  public string State { get; internal set; }
  public string ZIP { get; internal set; }
  public DateTime Expiration { get; internal set; }
  public DateTime BirthDate { get; internal set; }
  public string HomePhoneNumber { get; internal set; }
  public string BusinessPhoneNumber { get; internal set; }
  public string CellPhoneNumber { get; internal set; }
  public bool IsActive { get; internal set; }
  public Gender Gender { get; internal set; }
  public bool IsHeadHousehold { get; internal set; }
  public string Volunteer { get; internal set; }
  public string Occupation { get; internal set; }
  public string Email { get; internal set; }
}
