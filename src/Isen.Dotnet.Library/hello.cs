// Déclaration des improts
using System;

// Déclaration du namespace (un bloc)
namespace Isen.Dotnet.Library
{
    // Déclaration des classes

    /// <summary>
    /// Cette classe dis "Bonjour"
    /// </summary>
    public class Hello
    {
        /// <summary>
        /// Getter et Setter implicite de l'attribut "Name"
        /// </summary>
        /// <param name="set;"></param>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// Constructeur de la class
        /// </summary>
        /// <param name="name"></param>
        public Hello(string name)
        {
            Name = name;
        }

        /// <summary>
        /// return a greating message
        /// </summary>
        /// <returns></returns>
        public string Great()
        {
            string greatMessage = "Hello " + Name + "!";
            return greatMessage;
        }
    }
}