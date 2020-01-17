using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Isen.Dotnet.Library.Model
{
    public class Person : BaseEntity
    {        
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public DateTime? DateOfBirth {get;set;}

        public City BirthCity {get;set;}
        public int? BirthCityId {get;set;}

        public City ResidenceCity {get;set;}
        public int? ResidenceCityId {get;set;}

        public string PhoneNumber {get;set;}
        public string Mail {get;set;}

        public Service Service {get;set;}
        public int? ServiceId {get;set;}

        public MyCollection<RolePerson> RolePersons {get;set;}
        
        [NotMapped] // ne pas générer ce champ dans la bdd
        public int? Age => DateOfBirth.HasValue ?
            // Nb de jours entre naissance et today / 365
            (int)((DateTime.Now - DateOfBirth.Value).TotalDays / 365) :
            // Pas de date de naissance alors, un entier null
            new int?();
        
        public override string ToString() =>
            $"{FirstName} {LastName} | {DateOfBirth} ({Age}) | {BirthCity} / {ResidenceCity}";

        public string Roles() {
            var sb = new StringBuilder();
            sb.Append(RolePersons[0]?.Role?.Name);
            for(var i = 1; i < RolePersons?.Count; i++)
            {
                sb.Append(", ");
                sb.Append(RolePersons[i]?.Role?.Name);
            }
            return sb.ToString();
        }
    }
}