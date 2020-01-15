namespace Isen.Dotnet.Library.Model
{
    public class Role : BaseEntity
    {
        public string Name { get;set; }
        
        public MyCollection<RolePerson> RolePersons { get;set; }
        public override string ToString() => Name;
    }
}