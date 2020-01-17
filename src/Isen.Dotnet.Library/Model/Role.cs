using System.Text;

namespace Isen.Dotnet.Library.Model
{
    public class Role : BaseEntity
    {
        public string Name { get;set; }
        
        public MyCollection<RolePerson> RolePersons { get;set; }
        public override string ToString() => Name;

        public string Persons() {
            var sb = new StringBuilder();
            sb.Append($"{RolePersons[0]?.Person?.FirstName} {RolePersons[0]?.Person?.LastName}");
            for(var i = 1; i < RolePersons?.Count; i++)
            {
                sb.Append(", ");
                sb.Append($"{RolePersons[i]?.Person?.FirstName} {RolePersons[i]?.Person?.LastName}");
            }
            return sb.ToString();
        }
    }
}