namespace Isen.Dotnet.Library.Model
{
    // Utilisé pour créer une relation Many with Many
    public class RolePerson : BaseEntity
    {
        public Person Person { get;set; }
        public int PersonId { get;set; }
        public Role Role { get;set; }
        public int RoleId { get;set; }
    }
}